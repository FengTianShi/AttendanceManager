using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttendanceManager.Api.DBContexts;
using AttendanceManager.Api.Models;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace AttendanceManager.Api.Helper
{
    public class DemoManager : IDemoManager
    {
        private readonly PostgresDbContext storage;

        public DemoManager(PostgresDbContext storage)
        {
            this.storage = storage;
        }

        public async Task<IList<PersonInfoModel>> QueryAllPersonInfoAsync()
        {
            string sql = @"";
            sql += " SELECT                             ";
            sql += "   id AS id                         ";
            sql += "   , last_name AS last_name         ";
            sql += "   , first_name AS first_name       ";
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

        public Task<PersonInfoModel> QueryPersonInfoByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
