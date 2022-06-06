using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class BehaviorTest
{

    [OneTimeSetUp]
    public void SetUp()
    {
        SceneManager.LoadScene("TestScene");
    }

    [UnityTest]
    public IEnumerator PassLevel()
    {
        yield return null;
        var player = GameObject.FindWithTag("Player");
        for (int i=0; i<=11; i++)
        {
            player.GetComponent<Movement>().moveRight();
        }
        GameObject rewardStep = GameObject.FindGameObjectWithTag("RewardWindow");
        Assert.IsTrue(rewardStep.activeSelf);
    }

}
