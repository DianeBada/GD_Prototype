using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseWeapon : MonoBehaviour
{
    public int defenseValue = 5;

    public BattleSystem battleSystem;

    void Awake()
    {
        battleSystem = GameObject.Find("Game Manager").GetComponent<BattleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "player1")
        {
            gameObject.SetActive(false);

            gameObject.SetActive(false);
            // add this value in the attackValue of player1
            //Unit.damagePH = damage;
            battleSystem.player1Unit.healAmm += defenseValue;

            Debug.Log("damage value" + battleSystem.player1Unit.healAmm);

        }
        if (col.gameObject.tag == "player2")
        {
            gameObject.SetActive(false);

            // add this value in the attackValue of player1
            Player2Controller.defenseValue = defenseValue;

            Debug.Log(Player2Controller.defenseValue);




        }
    }
}
