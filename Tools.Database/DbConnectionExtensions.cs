using System.Data;
using System.Reflection;

namespace Tools.Database
{
    public static class DbConnectionExtensions
    {
        public static int ExecuteNonQuery(this IDbConnection connection, string query, bool isStoredProcedure = false, object? parameters = null)
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();

            using(IDbCommand command = CreateCommand(connection, query, isStoredProcedure, parameters))
            {
                return command.ExecuteNonQuery();
            }
        }

        public static object? ExecuteScalar(this IDbConnection connection, string query, bool isStoredProcedure = false, object? parameters = null)
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();

            using (IDbCommand command = CreateCommand(connection, query, isStoredProcedure, parameters))
            {
                object? result = command.ExecuteScalar();
                return result is DBNull ? null : result;
            }
        }

        public static IEnumerable<TResult> ExecuteReader<TResult>(this IDbConnection connection, string query, Func<IDataRecord, TResult> mapper, bool isStoredProcedure = false, object? parameters = null)
        {
            ArgumentNullException.ThrowIfNull(mapper);

            if (connection.State == ConnectionState.Closed)
                connection.Open();

            using (IDbCommand command = CreateCommand(connection, query, isStoredProcedure, parameters))
            {
                using(IDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        yield return mapper(reader);
                    }
                }
            }
        }

        private static IDbCommand CreateCommand(IDbConnection connection, string query, bool isStoredProcedure, object? parameters)
        {
            IDbCommand command = connection.CreateCommand();
            command.CommandText = query;

            if(isStoredProcedure)
            {
                command.CommandType = CommandType.StoredProcedure;
            }

            if(parameters is not null)
            {
                Type type = parameters.GetType();

                foreach (PropertyInfo propertyInfo in type.GetProperties())
                {
                    IDataParameter dataParameter = command.CreateParameter();
                    dataParameter.ParameterName = propertyInfo.Name;
                    dataParameter.Value = propertyInfo.GetMethod?.Invoke(parameters, null) ?? DBNull.Value;
                    command.Parameters.Add(dataParameter);
                }
            }

            return command;
        }
    }
}