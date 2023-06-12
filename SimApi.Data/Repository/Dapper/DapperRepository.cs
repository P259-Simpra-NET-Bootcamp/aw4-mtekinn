using System.Reflection;
using Dapper;
using SimApi.Base;
using SimApi.Data.Context;

namespace SimApi.Data.Repository;

public class DapperRepository<Entity> : IDapperRepository<Entity> where Entity : BaseModel
{
    protected readonly SimDapperDbContext dbContext;
    private bool disposed;

    public DapperRepository(SimDapperDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public static class DapperHelper
    {
        public static IEnumerable<string> GetParamNames(object obj)
        {
            return obj.GetType().GetProperties().Select(p => p.Name);
        }
    }
    public List<Entity> GetAll()
    {
        using var connection = dbContext.CreateConnection();
        var result = connection.Query<Entity>($"SELECT * FROM {typeof(Entity).Name}");
        return result.ToList();
    }
    public List<Entity> Filter(string sql)
    {
        using var connection = dbContext.CreateConnection(); 
        var result = connection.Query<Entity>(sql);
        return result.ToList();
    }
    public Entity GetById(int id)
    {
        using var connection = dbContext.CreateConnection();
        var result = connection.QueryFirstOrDefault<Entity>($"SELECT * FROM {typeof(Entity).Name} WHERE Id = @Id", new {Id = id});
        return result;
    }
    public void Insert(Entity entity)
    {
        var insertQuery = GenerateInsertQuery();

        using var connection = dbContext.CreateConnection();
        connection.Execute(insertQuery, entity);
    }
    private string GenerateInsertQuery()
    {
        var insertQuery = $"INSERT INTO {typeof(Entity).Name} ({string.Join(",", GetProperties().Skip(1))}) VALUES (@{string.Join(",@", GetProperties().Skip(1))})";
    
        return insertQuery;
    }
    private IEnumerable<string> GetProperties()
    {
        return typeof(Entity).GetProperties().Select(prop => prop.Name);
    }
    public void Update(Entity entity)
    {
        var updateQuery = GenerateUpdateQuery();

        using var connection = dbContext.CreateConnection();
        connection.Execute(updateQuery, entity);
    }
    private string GenerateUpdateQuery()
    {
        var updateQuery = $"UPDATE {typeof(Entity).Name} SET {string.Join(",", GetProperties().Skip(1).Select(p => $"{p} = @{p}"))} WHERE Id = @Id";
    
        return updateQuery;
    }
    public void DeleteById(int id)
    {
        using var connection = dbContext.CreateConnection();
        connection.Execute($"DELETE FROM {typeof(Entity).Name} WHERE Id = @Id", new { Id = id });
    }
}
