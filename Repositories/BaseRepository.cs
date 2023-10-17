using Dapper;
using DotNetAdvancedHerhalingsopdracht.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAdvancedHerhalingsopdracht.Repositories
{
    public abstract class BaseRepository<TEntity> : IDisposable where TEntity : class
    {
        protected abstract string Table {  get; }
        private readonly DbConnection _connection;
        public BaseRepository(DbConnection connection)
        {
            _connection = connection;
            try
            {
                _connection.Open();
            }catch(SqlException ex)
            { 
                Dispose();
                Console.WriteLine("Open Connection - SQL exception - {0}",ex.Message); 
            }
            
        }
        public TEntity? GetById(long id)
        {
            if (_connection.State == System.Data.ConnectionState.Open)
            {
                var result = _connection.QuerySingleOrDefault<TEntity>($"SELECT * FROM [{Table}] WHERE [Id] = @Id", new { Id = id });
                if (result is null)
                {
                    throw new ArgumentException($"The requested Id \"{id}\" does not exist in the database");
                }
                return result;
            }
            else
            {
                throw new InvalidOperationException("Cannot Insert into database when connection is closed");
            }
        }
        public int InsertOneRecord(object objectParameter, string commandText)
        {
            if (_connection.State == System.Data.ConnectionState.Open)
            {
                return _connection.Execute(commandText, objectParameter);
            }
            else { throw new InvalidOperationException("Cannot Insert into database when connection is closed"); }
                
        }
        public IEnumerable<TEntity> GetAll()
        {
            if (_connection.State == System.Data.ConnectionState.Open)
            {
                return _connection.Query<TEntity>($"SELECT * FROM [{Table}]");
            }
            else { throw new InvalidOperationException("Cannot Insert into database when connection is closed"); }
        }
        public void Dispose() => _connection.Dispose();

        protected DbParameter CreateParameter<T>(DbCommand command, string name, T value)
        {
            var parameter = command.CreateParameter();
            parameter.ParameterName = name;
            parameter.Value = value;
            return parameter;
        }
        
        protected abstract void MapCommand(DbCommand command, TEntity entity);
        protected abstract TEntity MapEntity(DbDataReader reader);
        public string TableName()
        {
            var type = typeof(TEntity);
            var attribute = type.GetCustomAttributes(inherit : false)
                .Where(attribute => attribute is TableNameAttribute)
                .FirstOrDefault() as TableNameAttribute;
            return attribute?.Name;
        } 
    }
}
