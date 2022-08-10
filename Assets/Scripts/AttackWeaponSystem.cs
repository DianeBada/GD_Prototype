using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AttackWeaponSystem : MonoBehaviour
{
    public int damage =10;
    Renderer rend;
     BattleSystem battleSystem;
    TextMeshProUGUI player1AStat;
    TextMeshProUGUI player2AStat;


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

            battleSystem.player2Unit.damage += damage;

            Debug.Log("damage value" + battleSystem.player2Unit.damage);



            // add this value in the attackValue of player1

        }
    }

     void Update()
    {
        //player1AStat = GameObject.Find("AttackStat").GetComponent<TextMeshProUGUI>();
        //player2AStat = GameObject.Find("AttackStat(2)").GetComponent<TextMeshProUGUI>();
        //player1AStat.text = battleSystem.player1Unit.damage.ToString();
        //player2AStat.text = battleSystem.player2Unit.damage.ToString();
    }
}




