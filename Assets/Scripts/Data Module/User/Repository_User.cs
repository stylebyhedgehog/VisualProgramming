using System.Collections;
using UnityEngine;
using MongoDB.Driver;
using System.Collections.Generic;

public class Repository_User : MonoBehaviour
{
    private IMongoDatabase database;
    private IMongoCollection<Model_User> userCollection;


    void Start()
    {
        database = Connection.Instance.GetDatabase();
        userCollection = database.GetCollection<Model_User>("users");
    }

    public List<Model_User> GetAllUsers()
    {
        List<Model_User> allUsers = userCollection.Find(_ => true).ToList();
        return allUsers;
    } 

    public Model_User GetUserByUsername(string username)
    {
        var filter = Builders<Model_User>.Filter.Eq("username", username);
        Model_User user = userCollection.Find(filter).FirstOrDefault(); 
        return user;
    }

    public void AddUser(Model_User user)
    {
        userCollection.InsertOne(user);
    }

 
}
