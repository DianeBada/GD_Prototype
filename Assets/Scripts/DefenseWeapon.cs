using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DefenseWeapon : MonoBehaviour
{
    public int defenseValue = 5;

    TextMeshProUGUI player1DStat;
    TextMeshProUGUI player2DStat;


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
            // add this value in the attackValue of player1
            //Unit.damagePH = damage;
            battleSystem.player1Unit.healAmm += defenseValue;

            Debug.Log("damage value" + battleSystem.player1Unit.healAmm);

        }
        if (col.gameObject.tag == "player2")
        {
            gameObject.SetActive(false);

            // add this value in the attackValue of player1

            battleSystem.player1Unit.healAmm += defenseValue;

            Debug.Log("damage value" + battleSystem.player2Unit.healAmm);




        }

    }

     void Update()
    {
        //player1DStat = GameObject.Find("DefStat").GetComponent<TextMeshProUGUI>();
        //player2DStat = GameObject.Find("DefStat2").GetComponent<TextMeshProUGUI>();
        //player1DStat.text = battleSystem.player1Unit.healAmm.ToString();
        //player2DStat.text = battleSystem.player2Unit.healAmm.ToString();
    }
}
