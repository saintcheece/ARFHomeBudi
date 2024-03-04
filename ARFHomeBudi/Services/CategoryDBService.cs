using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARFHomeBudi.Services
{
    public class CategoryDBService
    {
        private const string DB_NAME = "demo_local_db.d3";
        private readonly SQLiteAsyncConnection _connection;

        public CategoryDBService()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAME));
            _connection.CreateTableAsync<Category>();
        }

        //GETS ALL CATEGORIES
        public async Task<List<Category>> GetCategories()
        {
            return await _connection.Table<Category>().ToListAsync();

        }

        //GET ALL CATEGORIES BY ID
        public async Task<Category> GetByID(int id)
        {
            return await _connection.Table<Category>().Where(x => x.Cat_ID == id).FirstOrDefaultAsync();
        }

        //GET ALL CATEGORIES BY NAME
        public async Task<Category> GetByName(string name)
        {
            return await _connection.Table<Category>().Where(c => c.Cat_Name == name).FirstOrDefaultAsync();
        }

        public async Task Create(Category category)
        {
            await _connection.InsertAsync(category);
        }

        public async Task Update(Category category)
        {
            await _connection.UpdateAsync(category);
        }

        public async Task Delete(Category category)
        {
            await _connection.DeleteAsync(category);
        }

    }
}
