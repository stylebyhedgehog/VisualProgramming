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
        }
    }
    void Start()
    {
        settings = MongoClientSettings.FromConnectionString("mongodb+srv://fogdealer:123@cluster0.j1zxo.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
        client = new MongoClient(settings);
        database = client.GetDatabase("myFirstDatabase");
    }

    public IMongoDatabase GetDatabase()
    {
        return database;
    }
}

/*       IMongoCollection<Model_User> userCollection = database.GetCollection<Model_User>("collectionName");
       Model_User e = new Model_User();
       e.name = "hope";
       userCollection.InsertOne(e);
       List<Model_User> userModelList = userCollection.Find(user => true).ToList();
       Model_User[] userAsap = userModelList.ToArray();
       foreach (Model_User asap in userAsap)
       {
           print(asap.name);
       }*/