using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoogleBoard.Utility
{
    public class Trie
    {
        protected readonly int SIZE = 26;
        public int Row { get; set; }
        public int Column { get; set; }
        List<string> finalWords;

        public Trie[] Child;

        public bool isLeaf { get; set; }

        public Trie()
        {
            isLeaf = false;

            Child = new Trie[SIZE];
            finalWords = new List<string>();

            for(int i=0;i<SIZE;i++)
            {
                Child[i] = null;
            }
        }

        public bool Insert(Trie root,string word)
        {
            bool isInserted = false;

            Trie Node = root;

            for(int i =0; i<word.Length; i++)
            {
                int index = word[i] - 'A';
                if (Node.Child[index] == null)
                {
                    Node.Child[index] = new Trie();
                }
                Node = Node.Child[index];
            }
            isInserted = true;
            Node.isLeaf = true;
            
            return isInserted;
        }

        bool isSafe(int i, int j, bool[,] visited)
        {
            return (i >= 0 && i < Row && j >= 0 &&
                    j < Column && !visited[i, j]);
        }

        // A recursive function to print all words present on boggle  
        public void SearchWordRecursively(Trie root, char[,] boggle, int i,
                        int j, bool[,] visited, string str)
        {
            // if we found word in trie / dictionary  
            if (root.isLeaf == true)
                finalWords.Add(str.Trim());

            // If both I and j in range and we visited  
            // that element of matrix first time  
            if (isSafe(i, j, visited))
            {
                // make it visited  
                visited[i, j] = true;

                // traverse all child of current root  
                for (int K = 0; K < SIZE; K++)
                {
                    if (root.Child[K] != null)
                    {
                        // current character  
                        char ch = (char)(K + 'A');

                        // Recursively search reaming character of word  
                        // in trie for all 8 adjacent cells of  
                        // boggle[i,j]  
                        if (isSafe(i + 1, j + 1, visited) &&
                                    boggle[i + 1, j + 1] == ch)
                            SearchWordRecursively(root.Child[K], boggle, i + 1, j + 1,
                                                    visited, str + ch);
                        if (isSafe(i, j + 1, visited) &&
                            boggle[i, j + 1] == ch)
                            SearchWordRecursively(root.Child[K], boggle, i, j + 1,
                                                    visited, str + ch);
                        if (isSafe(i - 1, j + 1, visited) &&
                           boggle[i - 1, j + 1] == ch)
                            SearchWordRecursively(root.Child[K], boggle, i - 1, j + 1,
                                                    visited, str + ch);
                        if (isSafe(i + 1, j, visited) &&
                            boggle[i + 1, j] == ch)
                            SearchWordRecursively(root.Child[K], boggle, i + 1, j,
                                                    visited, str + ch);
                        if (isSafe(i + 1, j - 1, visited) &&
                            boggle[i + 1, j - 1] == ch)
                            SearchWordRecursively(root.Child[K], boggle, i + 1, j - 1,
                                                    visited, str + ch);
                        if (isSafe(i, j - 1, visited) &&
                            boggle[i, j - 1] == ch)
                            SearchWordRecursively(root.Child[K], boggle, i, j - 1,
                                                    visited, str + ch);
                        if (isSafe(i - 1, j - 1, visited) &&
                            boggle[i - 1, j - 1] == ch)
                            SearchWordRecursively(root.Child[K], boggle, i - 1, j - 1,
                                                    visited, str + ch);
                        if (isSafe(i - 1, j, visited) &&
                            boggle[i - 1, j] == ch)
                            SearchWordRecursively(root.Child[K], boggle, i - 1, j,
                                                visited, str + ch);
                    }
                }

                // make current element unvisited  
                visited[i, j] = false;
            }
        }

        public List<string> GetFoundWords()
        {
            return finalWords;
        }
    }
}
