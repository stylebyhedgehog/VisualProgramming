using System.Collections;
using UnityEngine;
using MongoDB.Driver;
using System.Collections.Generic;

public static class Repository_User 
{
    private static IMongoDatabase database = Connection.Instance.GetDatabase();
    private static IMongoCollection<Model_User> userCollection = database.GetCollection<Model_User>("users");


    public static List<Model_User> GetAllUsers()
    {
        List<Model_User> allUsers = userCollection.Find(_ => true).ToList();
        return allUsers;
    } 

    public static Model_User GetUserByUsername(string username)
    {
        Model_User user = null;
        var filter = Builders<Model_User>.Filter.Eq("Username", username);
        user = userCollection.Find(filter).FirstOrDefault();
        return user;
    }

    public static void AddUser(Model_User user)
    {
        userCollection.InsertOne(user);
    }

    public static void addScore(int amount)
    {
        Model_User userUpd = SaveSystem.Instance.getCurrentUser();
        userUpd.Score += amount;
        SaveSystem.Instance.updateUser(userUpd);
        userCollection.FindOneAndReplace(user => user._id == userUpd._id, userUpd);
    }

    public static void changeLevel(int level)
    {
        Model_User userUpd = SaveSystem.Instance.getCurrentUser();
        userUpd.Level = level;
        SaveSystem.Instance.updateUser(userUpd);
        userCollection.FindOneAndReplace(user => user._id == userUpd._id, userUpd);
    }

    public static void changeCharacter(int id)
    {
        Model_User userUpd = SaveSystem.Instance.getCurrentUser();
        userUpd.CharacterId = id;
        SaveSystem.Instance.updateUser(userUpd);
        userCollection.FindOneAndReplace(user => user._id == userUpd._id, userUpd);
    }


    public static void addCharacter(int id)
    {
        Model_User userUpd = SaveSystem.Instance.getCurrentUser();
        userUpd.AvailableCharactersId.Add(id);
        SaveSystem.Instance.updateUser(userUpd);
        userCollection.FindOneAndReplace(user => user._id == userUpd._id, userUpd);
    }
}
