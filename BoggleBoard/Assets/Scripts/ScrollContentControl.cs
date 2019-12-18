using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScrollContentControl : MonoBehaviour
{
    [SerializeField]
    GameObject WordPrefab;
    [SerializeField]
    GameObject Content;

    public void FillList(List<string> words)
    {
        if (words != null)
        {
            foreach (string word in words)
            {
                GameObject wordPrefab = Instantiate(WordPrefab, Content.transform);
                TextMeshProUGUI text = wordPrefab.GetComponent<TextMeshProUGUI>();
                text.text = "- " + word;
            }
        }
        
    }
    

}
