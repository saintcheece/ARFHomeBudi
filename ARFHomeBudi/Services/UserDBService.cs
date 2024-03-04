
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace ARFHomeBudi.Services
{


    public class UserDBService
    {
        private const string DB_NAME = "demo_local_db.d3";
        private readonly SQLiteAsyncConnection _connection;

        public UserDBService()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAME));
            _connection.CreateTableAsync<User>();
        }

        //CHECKS LEGITIMACY OF ACCOUNT AND ASSIGNS TO GLOBAL VARIABLE
        public async Task<User> VerifyUser(string email, string pass)
        {
            string query = "SELECT U_ID, U_FName, U_LName, U_Role FROM user WHERE U_Email = '"+email+"' AND U_Pass = '"+pass+"'";
            Console.WriteLine(query);
            var result = await _connection.QueryAsync<User>(query);
            Console.WriteLine(query);
            return result.FirstOrDefault();
        }

        //GETS ALL USERS
        public async Task<List<User>> GetUsers()
        {
            return await _connection.Table<User>().ToListAsync();

        }

        public async Task<User> GetByID(int id)
        {
            return await _connection.Table<User>().Where(x => x.U_ID == id).FirstOrDefaultAsync();
        }

        public async Task Create(User user)
        {
            await _connection.InsertAsync(user);
        }

        public async Task Update(User user)
        {
            await _connection.UpdateAsync(user);
        }

        public async Task Delete(User user)
        {
            await _connection.DeleteAsync(user);
        }
        public async Task<List<User>> GetReadable()
        {
            return await _connection.QueryAsync<User>(
                @"SELECT *
                FROM User u");
        }
        public async Task<List<User>> GetSearch(string x)
        {
            string sql = "SELECT * FROM User u WHERE u.U_Email LIKE '"+x+"' OR u.U_Pass LIKE '"+x+"' OR u.U_FName LIKE '"+x+"' OR u.U_LName LIKE '"+x+"' OR u.U_Cntry LIKE '"+x+"' OR u.U_City LIKE '"+x+"' OR u.U_Prov LIKE '"+x+"' OR u.U_Town LIKE '"+x+"' OR u.U_HNum LIKE '"+x+"' OR u.U_FB LIKE '"+x+"'";

            Console.WriteLine(sql);
            return await _connection.QueryAsync<User>(sql);
        }
    }
}