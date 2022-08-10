using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public enum BattleState { START, PLAYER1TURN, PLAYER2TURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{

	public GameObject playerPrefab;
	public GameObject enemyPrefab;

	public GridManager gridManager;

	bool p1Turn;
	bool p2Turn;

	public GameObject p1TurnPic;
	public GameObject p2TurnPic;

	public GameObject p1WaitPic;
	public GameObject p2WaitPic;


	TextMeshProUGUI player1AStat;
	TextMeshProUGUI player2AStat;
	TextMeshProUGUI player1DStat;
	TextMeshProUGUI player2DStat;




	public Unit player1Unit;
	public Unit player2Unit;

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
    void Awake()
    {

		



		state = BattleState.START;
		StartCoroutine(SetupBattle());
		
	}


	void Update()
	{
		if(p1Turn == true)
        {
			p1TurnPic.SetActive(true);
			p2WaitPic.SetActive(true);

			p1WaitPic.SetActive(false);
			p2TurnPic.SetActive(false);
        }
         else if(p2Turn == true)
        {
			p2TurnPic.SetActive(true);
			p1WaitPic.SetActive(true);

			p1TurnPic.SetActive(false);
			p2WaitPic.SetActive(false);
        }

		player1AStat = GameObject.Find("AttackStat").GetComponent<TextMeshProUGUI>();
		player2AStat = GameObject.Find("AttackStat(2)").GetComponent<TextMeshProUGUI>();
		player1AStat.text = player1Unit.damage.ToString();
		player2AStat.text = player2Unit.damage.ToString();

		player1DStat = GameObject.Find("DefStat").GetComponent<TextMeshProUGUI>();
		player2DStat = GameObject.Find("DefStat2").GetComponent<TextMeshProUGUI>();
		player1DStat.text = player1Unit.healAmm.ToString();
		player2DStat.text = player2Unit.healAmm.ToString();


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




		yield return new WaitForSeconds(2f);

		state = BattleState.PLAYER1TURN;
		Player1Turn();
	}
	void Player1Turn()
	{
		Debug.Log("Player 1's turn");
		p1Turn = true;
		p2Turn = false;
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
		p1Turn = false;
		p2Turn = true;


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
		bool isp1Dead = player1Unit.TakeDamage(player2Unit.damage);

		player1HUD.SetHP(player1Unit.currentHP);
		Debug.Log("attacked succesfully");

		yield return new WaitForSeconds(2f);

		if (isp1Dead)
		{
			state = BattleState.WON;
			EndBattle();
		}
		else
		{
			state = BattleState.PLAYER1TURN;
			Player1Turn();
		}
	}


	void EndBattle()
	{
		bool player1Dead = player1Unit.TakeDamage(player2Unit.damage);
		bool player2Dead = player2Unit.TakeDamage(player1Unit.damage);
		if (state == BattleState.WON && player1Dead) 
		{
			SceneManager.LoadScene("GameOver");
			Debug.Log("You win!");
		} else if (state == BattleState.WON && player2Dead)
		{
			SceneManager.LoadScene("GameOver");
			Debug.Log("You lose");
		}
	}

	

	IEnumerator PlayerHeal()
	{
		player1Unit.Heal(player1Unit.healAmm);

		player1HUD.SetHP(player1Unit.currentHP);
		Debug.Log("You feel renewed");

		yield return new WaitForSeconds(2f);

		state = BattleState.PLAYER2TURN;
		Player2Turn();
	}
	IEnumerator Player2Heal()
	{
		player2Unit.Heal(player2Unit.healAmm);

		player2HUD.SetHP(player2Unit.currentHP);
		Debug.Log("You feel renewed");

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

		StartCoroutine(Player2Attack());
	}

	public void OnHealP2Button()
	{
		if (state != BattleState.PLAYER2TURN)
			return;

		StartCoroutine(Player2Heal());
	}

}
