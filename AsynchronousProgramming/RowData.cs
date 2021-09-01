using System;
using System.Collections.Generic;
using System.Text;

namespace AsynchronousProgramming
{
    class RowData
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string Company { get; set; }
        public int Qty1 { get; set; }
        public int Qty2 { get; set; }
        public int Qty3 { get; set; }
        public int Qty4 { get; set; }
        public string Lacation { get; set; }
        public string Type { get; set; }
        public int Percent { get; set; }

        public static RowData FromCsv(string commaSeparatedRowDataString)
        {
            string[] arr = commaSeparatedRowDataString.Split(',');
            int.TryParse(arr[0], out int id);

            return new RowData { Id = id, Company = arr[3] };
        }
    }
}
