using BoogleBoard.Utility;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FillWords : Singleton<FillWords>
{
    [SerializeField]
    TextMeshPro RC00;
    [SerializeField]
    TextMeshPro RC01;
    [SerializeField]
    TextMeshPro RC02;
    [SerializeField]
    TextMeshPro RC10;
    [SerializeField]
    TextMeshPro RC11;
    [SerializeField]
    TextMeshPro RC12;
    [SerializeField]
    TextMeshPro RC20;
    [SerializeField]
    TextMeshPro RC21;
    [SerializeField]
    TextMeshPro RC22;

    public void FillWord(char[,] word)
    {
        RC00.text = word[0,0].ToString();
        RC01.text = word[0,1].ToString();
        RC02.text = word[0,2].ToString();
        RC10.text = word[1,0].ToString();
        RC11.text = word[1,1].ToString();
        RC12.text = word[1,2].ToString();
        RC20.text = word[2,0].ToString();
        RC21.text = word[2,1].ToString();
        RC22.text = word[2,2].ToString();
    }

}
