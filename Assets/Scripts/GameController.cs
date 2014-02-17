using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	public GUIText winnerText;
	public GUIText restartText;

	public GameObject player1;
	public GameObject player2;
	public GameObject player3;
	public GameObject player4;

	public int playerCount = 4;

	private bool slowMo = false;
	private bool paused = false;

	private string whoWon = "";

	void Start()
	{
		winnerText.text = "";
		restartText.text = "";

		player1 = GameObject.FindWithTag("Player1");
		player2 = GameObject.FindWithTag("Player2");
		player3 = GameObject.FindWithTag("Player3");
		player4 = GameObject.FindWithTag("Player4");
	}

	void Update()
	{
		Winner();
		SlowMo();
	}

	void Winner()
	{
		if(playerCount == 1)
		{
			if(player1 != null)
			{
				whoWon = "P1";
			}
			else if(player2 != null)
			{
				whoWon = "P2";
			}
			else if(player3 != null)
			{
				whoWon = "P3";
			}
			else
			{
				whoWon = "P4";
			}

			winnerText.color = Color.white;
			winnerText.text = whoWon + " IS THE WINNER!";
			restartText.text = "Press R for a rematch!";
			Time.timeScale = 0.1f;
			if(Input.GetKeyDown(KeyCode.R))
			{
				Time.timeScale = 1f;
				Application.LoadLevel(Application.loadedLevel);
				playerCount = 4;
			}
		}
	}

	void SlowMo()
	{
		if(Input.GetKeyDown(KeyCode.Space) && !slowMo && !paused)
		{
			slowMo = true;
			Time.timeScale = 0.2f;
		}
		else if(Input.GetKeyDown(KeyCode.Space) && slowMo && !paused)
		{	
			slowMo = false;
			Time.timeScale = 1f;
		}
	}
}