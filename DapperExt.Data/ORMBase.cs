using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperExt.Data
{
    public class ORMBase
    {
            private static string GetConnectionString()
            {
                return ConfigurationManager.AppSettings["MSSQLConnectionString"];
            }


            public static void ExecuteStoredProcNoReturn(string storedProcName, DynamicParameters dynamicParameters)
            {
                var connectionString = GetConnectionString();
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    sqlCon.ExecuteScalar(storedProcName, dynamicParameters, commandType: CommandType.StoredProcedure);
                }
            }

            public static T ExecuteScalarStoredProc<T>(string storedProcName, DynamicParameters dynamicParameters)
            {
                var connectionString = GetConnectionString();
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    return (T)Convert.ChangeType(sqlCon.ExecuteScalar(storedProcName, dynamicParameters, commandType: CommandType.StoredProcedure), typeof(T));
                }
            }

            public static IEnumerable<T> ExecuteStoreProcReturnList<T>(string storedProcName, DynamicParameters param)
            {
                var connectionString = GetConnectionString();
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    return sqlCon.Query<T>(storedProcName, param, commandType: CommandType.StoredProcedure);
                }
            }

            public static T ExecuteSingleStoredProc<T>(string storedProcName, DynamicParameters dynamicParameters)
            {
                var connectionString = GetConnectionString();
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    return sqlCon.QueryFirstOrDefault<T>(storedProcName, dynamicParameters, commandType: CommandType.StoredProcedure);
                }
            }

        }
    }

