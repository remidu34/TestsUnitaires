using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsUnitaires
{
    public class Maitre
    {
        public List<Table> tables = new List<Table>();
        public void PrendTable(Table table)
        {
            tables.Add(table);
        }
    }
}
