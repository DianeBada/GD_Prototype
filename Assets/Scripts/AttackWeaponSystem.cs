using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackWeaponSystem : MonoBehaviour
{
    public int damage =10;
    Renderer rend;
     BattleSystem battleSystem;


     void Awake()
    {
        battleSystem = GameObject.Find("Game Manager").GetComponent<BattleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "player1")
        {
            gameObject.SetActive(false);
            // add this value in the attackValue of player1
            //Unit.damagePH = damage;
            battleSystem.player1Unit.damage += damage;

            Debug.Log("damage value"+battleSystem.player1Unit.damage);

        }
        else if (col.gameObject.tag == "player2")
        {
            gameObject.SetActive(false);

            //Player2Controller.attackValue = attackValue;
            Debug.Log(Player2Controller.attackValue);


            // add this value in the attackValue of player1

        }
    }
}




