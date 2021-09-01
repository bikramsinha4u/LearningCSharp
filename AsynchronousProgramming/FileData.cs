using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsynchronousProgramming
{
    class FileData
    {
        public void GetCsvData(string filePath)
        {
            string[] csvRows = File.ReadAllLines(filePath, Encoding.Default);

            TableData tableData =  FillTableData(csvRows);
            PrintTableData(tableData);
        }

        public async Task GetCsvDataAsync(string filePath)
        {
            string[] csvRows;
            try
            {
                Task<string[]> task = File.ReadAllLinesAsync(filePath, Encoding.Default);
                csvRows = await task;
            }
            catch(Exception ex)
            {
                throw ex;
            }

            TableData tableData = FillTableData(csvRows);
            PrintTableData(tableData);
        }

        public async Task GetCsvDataLineByLineAsync(string filePath, CancellationTokenSource cancellationTokenSource, CancellationToken cancellationToken)
        {
            TableData tableData = new TableData();

            using (var stream = new StreamReader(File.OpenRead(filePath)))
            {
                await stream.ReadLineAsync(); // Skip the header row in the csv;

                string line;
                int i = 1;
                while((line = await stream.ReadLineAsync()) != null && i <= 5000)
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        break;
                    }
                    var rowData = RowData.FromCsv(line);
                    Console.WriteLine(rowData.Id + ", " + rowData.Company);
                    tableData[i] = rowData;

                    // Work around to demo cancellation token
                    CancelRequest(cancellationTokenSource, i, cancellationToken);

                    if (cancellationToken.IsCancellationRequested)
                    {
                        break;
                    }

                    i++;
                }
            }

            //PrintTableData(tableData);
        }

        private void CancelRequest(CancellationTokenSource cancellationTokenSource, int i, CancellationToken cancellationToken)
        {
            var cancelRequest = "no";
            if (i == 5)
            {
                Console.WriteLine("Do you want to cancel? ");
                cancelRequest = Console.ReadLine();

            }
            if (cancelRequest == "yes")
            {
                cancellationToken.Register(() =>
                {
                    Console.WriteLine("Cancellation requested.");
                });
                cancellationTokenSource.Cancel();
            }
        }

        private TableData FillTableData(string[] csvRows)
        {
            TableData tableData = new TableData();

            int i = 0;
            foreach (var line in csvRows)
            {
                if (i == 0)
                {
                    i++;
                    continue; // Skipping the header row
                }

                if (i == 6)
                {
                    break;
                }

                var rowData = RowData.FromCsv(line);
                tableData[i] = rowData;
                i++;
            }

            return tableData;
        }

        private void PrintTableData(TableData tableData)
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine(tableData[i].Id + ", " + tableData[i].Company);
                Console.WriteLine("----------------");
            }
        }
    }
}
