using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Controller_User 
{
    public static Model_User AddNeWUser(string username, string password)
    {
        Model_User newUser = Repository_User.CreateNew(username, password);
        Repository_User.Add(newUser);
        return newUser;
    }
    public static List<Model_User> GetAllUsers()
    {
        return Repository_User.GetAll();
    }
    public static Model_User GetUserByUsername(string username)
    {
       return Repository_User.GetByUsername(username);
    }
    public static Model_User GetCurrentUser()
    {
        if (Controller_Local.IsUserAuthorized())
        {
            string current_user_username = Controller_Local.GetSavedUserUsername();
            return GetUserByUsername(current_user_username);
        }
        else
        {
            return null;
        }
    }
    public static void IncreaseUserScore(int amount)
    {
        Model_User userUpd = GetCurrentUser();
        userUpd.Score += amount;
        Repository_User.Update(userUpd);
    }

    public static void ChangeRatingForLevel(int level, int rating)
    {
        Model_User userUpd = GetCurrentUser();
        foreach (Available_Level available_Level in userUpd.AvailableLevels)
        {
            if (available_Level.Index == level)
            {
                if (available_Level.Rating >= rating)
                {
                    return;
                }
                available_Level.Rating = rating;
            } 
        }
        Repository_User.Update(userUpd);
    }
    public static void UnlockNewLevelForUser(int level)
    {
        Model_User userUpd = GetCurrentUser();
        Available_Level passed_Level = new Available_Level();
        passed_Level.Index = level;
        passed_Level.Rating = 0;
        userUpd.AvailableLevels.Add(passed_Level);
        Repository_User.Update(userUpd);
    }

    public static void ChangeCurrentLevelForUser(int level)
    {
        Model_User userUpd = GetCurrentUser();
        userUpd.CurrentLevel = level;
        Repository_User.Update(userUpd);
    }

    public static void UnlockNewCharacterForUser(int characterId)
    {
        Model_User userUpd = GetCurrentUser();
        userUpd.AvailableCharactersId.Add(characterId);
        Repository_User.Update(userUpd);
    }

    public static void ChangeCurrentCharacterForUser(int characterId)
    {
        Model_User userUpd = GetCurrentUser();
        userUpd.CharacterId = characterId;
        Repository_User.Update(userUpd);
    }

    public static bool IsLevelAlreadyUnlocked(int level)
    {
        Model_User user = GetCurrentUser();
        return user.AvailableLevels.Any(l => l.Index == level );
    }

    public static int GetUserMaxLevel()
    {
        return GetCurrentUser().AvailableLevels.Last().Index;
    }

    public static int GetCurrentUserRatingForLevel(int level)
    {
        Model_User user = GetCurrentUser();
        Available_Level lvl = user.AvailableLevels.Find(l => l.Index == level);
        return lvl.Rating;
    }
    public static float GetCurrentUserAverageRating()
    {
        Model_User user = GetCurrentUser();
        return GetUserAvarageRating(user);
    }

    public static float GetUserAvarageRating(Model_User user)
    {
        float ratingSum = user.AvailableLevels.Sum(l => l.Rating);
        return (float)Math.Round((Double)(ratingSum / (user.AvailableLevels.Count -1)),1);
    }
}
