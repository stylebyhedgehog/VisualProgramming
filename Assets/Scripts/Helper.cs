using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Helper : MonoBehaviour
{

    [SerializeField] private Text info;
    [SerializeField] private Button skip;
    [SerializeField] private Text btnText;
    [SerializeField] private GameObject tutor;
    [SerializeField] private GameObject cloud;
    [SerializeField] private TypeWriter typeWriter;
    private Model_Level currentLevel;
    private Model_Theory currentTheory;
    private int currentTheoryIndex = 0;
    void Start()
    {
        currentLevel = Controller_Level.GetCurrentLevel();
        if (Controller_User.GetUserRatingForLevel(Controller_User.GetCurrentUser(),currentLevel.Index) == 0)
        {
            ShowHelpInfo();
        }
    }

    public void ShowHelpInfo()
    {
        skip.onClick.RemoveAllListeners();
        currentLevel = Controller_Level.GetCurrentLevel();
        OpenHelper();
        if (currentLevel.Theory.Count == 0)
        {
            info.text = "Для данного уровня нет подсказок";
            btnText.text = "Приступить";
            typeWriter.StartTyping();
            skip.onClick.AddListener(() => CloseHelper());
        }
        else
        {
            StartTyping();
            skip.onClick.AddListener(() => StartTyping());
        }
    }
    private void StartTyping()
    {
        typeWriter.StopTyping();
        info.text = "";
        currentTheory = currentLevel.Theory[currentTheoryIndex];
        info.text = currentTheory.Content;
        btnText.text = "Далее";
        if (currentTheoryIndex + 1 >= currentLevel.Theory.Count)
        {
            btnText.text = "Приступить";
            skip.onClick.RemoveAllListeners();
            skip.onClick.AddListener(() => CloseHelper());
        }
        else
        {
            currentTheoryIndex += 1;
            currentTheory = currentLevel.Theory[currentTheoryIndex];
        }
        typeWriter.StartTyping();
    }

    private void OpenHelper()
    {
        cloud.SetActive(true);
        info.gameObject.SetActive(true);
        skip.gameObject.SetActive(true);
        tutor.SetActive(true);
    }

    private void CloseHelper()
    {
        typeWriter.StopTyping();
        info.gameObject.SetActive(false);
        skip.gameObject.SetActive(false);
        tutor.SetActive(false);
        cloud.SetActive(false);
    }
}
