using UnityEngine;
using MongoDB.Driver;
using System.Collections.Generic;

public class Connection : MonoBehaviour
{
    public static Connection Instance;
    private MongoClientSettings settings;
    private MongoClient client;
    private IMongoDatabase database;
    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            settings = MongoClientSettings.FromConnectionString("mongodb+srv://fogdealer:123@cluster0.j1zxo.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
            client = new MongoClient(settings);
            database = client.GetDatabase("clot");
        }
    }
    private void Start(){ DontDestroyOnLoad(gameObject);}
    public IMongoDatabase GetDatabase(){ return database;}
}

