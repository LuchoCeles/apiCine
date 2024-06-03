using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Threading.Tasks;

namespace ATDapi.Models;

public class Repository{
    private string dbConexion = "DRIVER={ODBC Driver 17 for SQL Server};SERVER=server-terciario.hilet.com,11333;DATABASE=valu;UID=sa;PWD=1234!\"qwerQW;";
    public Repository(){}

    public async Task<dynamic> InsertByQuery(string query)
    {
        using (OdbcConnection connection = new OdbcConnection(dbConexion))
        {
            try
            {
                return await connection.ExecuteAsync(query);

            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }

    public async Task<T> GetByQuery<T>(string query)
    {
        using (OdbcConnection connection = new OdbcConnection(dbConexion))
        {
            return await connection.QueryFirstOrDefaultAsync<T>(query);
        }
    }
    
    public async Task<List<T>> GetListBy<T>(string query)
    {
        using (OdbcConnection connection = new OdbcConnection(dbConexion))
        {
            IEnumerable<T> rows = await connection.QueryAsync<T>(query);
            return rows.AsList();
        }
    }


}