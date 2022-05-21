using System.Collections;
using UnityEngine;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

public static class Repository_User 
{
    static IMongoDatabase database = Connection.Instance.GetDatabase();
    static IMongoCollection<Model_User> userCollection = database.GetCollection<Model_User>("users");

    public static Model_User CreateNew(string username, string password)
    {
        Model_User user = new Model_User();
        user.Username = username;
        user.Password = Cryptography.Encrypt(password);
        user.Score = 0;
        user.CurrentLevel = 1;
        Available_Level available_Level = new Available_Level() { Index = 1, Rating = 0};
        user.AvailableLevels = new List<Available_Level>() { available_Level };
        user.CharacterId = 1;
        user.AvailableCharactersId = new List<int>() { user.CharacterId };
        return user;
    }
    public static List<Model_User> GetAll()
    {
        List<Model_User> allUsers = userCollection.Find(_ => true)
            .SortByDescending(e => e.Score).ToList();
        return allUsers;
    } 
    public static Model_User GetByUsername(string username)
    {
        var filter = Builders<Model_User>.Filter.Eq("Username", username);
        return userCollection.Find(filter).FirstOrDefault();
    }
    public static void Add(Model_User user)
    {
        Debug.Log(user.Username);
        userCollection.InsertOne(user);
    }
    public static void Update(Model_User userToUpd)
    {
        userCollection.FindOneAndReplace(user => user._id == userToUpd._id, userToUpd);
    }
}
