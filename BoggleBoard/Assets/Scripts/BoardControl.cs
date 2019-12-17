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

    //list of all Possible words
    List<string> possibleWords;
    //list of all input words
    List<string> inputWords;

    #endregion

    void Start()
    {
        BoggleTxt.text = "";
        //BoggleTxt.text = BoogleLogic.
        possibleWords = BoogleLogic.Instance.GetAllPossibleWords();
        foreach(string word in possibleWords)
        {
            BoggleTxt.text += " -   " + word + "\n";
        }
    }

    #region Helper Methods

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
        
    }

    /// <summary>
    /// Interpolates smoothly to a target position.
    /// </summary>
    /// <param name="start">The starting position.</param>
    /// <param name="target">The destination position.</param>
    /// <param name="deltaTime">Caller-provided Time.deltaTime.</param>
    /// <param name="speed">The speed to apply to the interpolation.</param>
    /// <returns>New interpolated position closer to target</returns>
    public static Vector3 NonLinearInterpolateTo(Vector3 start, Vector3 target, float deltaTime, float speed)
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

    public void AddInputWords(string inputWord)
    {
        inputWords.Add(inputWord);
    }

    /// <summary>
    /// Function to Exit Game
    /// </summary>
    public void ExitGame()
    {
        Application.Quit();
    }

    #endregion
}
