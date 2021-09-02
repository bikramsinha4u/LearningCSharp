using System;

namespace MultithreadedProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            MulthithreadExamples multhithreadExamples = new MulthithreadExamples();

            //multhithreadExamples.NormlLoopTime();
            //multhithreadExamples.ParallelLoopTime();
            //multhithreadExamples.PerformingAtomicOperations();
            //multhithreadExamples.PerformingAtomicOperationsCancellationToken();
            //multhithreadExamples.ThreadLocalExample();
            //multhithreadExamples.AsyncLocalExample();
            multhithreadExamples.PlinqExample();

            Console.ReadLine();
        }
    }
}
