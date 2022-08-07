using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    
    [SerializeField]
    public float attackStat = 10;
    [SerializeField]
    public float defenseStat = 10;


    public static float attackValue;
    public float attValue;

    public static float defenseValue = 5;
    public float defValue;

    public GameObject player1;
    public GameObject player2;
    public bool p1Turn = false;

    public Player2Controller player2Controller;

    public Player2Health player2Health;
    public Player1Health player1Health;

    float minDist = 1;
    float dist;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void p2Attack()
    {
        if (player1Health.currentHealth > 0)
        {
            player1Health.TakeDamage(attValue);
        }
        //if (playerHealth.currentHealth > 0)
        //{
        //    playerHealth.TakeDamage(attackDamage);
        //}
        // depending on the stat or the item that is in hand.
        // so item picked changes the amount of damage done unto player
    }

  
   



    // Update is called once per frame
    void Update()
    {
        //if (p1Turn == true)
        dist = Vector2.Distance(player2.transform.position, player1.transform.position);
        if (dist <= minDist)
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                p2Attack();
            }
        }
        attValue = attackValue;
        defValue = defenseValue;

    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "attackWeapon")

        {
            Debug.Log("I just collided with this " + col);
            // retrieve the attack points and add it to the attackStat
            // set the new attackvalue to the attackValue of the weapon
        }
       else if (col.gameObject.tag == "defenseWeapon")
        {
            if (player2Health.currentHealth > 0)
            {
                Debug.Log("Adding health to player2");

                player2Health.AddHealth(defValue);
            }
            // retrieve the defense points and add it to the defenseStat
            // set the new defensevalue to the defenseackValue of the weapon
        }
    }


}
