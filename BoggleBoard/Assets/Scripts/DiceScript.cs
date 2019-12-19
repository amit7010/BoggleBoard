using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DiceScript : MonoBehaviour
{
    Rigidbody rb;
    public Vector3 diceVelocity = new Vector3(1f,1f,1f);
    [Header("Physics")]
    public bool startRolling = false;
    [SerializeField]
    private float DiceForce = 500;
    [SerializeField]
    public int posX;
    [SerializeField]
    public int posY;

    [Header("Sides")]
    public TextMeshPro Side1OppS3;
    public TextMeshPro Side2OppS4;
    public TextMeshPro Side3OppS1;
    public TextMeshPro Side4OppS2;
    public TextMeshPro Side5OppS6;
    public TextMeshPro Side6OppS5;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        diceVelocity = rb.velocity;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || startRolling)
        {
            float dirX = Random.Range(-500, 2000);
            float dirY = Random.Range(-500, 2000);
            float dirZ = Random.Range(-500, 2000);
            //transform.position = new Vector3(0, 2, 0);
            //transform.rotation = Quaternion.identity;
            rb.AddForce(transform.up * (DiceForce+DiceForce));
            rb.AddTorque(dirX, dirY, dirZ);
            startRolling = false;
        }
    }

    public char GetCharacter(string side)
    {
        if (side == "Side1")
            return Side1OppS3.text[0];
        else if (side == "Side2")
            return Side2OppS4.text[0];
        else if (side == "Side3")
            return Side3OppS1.text[0];
        else if (side == "Side4")
            return Side4OppS2.text[0];
        else if (side == "Side5")
            return Side5OppS6.text[0];
        else 
            return Side6OppS5.text[0];
    }

    public void PutCharacter(char[] ch)
    {
        Side1OppS3.text = ch[0].ToString().ToUpper().Trim();
        Side2OppS4.text = ch[0].ToString().ToUpper().Trim();
        Side3OppS1.text = ch[0].ToString().ToUpper().Trim();
        Side4OppS2.text = ch[0].ToString().ToUpper().Trim();
        Side5OppS6.text = ch[0].ToString().ToUpper().Trim();
        Side6OppS5.text = ch[0].ToString().ToUpper().Trim();
    }
}
