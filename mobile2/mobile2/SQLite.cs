using SQLite;
using System;
using System.IO;

namespace mobile2
{
    class SQLite
    {

        string BD;
        SQLiteConnection spisConnection;
        public string GetLocalPath()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, "BD");
            spisConnection.CreateTable<Spisok>();
        }
        public Spisok SaveSpisok(Spisok spisok)
        {
            var existingSpiski = spisConnection.Table<Spisok>().FirstOrDefault(sp => sp.ID == spisok.ID);

            if (existingSpiski != null)
                spisConnection.Update(spisok);
            else
                spisConnection.Insert(spisok);

            return spisConnection.Table<Spisok>().FirstOrDefault(cat => cat.ID == spisok.ID);
        }

        public bool DeleteSpisok(Spisok spisok)
        {
            int delete = spisConnection.Delete(spisok);
            if (delete != -1)
                return true;
            else
                return false;
        }

        public Spisok SearchBySpisok(string id)
        {
            Spisok Spis = spisConnection.Table<Spisok>().FirstOrDefault(sp => sp.ID.Equals(id));
            return Spis;
        }
    }
}
