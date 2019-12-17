using BoogleBoard.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoogleLogic : Singleton<BoogleLogic>
{
    List<string> PossibleWords;
    /// <summary>
    /// Function to get All words possible 
    /// </summary>
    /// <returns></returns>
    private string[] GetDictionary()
    {
        string[] dictionary = { "BRED", "YORE", "ABED","OREAD", "BORE", "ORBY", "ROBED", "BROAD", "BYROAD", "ROBE", "BORED", "DERBY", "BADE", "AERO"
        , "READ", "ORBED", "VERB", "AERY", "BEAD", "BREAD", "VERY", "ROAD", "ROBBED", "ROBBER", "BOARD", "DOVE"};
        
        return dictionary;
    }


    /// <summary>
    /// Function to find all possible words
    /// </summary>
    /// <returns></returns>
    public List<string> GetAllPossibleWords()
    {
        int Row = 3;
        int Column = 3;
        Trie TrieNode = new Trie();

        TrieNode.Row = Row;
        TrieNode.Column = Column;

        string[] dictionary = GetDictionary();
        for (int i = 0; i < dictionary.Length; i++)
        {
            dictionary[i] = dictionary[i].ToUpper();
            TrieNode.Insert(TrieNode, dictionary[i]);
        }

        char[,] word = {{ 'Y', 'O', 'X' }, { 'R','B','A'},{'V','E','D' } };

        return PossibleWords = findWords(word, TrieNode, Row, Column);
     
    }

    List<string> findWords(char[,] boggle, Trie root, int Rows,int Columns)
    {
        // Mark all characters as not visited  
        bool[,] visited = new bool[Rows, Columns];
        Trie pChild = root;

        string str = "";
        //IEnumerator target;
        List<string> foundWords;

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
                    //target = root.SearchWordRecursively(pChild.Child[(boggle[i, j]) - 'A'],
                    //        boggle, i, j, visited, str);

                    //while(target.MoveNext())
                    //{
                    //    str = target.Current.ToString();
                    //    if(str !="")
                    //    {
                    //        Debug.Log(str);
                    //    }
                    //}
                    root.SearchWordRecursively(pChild.Child[(boggle[i, j]) - 'A'],
                            boggle, i, j, visited, str);
                    str = "";
                }
            }
        }

        foundWords = root.GetFoundWords();
        return foundWords;
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
