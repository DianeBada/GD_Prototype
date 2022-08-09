using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

	public string unitName;
	[SerializeField]
	public int damage;
	public static int damagePH;

	public int maxHP;
	public int currentHP;

	public int healAmm;

     void Start()
    {

    }
    void Update()
    {
    }
    public bool TakeDamage(int dmg)
	{
		currentHP -= dmg;

		if (currentHP <= 0)
			return true;
		else
			return false;
	}

	public void Heal(int amount)
	{
		currentHP += amount;
		if (currentHP > maxHP)
			currentHP = maxHP;
	}

}
