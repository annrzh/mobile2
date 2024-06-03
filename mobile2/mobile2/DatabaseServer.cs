using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace mobile2
{
    class DatabaseServer
    {
        public readonly SQLiteConnection _database;

        public DatabaseServer(string dbpath)
        {
            _database = new SQLiteConnection(dbpath);
            _database.CreateTable<Spisok>();
        }

        public List<Spisok> GetItems()
        {
            return (from t in _database.Table<Spisok>() select t).ToList();
        }
        public void SaveItem(Spisok item)
        {
            if (item.ID != 0)
            {
                _database.Update(item);
            }
            else
            {
                _database.Insert(item);
            }
        }
    }
}
