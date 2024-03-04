using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ARFHomeBudi.Services
{
    public class JobDBService
    {
        private const string DB_NAME = "demo_local_db.d3";
        private readonly SQLiteAsyncConnection _connection;

        public JobDBService()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAME));
            _connection.CreateTableAsync<JobOffer>();
        }

        //GET ALL COLUMNS AND RECORDS
        public async Task<List<JobOffer>> GetJobOffers()
        {
            return await _connection.Table<JobOffer>().ToListAsync();
        }

        public async Task Create(JobOffer joboffer)
        {
            await _connection.InsertAsync(joboffer);
        }

        public async Task Update(JobOffer joboffer)
        {
            await _connection.UpdateAsync(joboffer);
        }

        public async Task Delete(JobOffer joboffer)
        {
            await _connection.DeleteAsync(joboffer);
        }
    }
}
