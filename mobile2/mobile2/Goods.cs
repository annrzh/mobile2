using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace mobile2
{
    [Table("Goods")]
    public class Goods
    {
        [PrimaryKey,AutoIncrement,Column("ID")]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
