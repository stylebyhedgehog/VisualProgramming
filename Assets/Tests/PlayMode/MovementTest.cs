using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class MovementTest
{

    [OneTimeSetUp]
    public void SetUp()
    {
        SceneManager.LoadScene("TestScene");
    }

    [UnityTest]
    public IEnumerator MoveForward()
    {
        yield return null;
        var player = GameObject.FindWithTag("Player");
        Vector3 startPos = player.transform.position;
        player.GetComponent<Movement>().moveForward();
        Assert.AreEqual(startPos + new Vector3(0, 1, 0), player.transform.position);
    }

    [UnityTest]
    public IEnumerator MoveBackward()
    {
        yield return null;
        var player = GameObject.FindWithTag("Player");
        Vector3 startPos = player.transform.position;
        player.GetComponent<Movement>().moveBackward();
        Assert.AreEqual(startPos + new Vector3(0, -1, 0), player.transform.position);
    }

    [UnityTest]
    public IEnumerator MoveRight()
    {
        yield return null;
        var player = GameObject.FindWithTag("Player");
        Vector3 startPos = player.transform.position;
        player.GetComponent<Movement>().moveRight();
        Assert.AreEqual(startPos + new Vector3(1, 0, 0), player.transform.position);
    }

    [UnityTest]
    public IEnumerator MoveLeft()
    {
        yield return null;
        var player = GameObject.FindWithTag("Player");
        Vector3 startPos = player.transform.position;
        player.GetComponent<Movement>().moveLeft();
        Assert.AreNotEqual(startPos + new Vector3(-1, 0, 0), player.transform.position);
    }

}
