using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using UnitedSystemsCooperative.Bot.Interfaces;
using UnitedSystemsCooperative.Bot.Models;

namespace UnitedSystemsCooperative.Bot.Services;

public class MongoDbService : IDatabaseService
{
    private readonly string _connString;
    public MongoDbService(IConfiguration config)
    {
        _connString = config.GetConnectionString("mongoDb");
    }

    public async Task<T> GetValueAsync<T>(string key) where T : DatabaseItemBase
    {
        var client = GetClient();
        var database = client.GetDatabase("usc");
        var collection = database.GetCollection<T>("discordKeys");
        var doc = await collection.Find(Builders<T>.Filter.Eq("key", key)).FirstOrDefaultAsync();
        if (doc == null)
        {
            throw new Exception("Item Not Found");
        }

        return doc;
    }

    public async Task SetValueAsync<T>(string key, T value) where T : DatabaseItemBase
    {
        var client = GetClient();
        var database = client.GetDatabase("usc");
        var collection = database.GetCollection<T>("discordKeys");

        await collection.FindOneAndUpdateAsync(
            Builders<T>.Filter.Eq("key", key),
            Builders<T>.Update.Set("value", value),
            new FindOneAndUpdateOptions<T>() { IsUpsert = true }
        );
    }

    public Task<JoinRequest> GetJoinRequest(string discordUserName)
    {
        throw new NotImplementedException();
    }

    public Task SetEmail(string tag, string email)
    {
        throw new NotImplementedException();
    }

    private MongoClient GetClient()
    {
        var settings = MongoClientSettings.FromConnectionString(_connString);
        settings.ServerApi = new ServerApi(ServerApiVersion.V1);
        return new MongoClient(settings);
    }
}