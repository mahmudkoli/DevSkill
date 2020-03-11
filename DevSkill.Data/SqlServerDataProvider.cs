using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        public IEnumerable<TEntity> GetData(string sql) 
        {
            var result = new List<TEntity>();

            var command = new SqlCommand(sql, _sqlConnection);

            var reader = command.ExecuteReader();

            while(reader.Read())
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

            return result;
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
