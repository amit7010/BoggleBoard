using BoogleBoard.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCheckZoneScript : Singleton<DiceCheckZoneScript>
{
    List<DiceScript> dies;
    char[,] word;
    int Row = 3;
    int Column = 3;
    bool UpdateDone = false;
    public bool diesSettled = false;

    private void Start()
    {
        dies = DiceControl.Instance.GetDies();
        word = new char[Row,Column];
    }

    private void Update()
    {
        UpdateDebugBox();
    }

    private void UpdateDebugBox()
    {
        foreach(DiceScript die in dies)
        {
            word[die.posX, die.posY] = die.CurrentText;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!UpdateDone)
        {
            switch (other.gameObject.name)
            {
                case "Side1":
                    other.gameObject.GetComponent<DieSide>().respectiveDice.GetCharacter("Side1");
                    break;
                case "Side2":
                    other.gameObject.GetComponent<DieSide>().respectiveDice.GetCharacter("Side2");
                    break;
                case "Side3":
                    other.gameObject.GetComponent<DieSide>().respectiveDice.GetCharacter("Side3");
                    break;
                case "Side4":
                    other.gameObject.GetComponent<DieSide>().respectiveDice.GetCharacter("Side4");
                    break;
                case "Side5":
                    other.gameObject.GetComponent<DieSide>().respectiveDice.GetCharacter("Side5");
                    break;
                case "Side6":
                    other.gameObject.GetComponent<DieSide>().respectiveDice.GetCharacter("Side6");
                    break;
            }
            FillWords.Instance.FillWord(word);

        }
    }

}
