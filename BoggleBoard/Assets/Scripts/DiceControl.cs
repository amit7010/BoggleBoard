using BoogleBoard.Utility;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DiceControl : Singleton<DiceControl>
{
    List<DiceScript> dies;
    // Start is called before the first frame update
    void Start()
    {
        dies = GetComponentsInChildren<DiceScript>().ToList();
    }

    public List<DiceScript> GetDies()
    {
        if (dies != null)
            return dies;
        else
            return null;
    }

    public IEnumerator RollDies()
    {
        foreach(DiceScript die in dies)
        {
            die.startRolling = true;
            yield return new WaitForSeconds(.02f);
        }
        DiceCheckZoneScript.Instance.diesSettled = true;

    }
}
