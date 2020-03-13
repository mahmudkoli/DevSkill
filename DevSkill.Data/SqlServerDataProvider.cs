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

        public (IList<TEntity> records, int total, int totalFiltered) GetDataByStoreProc(int pageIndex, int pageSize, string searchText, string orderBy, string orderDir)
        {
            var result = new List<TEntity>();

            var command = new SqlCommand();
            command.Connection = _sqlConnection;
            command.CommandText = "spProducts_GetAll";
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@PageIndex", pageIndex);
            command.Parameters.AddWithValue("@PageSize", pageSize);
            command.Parameters.AddWithValue("@OrderBy", orderBy);
            command.Parameters.AddWithValue("@OrderDir", orderDir);

            if (!string.IsNullOrEmpty(searchText))
            {
                command.Parameters.AddWithValue("@SearchText", searchText);
            }

            command.Parameters.Add("@TotalCount", SqlDbType.Int);
            command.Parameters["@TotalCount"].Direction = ParameterDirection.Output;
            command.Parameters.Add("@FilteredCount", SqlDbType.Int);
            command.Parameters["@FilteredCount"].Direction = ParameterDirection.Output;

            var reader = command.ExecuteReader();

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

            if (_sqlConnection.State == System.Data.ConnectionState.Open)
                _sqlConnection.Close();

            var totalCount = (int?)command.Parameters["@FilteredCount"].Value;
            var filteredCount = (int?)command.Parameters["@FilteredCount"].Value;

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
