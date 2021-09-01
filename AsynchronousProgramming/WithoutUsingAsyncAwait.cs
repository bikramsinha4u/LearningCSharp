using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AsynchronousProgramming
{
    class WithoutUsingAsyncAwait
    {
        CancellationTokenSource cancellationTokenSource;

        public void GetCsvData(string filePath)
        {
            try
            {
                var lines = File.ReadAllLines(filePath);
                var tableData = new List<RowData>();

                foreach (var line in lines.Skip(1))
                {
                    var rowData = RowData.FromCsv(line);
                    tableData.Add(rowData);        
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void GetCsvDataUsingTaskRun(string filePath)
        {
            try
            {
                var loadLinesTask = Task.Run<string[]>(() => {
                    var lines = File.ReadAllLines(filePath);

                    return lines;
                });

                var processLinesTask = loadLinesTask.ContinueWith((completedTask) => {
                    var lines = completedTask.Result;
                });

                Console.WriteLine("async & await is much more readable and maintainable approach.");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void GetCsvDataUsingTaskRunAndAsyncAwait(string filePath)
        {
            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel();
                cancellationTokenSource = null;

                return;
            }
            try
            {
                cancellationTokenSource = new CancellationTokenSource();
                var cancellationToken = cancellationTokenSource.Token;
                cancellationToken.Register(() =>
                {
                    Console.WriteLine("Cancellation requested");
                });

                var loadLinesTask = Task.Run(async () => {
                    using(var stream = new StreamReader(File.OpenRead(filePath)))
                    {
                        var lines = new List<string>();

                        string line;
                        while ((line = await stream.ReadLineAsync()) != null)
                        {
                            if(cancellationToken.IsCancellationRequested)
                            {
                                break;
                            }
                            lines.Add(line);
                        }

                        return lines;
                    }
                }, cancellationToken);

                var processLinesTask = loadLinesTask.ContinueWith((completedTask) => {
                    var lines = completedTask.Result;
                    // further process the lines data
                });

                Console.WriteLine("async & await is much more readable and maintainable approach.");
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
