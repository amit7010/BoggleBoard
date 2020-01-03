using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieSide : MonoBehaviour
{
    public DiceScript respectiveDice;

    private void Awake()
    {
        respectiveDice = GetComponentInParent<DiceScript>();
    }
}
