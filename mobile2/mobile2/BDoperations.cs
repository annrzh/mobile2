using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace mobile2
{
    public class BDoperations
    {
        SQLiteConnection database;
        public BDoperations(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Goods>();
        }
        public IEnumerable<Goods> GetItems()
        {
            return database.Table<Goods>().ToList();
        }
        public Goods GetItem(int id)
        {
            return database.Get<Goods>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<Goods>(id);
        }
        public int SaveItem(Goods item)
        {
            if(item.ID != 0)
            {
                database.Update(item);
                return item.ID;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}
