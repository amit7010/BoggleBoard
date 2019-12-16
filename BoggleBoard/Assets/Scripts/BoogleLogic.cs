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


    private bool CheckWordInDictionary()
    {
        int Row = 3;
        int Column = 3;
        Trie TrieNode = new Trie();

        TrieNode.Row = Row;
        TrieNode.Column = Column;

        string[] dictionary = GetDictionary();

        char[,] word = {{ 'Y', 'O', 'X' }, { 'R','B','A'},{'V','E','D' } };
        findWords(word, TrieNode, Row, Column);
        return true;

    }

    void findWords(char[,] boggle, Trie root, int Rows,int Columns)
    {
        // Mark all characters as not visited  
        bool[,] visited = new bool[Rows, Columns];
        Trie pChild = root;

        String str = "";

        // traverse all matrix elements  
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                // we start searching for word in dictionary  
                // if we found a character which is child  
                // of Trie root  
                if (pChild.Child[(boggle[i, j]) - 'A'] != null)
                {
                    str = str + boggle[i, j];
                    root.SearchWordRecursively(pChild.Child[(boggle[i, j]) - 'A'],
                            boggle, i, j, visited, str);
                    str = "";
                }
            }
        }
    }

    #region Not In Use
    /// <summary>
    /// Main Function to match words from dictionary
    /// Used DFS Algorithm
    /// </summary>
    /// <param name="words"></param>
    //void MatchWordsDFS(char[,] words, int[] dimensions)
    //{
    //    int m = dimensions[0];
    //    int n = dimensions[1];
    //    bool[,] visitedLetters = new bool[m, n];

    //    // Initialize current string 
    //    string str = "";

    //    for (int i = 0; i < m; i++)
    //        for (int j = 0; j < n; j++)
    //        {
    //            MatchWordsDFSUtil(words, visitedLetters, m, n, out str);
    //        }
    //}

    //private void MatchWordsDFSUtil(char[,] words, bool[,] visitedLetters, int m, int n, out string str)
    //{
    //    str = "";

    //    for (int i = 0; i < m; i++)
    //        for (int j = 0; j < n; j++)
    //        {
    //            str += words[i, j];

    //            if (str.Length > 3)
    //                CheckWordInDictionary(str);


    //        }
    //}

    #endregion
}
