using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttendanceManager.Api.Models;
using Dapper;
using Giga.Monitor.Core.Data.Postgres;
using Microsoft.EntityFrameworkCore;

namespace AttendanceManager.Api.Helper
{
    public class DemoManager : IDemoManager
    {
        private readonly PostgresContext storage;

        public DemoManager(PostgresContext storage)
        {
            this.storage = storage;
        }

        public async Task<IList<PersonInfoModel>> QueryAllPersonInfoAsync()
        {
            string sql = @"";
            sql += " SELECT                             ";
            sql += "   id AS id                         ";
            sql += "   , last_name AS lastName          ";
            sql += "   , first_name AS firstName        ";
            sql += "   , address AS address             ";
            sql += "   , city AS city                   ";
            sql += " FROM                               ";
            sql += "   persons                          ";
            sql += " ORDER BY                           ";
            sql += "   id                               ";

            try
            {
                IList<PersonInfoModel> persons = (await storage.Database.GetDbConnection().QueryAsync<PersonInfoModel>(sql)).ToList();
                return persons;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<PersonInfoModel> QueryPersonInfoByIdAsync(int id)
        {
            string sql = @"";
            sql += " SELECT                           ";
            sql += "   id AS id                       ";
            sql += "   , last_name AS lastName        ";
            sql += "   , first_name AS firstName      ";
            sql += "   , address AS address           ";
            sql += "   , city AS city                 ";
            sql += " FROM                             ";
            sql += "   persons                        ";
            sql += " WHERE                            ";
            sql += "   id = @id                       ";

            try
            {
                return await storage.Database.GetDbConnection().QueryFirstOrDefaultAsync<PersonInfoModel>(sql, new { id });
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
