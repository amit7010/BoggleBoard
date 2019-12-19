using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoardControl : MonoBehaviour
{
    #region Varianbles
    [SerializeField]
    TextMeshProUGUI BoggleTxt;
    [SerializeField]
    GameObject WelcomePanel;
    [SerializeField]
    GameObject PlayPanel;
    [SerializeField]
    GameObject GameOverPanel;
    [SerializeField]
    GameObject TextPrefab;
    [SerializeField]
    GameObject ErrorTextPrefab;
    [SerializeField]
    float timeLeft = 2f;
    [Header("Text Fields")]
    [SerializeField]
    TMP_InputField userInputField;
    [SerializeField]
    TextMeshProUGUI MatchedWordNumber;
    [SerializeField]
    TextMeshProUGUI ScoreTxt;
    [SerializeField]
    TextMeshPro timeLeftTxt;

    [Header("Scripts")]
    [SerializeField]
    ScrollContentControl scrollMenu;
    //list of all Possible words
    List<string> possibleWords;
    //list of all input words
    List<string> inputWords;

    bool UpdatePending = false;
    bool ClockTicking = false;
    BoogleLogic Instance;

    #endregion

    void Start()
    {
        InvokeRepeating("ControlTimer", 1f, 1f);

        Instance = new BoogleLogic();
        //For Testing
        BoggleTxt.text = "";

        //BoggleTxt.text = BoogleLogic.
        possibleWords = Instance.GetAllPossibleWords();
        inputWords = new List<string>();
        foreach(string word in possibleWords)
        {
            BoggleTxt.text += " -   " + word + "\n";
        }
        timeLeftTxt.text = "" + timeLeft;
    }

    //private void Update()
    //{
        
    //}

    #region Helper Methods
    
    /// <summary>
    /// Function to Control timer of the Game
    /// </summary>
    private void ControlTimer()
    {
        if(timeLeft <=0 && !ClockTicking )
        {
            GameOver();
            //CancelInvoke("ControlTimer");
        }
        else if(ClockTicking)
        {
            timeLeftTxt.text = "" + timeLeft;
            timeLeft--;
            if (timeLeft <= 0)
                ClockTicking = !ClockTicking;
        }
    }

    /// <summary>
    /// Function to Initiate Game
    /// </summary>
    public void InitGame()
    {
        //0. Disable Welcome canvas Panels
        WelcomePanel.SetActive(false);
        //1. Enable PlayScreen canvas Panel
        PlayPanel.SetActive(true);
        //2.1. Non-Linear Interpolate Camera for better View

        //2.2. Roll Dies
        StartCoroutine(DiceControl.Instance.RollDies());
        //2.3 Start Clock Ticking
        ClockTicking = true;
    }

    /// <summary>
    /// Function to show User Input words
    /// </summary>
    public void ShowUserWords()
    {
        string userWord = userInputField.textComponent.text;
        if(userWord.Length > 0)
        {
            if(AddInputWords(userWord))
                scrollMenu.FillList(inputWords);
        }
    }

    /// <summary>
    /// Function called When the Game is Over
    /// </summary>
    public void GameOver()
    {
        //Stop Game
        Time.timeScale = 0f;

        PlayPanel.SetActive(false);

        GameOverPanel.SetActive(true);

        //Calculate Score
        CalculateScore();
    }

    /// <summary>
    /// Calculates scores and Matched words
    /// </summary>
    void CalculateScore()
    {
        //Counts matched Words
        int count = 0;
        //Total Score
        int Score = 0;
        foreach(string word in inputWords)
        {
            if(Instance.findWord(word))
            {
                count++;
                Score += 5;
            }
            else
            {
                Score -= 2;
            }
        }

        MatchedWordNumber.text = "" + count;
        ScoreTxt.text = "" + Score;
    }

    /// <summary>
    /// Function to Exit Game
    /// </summary>
    public void ExitGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// Interpolates smoothly to a target position.
    /// </summary>
    /// <param name="start">The starting position.</param>
    /// <param name="target">The destination position.</param>
    /// <param name="deltaTime">Caller-provided Time.deltaTime.</param>
    /// <param name="speed">The speed to apply to the interpolation.</param>
    /// <returns>New interpolated position closer to target</returns>
    private static Vector3 NonLinearInterpolateTo(Vector3 start, Vector3 target, float deltaTime, float speed)
    {
        // If no interpolation speed, jump to target value.
        if (speed <= 0.0f)
        {
            return target;
        }

        Vector3 distance = (target - start);

        // When close enough, jump to the target
        if (distance.sqrMagnitude <= Mathf.Epsilon)
        {
            return target;
        }



        // Apply the delta, then clamp so we don't overshoot the target
        Vector3 deltaMove = distance * Mathf.Clamp(deltaTime * speed, 0.0f, 1.0f);



        return start + deltaMove;
    }

    /// <summary>
    /// Add words to Input Words by User
    /// </summary>
    /// <param name="inputWord"></param>
    private bool AddInputWords(string inputWord)
    {
        string wordToAdd = inputWord.ToUpper().Trim();
        if (!CheckUserInputDuplicate(wordToAdd))
        {
            StartCoroutine(ErrorPopUp());
            return false;
        }
        else
        {
            inputWords.Add(wordToAdd);
            return true;
        }
    }

    /// <summary>
    /// Function to show Error PopUP
    /// </summary>
    /// <returns></returns>
    private IEnumerator ErrorPopUp()
    {
        GameObject ErrorGO = Instantiate(ErrorTextPrefab, transform);
        TextMeshProUGUI text = ErrorGO.GetComponent<TextMeshProUGUI>();
        text.text = "Error:\nWord Already  Existe";
        yield return new WaitForSeconds(4f);
        DestroyImmediate(ErrorGO);
        yield return null;
    }

    /// <summary>
    /// Function to check Duplicates in User 
    /// </summary>
    /// <param name="inputWord"></param>
    /// <returns></returns>
    private bool CheckUserInputDuplicate(string inputWord)
    {
        if (inputWords.Contains(inputWord))
            return false;
        return true;
    }

    #endregion
}
