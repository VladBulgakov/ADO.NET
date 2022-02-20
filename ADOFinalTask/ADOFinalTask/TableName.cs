using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOFinalTask
{
    public class TableName
    {
        public string Schema;
        public string Name;

        public TableName()
        {

        }

        public TableName(string schema, string name)
        {
            Schema = schema;
            Name = name;
        }

        public override string ToString()
        {
            return $"SCHEMA: {Schema} NAME: {Name}";
            //return base.ToString();
        }
    }
}
