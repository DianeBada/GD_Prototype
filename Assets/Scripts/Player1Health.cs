using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Health : MonoBehaviour
{
    public float currentHealth;
    bool damaged;
    bool hasDefense;

    // Start is called before the first frame update
    void Awake()
    {
        currentHealth = 100;
    }
    public void TakeDamage(float damage)
    {
        damaged = true;

        currentHealth -= damage;


        //damage is reduced if player has defense value
        //healthSlider.value = currentHealth;
    }

    public void AddHealth(float defense)
    {
        hasDefense = true;
        currentHealth += defense;
    }





}
