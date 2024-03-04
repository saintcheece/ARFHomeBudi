using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARFHomeBudi.Services
{
    [SQLite.Table("Category")]
    public class Category
    {
        [PrimaryKey]
        [AutoIncrement]
        [SQLite.Column("Cat_ID")]
        public int Cat_ID { get; set; }

        [SQLite.Column("Cat_Name")]
        public string Cat_Name { get; set; }

        [SQLite.Column("Cat_Rate")]
        public float Cat_Rate { get; set; }
    }
}
