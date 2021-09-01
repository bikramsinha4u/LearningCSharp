using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsynchronousProgramming
{
    class Program
    {
        async static Task Main(string[] args)
        {
            const string csvFilePath = @"D:\Program\Sample-Spreadsheet-50000-rows.csv";

            var fileData = new FileData();
            //fileData.GetCsvData(csvFilePath);
            //await fileData.GetCsvDataAsync(csvFilePath);
            
            await GetCsvDataLineByLine(csvFilePath, fileData);   

            Console.ReadLine();
        }

        private static async Task GetCsvDataLineByLine(string csvFilePath, FileData fileData)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            
            await fileData.GetCsvDataLineByLineAsync(csvFilePath, cancellationTokenSource, cancellationToken);
        }
    }
}
