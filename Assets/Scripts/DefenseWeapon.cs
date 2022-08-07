using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseWeapon : MonoBehaviour
{
    public float defense = 5;
    public float defenseValue = 5;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "player1")
        {
            // add this value in the attackValue of player1
            Player1Controller.defenseValue = defenseValue;
            Debug.Log(Player1Controller.defenseValue);

        }
        if (col.gameObject.tag == "player2")
        {
            // add this value in the attackValue of player1
            Player2Controller.defenseValue = defenseValue;
            Debug.Log(Player2Controller.defenseValue);




        }
    }
}
