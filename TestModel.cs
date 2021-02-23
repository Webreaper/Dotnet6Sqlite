using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Dotnet6Sqlite
{
    public class TestContext : DbContext
    {
        const string dbPath = "./TestDB.db";

        public DbSet<Folder> Folders { get; set; }

        /// <summary>
        /// Basic initialisation for the DB that are generic to all DB types
        /// </summary>
        /// <param name="options"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            string dataSource = $"Data Source={dbPath}";
            options.UseSqlite(dataSource);
        }
    }

    public class Folder
    {
        [Key]
        public int FolderId { get; set; }
        public string Path { get; set; }
    }
}
