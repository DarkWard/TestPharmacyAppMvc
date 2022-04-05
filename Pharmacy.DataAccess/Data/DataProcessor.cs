using Pharmacy.DataAccess.Extensions;
using Pharmacy.Models.Attributes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace Pharmacy.DataAccess.Data
{
    public class DataProcessor
    {
        private readonly string _connectionString;

        public DataProcessor(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add<T>(T entity)
        {
            var paramsList = entity.GetType().GetProperties().Where(x => x.GetCustomAttribute<IdentityAttribute>() == null).Select(x => new SqlParameter
            {
                ParameterName = "@" + x.Name.ToLowerFirstChar(),
                Value = x.GetValue(entity),
            });

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand($"sp_InsertTo{entity.GetType().GetCustomAttribute<TableNameAttribute>().Name}", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                foreach (var param in paramsList)
                {
                    command.Parameters.Add(param);
                }

                entity.GetType().GetProperties().Where(x => x.GetCustomAttribute<IdentityAttribute>() == null).Select(x =>
                    command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@" + x.Name.ToLowerFirstChar(),
                        Value = x.GetValue(entity)
                    }));

                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<T> GetAll<T>()
        {
            var type = typeof(T);
            var list = new List<T>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand($"sp_GetAll{type.GetCustomAttribute<TableNameAttribute>().Name}", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    T obj = (T)Activator.CreateInstance(type);
                    type.GetProperties().ToList().ForEach(p =>
                    {
                        p.SetValue(obj, reader[p.Name]);
                    });
                    list.Add(obj);
                }
            }

            return list;
        }

        public void Remove<T>(T entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand($"sp_RemoveFrom{entity.GetType().GetCustomAttribute<TableNameAttribute>().Name}", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@itemId",
                    Value = entity.GetType().GetProperties().Where(x => x.GetCustomAttribute<IdentityAttribute>() != null).First().GetValue(entity)
                });

                command.ExecuteNonQuery();
            }
        }

        public void Update<T>(T entity)
        {
            var paramsList = entity.GetType().GetProperties().Where(x => x.GetCustomAttribute<IdentityAttribute>() == null).Select(x => new SqlParameter
            {
                ParameterName = "@" + x.Name.ToLowerFirstChar(),
                Value = x.GetValue(entity),
            });

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"sp_Update{entity.GetType().GetCustomAttribute<TableNameAttribute>().Name}", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@itemId",
                    Value = entity.GetType().GetProperties().Where(x => x.GetCustomAttribute<IdentityAttribute>() != null).First().GetValue(entity)
                });

                foreach (var param in paramsList)
                {
                    command.Parameters.Add(param);
                }

                command.ExecuteNonQuery();
            }
        }
    }
}