using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class StartBlock : MonoBehaviour
{
    [SerializeField] private List<string> actions;
    [SerializeField] private Button check;

    private void Start()
    {
        check.onClick.AddListener(() => queryActions(gameObject.transform));
    }
    private void queryActions(Transform parent)
    {
        foreach (Transform child in parent)
        {
            if (child.gameObject.name != "mock")
            {
                Debug.Log(child.gameObject.name);
                actions.Add(child.gameObject.name[0].ToString());
                queryActions(child);
            }
        }
        StartCoroutine(executeActions());
    }

    private IEnumerator executeActions()
    {
        foreach (string action in actions)
        {
            makeAction(action);
            yield return new WaitForSecondsRealtime(1);
        }
    }
    private void makeAction(string letter)
    {
        switch (letter)
        {
            case "g":
                PlayerController.Instance.moveF();
                break;
            case "b":
                PlayerController.Instance.moveB();
                break;
            default:
                Debug.Log("Unrecognized");
                break;
        }

        
    }
}
