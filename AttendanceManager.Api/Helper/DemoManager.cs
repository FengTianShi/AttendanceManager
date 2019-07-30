using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AttendanceManager.Api.Models;
using Dapper;
using Giga.Monitor.Core.Data.Postgres;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace AttendanceManager.Api.Helper
{
    public class DemoManager : IDemoManager
    {
        private readonly PostgresContext storage;
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

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
                logger.Error(e.Message);
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
                logger.Error(e.Message);
                throw e;
            }
        }

        public async Task<bool> UpdatePersonInfoByIdAsync(PersonInfoModel person)
        {
            string sql = @"";
            sql += " UPDATE persons                         ";
            sql += " SET                                    ";
            sql += "   last_name = @lastName                ";
            sql += "   , first_name = @firstName            ";
            sql += "   , address = @address                 ";
            sql += "   , city = @city                       ";
            sql += " WHERE                                  ";
            sql += "   id = @id                             ";

            var conn = storage.Database.GetDbConnection();

            if (conn.State == ConnectionState.Closed) conn.Open();

            using (var trun = conn.BeginTransaction())
            {
                try
                {
                    var updateRowNum = await conn.ExecuteAsync(sql, new
                    {
                        person.lastName,
                        person.firstName,
                        person.address,
                        person.city,
                        person.id
                    }, trun);

                    trun.Commit();

                    return updateRowNum > 0;
                }
                catch (Exception e)
                {
                    logger.Error(e.Message);
                    trun.Rollback();
                    throw e;
                }
            }
        }

        public async Task<bool> DeletePersonInfoByIdAsync(int id)
        {
            string sql = @"";
            sql += " DELETE                  ";
            sql += " FROM                    ";
            sql += "   persons               ";
            sql += " WHERE                   ";
            sql += "   id = @id              ";

            var conn = storage.Database.GetDbConnection();

            if (conn.State == ConnectionState.Closed) conn.Open();

            using (var trun = conn.BeginTransaction())
            {
                try
                {
                    var updateRowNum = await conn.ExecuteAsync(sql, new
                    {
                        id
                    }, trun);

                    trun.Commit();

                    return updateRowNum > 0;
                }
                catch (Exception e)
                {
                    logger.Error(e.Message);
                    trun.Rollback();
                    throw e;
                }
            }
        }

        public async Task<bool> InsertPersonInfoAsync(PersonInfoModel person)
        {
            int maxId = QueryPersonsMaxId();

            string sql = @"";
            sql += " INSERT                                                              ";
            sql += " INTO persons(id, last_name, first_name, address, city)              ";
            sql += " VALUES (@id, @lastName, @firstName, @address, @city)                ";

            var conn = storage.Database.GetDbConnection();

            if (conn.State == ConnectionState.Closed) conn.Open();

            using (var trun = conn.BeginTransaction())
            {
                try
                {
                    var updateRowNum = await conn.ExecuteAsync(sql, new
                    {
                        id = maxId,
                        person.lastName,
                        person.firstName,
                        person.address,
                        person.city
                    }, trun);

                    trun.Commit();

                    return updateRowNum > 0;
                }
                catch (Exception e)
                {
                    logger.Error(e.Message);
                    trun.Rollback();
                    throw e;
                }
            }
        }

        public int QueryPersonsMaxId()
        {
            string sql = @"";
            sql += " SELECT           ";
            sql += "   max(id)        ";
            sql += " FROM             ";
            sql += "   persons        ";

            try
            {
                int? maxId = storage.Database.GetDbConnection().QueryFirstOrDefault<int?>(sql);
                return maxId.HasValue ? maxId.Value + 1 : 1;
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                throw e;
            }
        }
    }
}
