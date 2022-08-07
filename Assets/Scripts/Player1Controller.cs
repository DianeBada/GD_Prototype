using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{
    [SerializeField]
    public float playerHealth = 50;
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
    bool closeToWeapon;

    public Player1Controller player1Controller;

    public Player2Health player2Health;
    public Player1Health player1Health;

    float minDist = 1;
    float dist;
    float weaponDist;
    float weaponMinDist = 0;

    GameObject weaponPlaceholder;


    // Start is called before the first frame update
    void Start()
    {

    }

    public void p1Attack()
    {
        if (player2Health.currentHealth > 0)
        {
            player2Health.TakeDamage(attValue);
        }
        //if (playerHealth.currentHealth > 0)
        //{
        //    playerHealth.TakeDamage(attackDamage);
        //}
        // depending on the stat or the item that is in hand.
        // so item picked changes the amount of damage done unto player
    }




    public void p1Defense()
    {
        if (player2Health.currentHealth > 0)
        {

        }

    }

    public void p1TakeDamage()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (p1Turn == true)
        //dist = Vector2.Distance(player1.transform.position, player2.transform.position);
        //    if (dist <= minDist)

        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    p1Attack();
        //}
        if (player2.transform.position == gameObject.transform.position)
        {
            player2.SetActive(false);
            Debug.Log("same position");
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("attacking player");
                p1Attack();
            }
            attValue = attackValue;
            defValue = defenseValue;

        }

    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "attackWeapon")

        {
            Debug.Log("I just collided with this " + col);
            // retrieve the attack points and add it to the attackStat
            // set the new attackvalue to the attackValue of the weapon
        }
         if (col.gameObject.tag == "defenseWeapon")
        {
            if (player1Health.currentHealth > 0)
            {
                player1Health.AddHealth(defValue);
            }
            // retrieve the defense points and add it to the defenseStat
            // set the new defensevalue to the defenseackValue of the weapon
        }
        if(col.gameObject.tag == "player2")
        {
            Debug.Log("next to player2" + col);
           
                   

            





        }
    }

    void CloseToWeapon()
    {

        //if (p1Turn == true)
       
            if(player1.transform.position == GameObject.FindGameObjectWithTag("attackWeapon").transform.position)
            {
                closeToWeapon = true;
                //GameObject.FindGameObjectWithTag("attackWeapon").SetActive(false);
                Debug.Log("I just collided with this ");


            if (Input.GetKeyDown(KeyCode.E))
            {
                p1Attack();
            }
        }
    }

    

}

