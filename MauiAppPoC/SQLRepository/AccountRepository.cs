using SQLite;
using System.Reflection;

namespace MauiAppPoC.SQLRepository
{
    public class AccountRepository
    {
        private readonly SQLiteConnection _database;

        public AccountRepository(string dbName)
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory;
            DirectoryInfo parentDir = Directory.GetParent(path).Parent.Parent.Parent.Parent.Parent;
            var dbPath = Path.Combine(parentDir.ToString(), dbName);
            var pa1 = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var pa2 = System.AppDomain.CurrentDomain.BaseDirectory;




            _database = new SQLiteConnection(dbPath);
            _database.CreateTable<Account>();
   
        }

        public List<Account> GetAccounts()
        {
            return _database.Table<Account>().ToList();
        }
        public List<Artist> GetArtists()
        {
            return _database.Table<Artist>().ToList();
        }
        public int CreateAccount(Account account)
        {
            return _database.Insert(account);
        }

        public int UpdateAccount(Account account)
        {
            return _database.Update(account);
        }

        public int DeleteAccount(Account account)
        {
            return _database.Delete(account);
        }

        public List<Account> QueryAccountWithPositiveBalance()
        {
            return _database.Query<Account>("SELECT * FROM Account WHERE Balance > 0");
        }

        public List<Account> LinqZeroBalance()
        {
            return _database.Table<Account>().Where(a => a.Balance == 0).ToList();
        }
    }
}
