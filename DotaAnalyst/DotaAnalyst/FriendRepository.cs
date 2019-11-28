using System.Collections.Generic;
using System.Linq;
using SQLite;
using Xamarin.Forms;

namespace DotaAnalyst
{
    public class FriendRepository
    {
        SQLiteConnection database;
        public FriendRepository(string filename)
        {
            string databasePath = DependencyService.Get<ISQLite>().GetDatabasePath(filename);
            database = new SQLiteConnection(databasePath);
            database.CreateTable<DotaHero>();
        }
        public IEnumerable<DotaHero> GetItems()
        {
            return (from i in database.Table<DotaHero>() select i).ToList();

        }
        public DotaHero GetItem(int id)
        {
            return database.Get<DotaHero>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<DotaHero>(id);
        }
        public int SaveItem(DotaHero item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }

    }

}
