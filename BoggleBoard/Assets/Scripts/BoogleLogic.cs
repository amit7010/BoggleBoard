using BoogleBoard.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoogleLogic : Singleton<BoogleLogic>
{
    /// <summary>
    /// Function to get All words possible 
    /// </summary>
    /// <returns></returns>
    private string[] GetDictionary()
    {
        string[] dictionary = { "bred", "yore", "abed","oread", "bore", "orby", "robed", "broad", "byroad", "robe", "bored", "derby", "bade", "aero"
        , "read", "orbed", "verb", "aery", "bead", "bread", "very", "road", "robbed", "robber", "board", "dove"};
        
        return dictionary;
    }

    /// <summary>
    /// Main Function to match words from dictionary
    /// Used DFS Algorithm
    /// </summary>
    /// <param name="words"></param>
    void MatchWordsDFS(char[,]  words, int[] dimensions)
    {
        int m = dimensions[0];
        int n = dimensions[1];
        bool[,] visitedLetters = new bool[m,n];
        
        // Initialize current string 
        string str = "";

        for(int i=0;i<m;i++)
            for(int j=0;j<n;j++)
            {
                MatchWordsDFSUtil(words, visitedLetters, m, n, out str);
            }
    }

    private void MatchWordsDFSUtil(char[,] words, bool[,] visitedLetters, int m, int n, out string str)
    {
        str = "";

        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
            {
                str += words[i,j];

                if (str.Length > 3)
                    CheckWordInDictionary(str);


            }
    }

    private bool CheckWordInDictionary(string str)
    {
        string[] dictionary = GetDictionary();
        for (int i = 0; i < dictionary.Length; i++)
            if (str.Equals(dictionary[i]))
                return true;

        return false;
    }
}
