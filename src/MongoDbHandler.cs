﻿using AwcHelper.Txt.Models;
using MongoDB.Driver;

namespace AwcHelper.Txt;

public class MongoDbHandler
{
    string _connectionString = "mongodb://localhost:27017";
    string _databaseName = "MAL";
    string _animeCollection = "anime";

    public MongoDbHandler() { }

    private IMongoCollection<T> ConnectToMongo<T>(in string collection)
    {
        var client = new MongoClient(_connectionString);
        var db = client.GetDatabase(_databaseName);
        return db.GetCollection<T>(collection);
    }

    public async Task<List<Anime>> GetAllAnime()
    {
        var animeCollection = ConnectToMongo<Anime>(_animeCollection);
        var result = await animeCollection.FindAsync(_ => true);
        return result.ToList();
    }
}