using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MultithreadedProgramming
{
    class MulthithreadExamples
    {
        public object syncRoot = new object();

        public void NormlLoopTime()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            decimal total = 0;
            for (int i = 0; i < 100; i++)
            {
                total += Compute(i);
            }


            stopwatch.Stop();

            Console.WriteLine(total);
            Console.WriteLine("It took: " + stopwatch.ElapsedMilliseconds + "ms");
        }

        private void ParallelLoopTime()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            decimal total = 0;
            Parallel.For(0, 100, (i) => {
                // total += Compute(i);  // This gives wrong result as the thread keeps updating total variable parallely 

                // fix for the above line
                var result = Compute(i);
                lock (syncRoot)  // Only lock for short time
                {
                    total += result;
                }
            });

            stopwatch.Stop();

            Console.WriteLine(total);
            Console.WriteLine("It took: " + stopwatch.ElapsedMilliseconds + "ms");
        }

        private void PerformingAtomicOperations()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            int total = 0;
            Parallel.For(0, 100, (i) => {
                var result = (int)Compute(i);
                Interlocked.Add(ref total, result); // Works on int type only
            });

            stopwatch.Stop();

            Console.WriteLine(total);
            Console.WriteLine("It took: " + stopwatch.ElapsedMilliseconds + "ms");
        }

        public void PerformingAtomicOperationsCancellationToken()
        {
            var stopwatch = new Stopwatch();
            var cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.CancelAfter(2000);
            var parallelOptions = new ParallelOptions
            {
                CancellationToken = cancellationTokenSource.Token,
                MaxDegreeOfParallelism = 1
            };

            stopwatch.Start();
            int total = 0;
            try
            {
                Parallel.For(0, 100, parallelOptions, (i) => {
                    var result = (int)Compute(i);
                    Interlocked.Add(ref total, result); // Works on int type only
                });
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine("Cancellation Requested.");
            }

            stopwatch.Stop();

            Console.WriteLine(total);
            Console.WriteLine("It took: " + stopwatch.ElapsedMilliseconds + "ms");
        }

        private ThreadLocal<decimal?> threadLocal = new ThreadLocal<decimal?>();
        public void ThreadLocalExample()
        {
            var options = new ParallelOptions { MaxDegreeOfParallelism = 2 };
            Parallel.For(0, 100, options, (i) => {
                var currentValue = threadLocal.Value; // Contains value from each thread // if some task run on the exisitng thread then threadLocal value may give wrong result
                threadLocal.Value = Compute(i);
            });

            var totalValues = threadLocal.Values; // All thread values are retrieved.
        }

        public void PlinqExample()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            // Normal Way
            //var result = Enumerable.Range(0, 100)
            //    .Select(Compute)
            //    .Sum();

            var result = Enumerable.Range(0, 100)
                .AsParallel()
                .AsOrdered()
                //.WithDegreeOfParallelism(1)
                //.WithCancellation(new CancellationToken(canceled: true))
                .Select(Compute)
                .Take(10);
                //.Sum();

            stopwatch.Stop();

            result.ForAll(Console.WriteLine);
            Console.WriteLine(result);
            Console.WriteLine("It took: " + stopwatch.ElapsedMilliseconds + "ms");
        }

        /// <summary>
        /// When you write to AsyncLocal a local copy will be created.
        /// The outer contexts value will not be oberwritten!
        /// </summary>
        private AsyncLocal<decimal?> asyncLocal = new AsyncLocal<decimal?>();
        public void AsyncLocalExample()
        {
            asyncLocal.Value = 200;

            var options = new ParallelOptions { MaxDegreeOfParallelism = 2 };
            Parallel.For(0, 100, options, (i) => {
                var currentValue = asyncLocal.Value; // Create a local copy of the variable.
                asyncLocal.Value = Compute(i);
            });

            var currentValue = asyncLocal.Value; // will print 200!
        }

        private static Random random = new Random();
        private static decimal Compute(int value)
        {
            var randomMs = random.Next(10, 50);
            var end = DateTime.Now + TimeSpan.FromMilliseconds(randomMs);

            while (DateTime.Now < end) { }

            return value + 0.5m;
        }
    }
}
