using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYER1TURN, PLAYER2TURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{

	public GameObject playerPrefab;
	public GameObject enemyPrefab;

	public GridManager gridManager;

	

	Unit player1Unit;
	Unit player2Unit;

	public Text dialogueText;

	public BattleHUD player1HUD;
	public BattleHUD player2HUD;

	Button attButton;
	Button defButton;
	Button p2AttButton;
	Button p2DefButton;






	GameObject p1HUD;
	public BattleState state;

    // Start is called before the first frame update
    void Start()
    {

		



		state = BattleState.START;
		StartCoroutine(SetupBattle());
		
	}

    
     
		
    

    IEnumerator SetupBattle()
	{
		var spawnedPlayerOne = Instantiate(playerPrefab, new Vector3(0, 4, -1), Quaternion.identity);
		spawnedPlayerOne.name = $"Player One";
		player1Unit = spawnedPlayerOne.GetComponent<Unit>();

		var spawnedPlayerTwo = Instantiate(enemyPrefab, new Vector3(11, 4, -1), Quaternion.identity);
		spawnedPlayerTwo.name = $"Player Two";
		player2Unit = spawnedPlayerTwo.GetComponent<Unit>();


		yield return new WaitForSeconds(0.5f);


		player1HUD = GameObject.FindGameObjectWithTag("P1BattleHud").GetComponent<BattleHUD>();
		player2HUD = GameObject.FindGameObjectWithTag("P2BattleHud").GetComponent<BattleHUD>();
		player1HUD.SetHUD(player1Unit);
		player2HUD.SetHUD(player2Unit);


		attButton = GameObject.FindGameObjectWithTag("attButton").GetComponent<Button>();
		attButton.onClick.AddListener(OnAttackButton);
		defButton = GameObject.FindGameObjectWithTag("defButton").GetComponent<Button>();
		defButton.onClick.AddListener(OnHealButton);

		p2AttButton = GameObject.FindGameObjectWithTag("p2AttButton").GetComponent<Button>();
		p2AttButton.onClick.AddListener(OnAttackP2Button);

		p2DefButton = GameObject.FindGameObjectWithTag("p2DefButton").GetComponent<Button>();
		p2DefButton.onClick.AddListener(OnHealP2Button);


		player2HUD.SetHUD(player2Unit);


		yield return new WaitForSeconds(2f);

		state = BattleState.PLAYER1TURN;
		Player1Turn();
	}
	void Player1Turn()
	{
		Debug.Log("Player 1's turn");
	}
	IEnumerator Player1Attack()
	{
		bool isP2Dead = player2Unit.TakeDamage(player1Unit.damage);

		player2HUD.SetHP(player2Unit.currentHP);
		Debug.Log("attacked succesfully");

		yield return new WaitForSeconds(2f);

		if(isP2Dead)
		{
			state = BattleState.WON;
			EndBattle();
		} else
		{
			state = BattleState.PLAYER2TURN;
			Player2Turn();
		}
			
	}

	void Player2Turn()
	{
		Debug.Log("Player 2's turn");


		//yield return new WaitForSeconds(1f);

		//bool isDead = player1Unit.TakeDamage(player2Unit.damage);

		//player1HUD.SetHP(player1Unit.currentHP);

		//yield return new WaitForSeconds(1f);

		//if(isDead)
		//{
		//	state = BattleState.LOST;
		//	EndBattle();
		//} else
		//{
		//	state = BattleState.PLAYER1TURN;
		//	Player1Turn();
		//}

	}
	IEnumerator Player2Attack()
	{
		bool isDead = player2Unit.TakeDamage(player2Unit.damage);

		player1HUD.SetHP(player1Unit.currentHP);
		Debug.Log("attacked succesfully");

		yield return new WaitForSeconds(2f);

		if (isDead)
		{
			state = BattleState.WON;
			EndBattle();
		}
		else
		{
			state = BattleState.PLAYER2TURN;
			Player1Turn();
		}
	}


	void EndBattle()
	{
		if(state == BattleState.WON)
		{
			dialogueText.text = "You won the battle!";
		} else if (state == BattleState.LOST)
		{
			dialogueText.text = "You were defeated.";
		}
	}

	

	IEnumerator PlayerHeal()
	{
		player1Unit.Heal(5);

		player1HUD.SetHP(player1Unit.currentHP);
		dialogueText.text = "You feel renewed strength!";

		yield return new WaitForSeconds(2f);

		state = BattleState.PLAYER2TURN;
		Player2Turn();
	}
	IEnumerator Player2Heal()
	{
		player2Unit.Heal(5);

		player2HUD.SetHP(player2Unit.currentHP);
		Debug.Log("You feel restrenghtened");
		yield return new WaitForSeconds(2f);

		state = BattleState.PLAYER1TURN;
		Player1Turn();
	}

	public void OnAttackButton()
	{
		if (state != BattleState.PLAYER1TURN)
			return;

		StartCoroutine(Player1Attack());
	}

	public void OnHealButton()
	{
		if (state != BattleState.PLAYER1TURN)
			return;

		StartCoroutine(PlayerHeal());
	}

	public void OnAttackP2Button()
	{
		if (state != BattleState.PLAYER2TURN)
			return;

		StartCoroutine(Player1Attack());
	}

	public void OnHealP2Button()
	{
		if (state != BattleState.PLAYER2TURN)
			return;

		StartCoroutine(PlayerHeal());
	}

}
