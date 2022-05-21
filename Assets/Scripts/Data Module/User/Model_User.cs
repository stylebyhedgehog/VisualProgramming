using MongoDB.Bson;
using System.Collections.Generic;

public class Model_User
{
    public ObjectId _id { set; get; }
    public string Username { set; get; }
    public string Password { set; get; }
    public int Score { set; get; }
    public List<Available_Level> AvailableLevels { set; get; }
    public int CurrentLevel { set; get; }
    public int CharacterId { set; get; }
    public List<int> AvailableCharactersId { set; get; }
}
