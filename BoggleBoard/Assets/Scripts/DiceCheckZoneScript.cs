using BoogleBoard.Utility;
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

    private void OnTriggerStay(Collider other)
    {
        if(!UpdateDone && diesSettled)
        {
            for (int i = 0; i < dies.Count; i++)
            {
                if (dies[i].diceVelocity.x == 0f && dies[i].diceVelocity.y == 0f && dies[i].diceVelocity.z == 0f)
                {
                    switch (other.gameObject.name)
                    {
                        case "Side1":
                            word[dies[i].posX,dies[i].posY] = (dies[i].GetCharacter("Side1"));
                            break;
                        case "Side2":
                            word[dies[i].posX, dies[i].posY] = (dies[i].GetCharacter("Side2"));
                            break;
                        case "Side3":
                            word[dies[i].posX, dies[i].posY] = (dies[i].GetCharacter("Side3"));
                            break;
                        case "Side4":
                            word[dies[i].posX, dies[i].posY] = (dies[i].GetCharacter("Side4"));
                            break;
                        case "Side5":
                            word[dies[i].posX, dies[i].posY] = (dies[i].GetCharacter("Side5"));
                            break;
                        case "Side6":
                            word[dies[i].posX, dies[i].posY] = (dies[i].GetCharacter("Side6"));
                            break;
                    }
                }
            }
            

        }
    }
    
}
