using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARFHomeBudi.Services
{
    public class UniversalDBService
    {
        private readonly UserDBService _userDBService;
        private readonly CategoryDBService _catDBService;
        private readonly JobDBService _jobDBService;

        private const string DB_NAME = "demo_local_db.d3";
        private readonly SQLiteAsyncConnection _connection;

        public UniversalDBService(UserDBService userdn, CategoryDBService catdb, JobDBService jobdb)
        {
            _userDBService = userdn;
            _catDBService = catdb;
            _jobDBService = jobdb;
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAME));
        }

        public class JobOfferDetails
        {
            public string JobTitle { get; set; }
            public string Location { get; set; }
            public string CatName { get; set; }
            public string JobDesc { get; set; }
            public DateTime JobSched { get; set; }
            public decimal JobAddPay { get; set; }
        }

        public async Task<List<JobOfferDetails>> GetJobOffersDetails()
        {
            return await _connection.QueryAsync<JobOfferDetails>(
                @"SELECT j.Job_Title AS JobTitle,
                       u.U_City || ' ' || u.U_Town AS Location,
                       c.Cat_Name AS CatName,
                       j.Job_Desc AS JobDesc,
                       strftime('%M-%d-%Y', j.Job_Sched) AS JobSched,
                       j.Job_AddPay AS JobAddPay
                FROM JobOffer j
                INNER JOIN User u ON j.U_ID = u.U_ID
                INNER JOIN Category c ON j.Cat_ID = c.Cat_ID");
        }
    }
}