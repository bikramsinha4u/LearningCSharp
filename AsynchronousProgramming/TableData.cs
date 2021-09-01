using System;
using System.Collections.Generic;
using System.Text;

namespace AsynchronousProgramming
{
    class TableData
    {
        private List<RowData> Datas = new List<RowData>();

        public RowData this[int i]
        {
            get
            {
                return Datas.Find(x => x.Id == i);
            }

            set
            {
                Datas.Add(value);
            }
        }
    }
}
