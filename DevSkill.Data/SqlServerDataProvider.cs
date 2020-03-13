using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace DevSkill.Data
{
    public class SqlServerDataProvider<TEntity> : IDisposable
    {
        private readonly SqlConnection _sqlConnection;

        public SqlServerDataProvider(string connectionString)
        {
            _sqlConnection = new SqlConnection(connectionString);
            _sqlConnection.Open();
        }

        public (IList<TEntity> records, int total, int totalFiltered) GetData(string procedureName, IList<(string Key, object Value, bool IsOut)> parameters)
        {
            var result = new List<TEntity>();

            var command = new SqlCommand(procedureName, _sqlConnection);
            command.CommandType = CommandType.StoredProcedure;

            foreach (var param in parameters)
            {
                if (!param.IsOut)
                    command.Parameters.AddWithValue(param.Key, param.Value);
                else
                {
                    command.Parameters.Add(new SqlParameter 
                    {
                        ParameterName = param.Key,
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output
                    });
                }
            }

            using (var reader = command.ExecuteReader())
            { 
                while (reader.Read())
                {
                    var itemType = typeof(TEntity);
                    var constructor = itemType.GetConstructor(new Type[] { });
                    var instance = constructor.Invoke(new object[] { });
                    var properties = itemType.GetProperties();

                    foreach (var property in properties)
                    {
                        property.SetValue(instance, reader[property.Name]);
                    }

                    result.Add((TEntity)instance);
                }
            }

            var totalCount = (int?)command.Parameters["TotalCount"].Value;
            var filteredCount = (int?)command.Parameters["FilteredCount"].Value;

            return (result, totalCount??0, filteredCount??0);
        }

        public void Dispose()
        {
            if (_sqlConnection != null)
            {
                if (_sqlConnection.State == System.Data.ConnectionState.Open)
                    _sqlConnection.Close();

                _sqlConnection.Dispose();
            }
        }
    }
}
