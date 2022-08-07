using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackWeaponSystem : MonoBehaviour
{
    public float damage = 10;
    public float attackValue = 10;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "player1")
        {
            gameObject.SetActive(false);
            // add this value in the attackValue of player1
            Player1Controller.attackValue = attackValue;
            Debug.Log(Player1Controller.attackValue);

        }
        else if (col.gameObject.tag == "player2")
        {
            gameObject.SetActive(false);

            Player2Controller.attackValue = attackValue;
            Debug.Log(Player2Controller.attackValue);


            // add this value in the attackValue of player1

        }
    }
}




