using MongoDB.Bson;
using System.Collections.Generic;

public class Model_User
{
    public ObjectId _id { set; get; }
    public string Username { private set; get; }
    public string Password { private set; get; }
    public int Score { private set; get; }
    public int Level { private set; get; }

    public int CharacterId { private set; get; }

    public List<int> AvailableCharactersId { private set; get; }
}
