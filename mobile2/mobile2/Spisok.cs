using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace mobile2
{
    [Table("Spisok")]
   public  class Spisok
    {
        [PrimaryKey, AutoIncrement, Column("ID")]
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}
