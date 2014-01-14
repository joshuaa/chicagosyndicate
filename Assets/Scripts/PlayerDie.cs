using UnityEngine;
using System.Collections;

public class PlayerDie : MonoBehaviour 
{
	private Controller controller;
	private Collider otherThing;
	private PlayerSlot playerSlot;
	private GameController gameController;

	void Start()
	{
		GameObject gc = GameObject.FindWithTag("GameController");
		gameController = gc.GetComponent<GameController>();

		controller = GetComponent<Controller>();
		playerSlot = GetComponent<PlayerSlot>();
	}

	void OnTriggerEnter(Collider other)
	{
		//if it collides with bullet, log who killed who, take 1 away from playerCount (for camera), destroy crosshair if it's player1, destroy player
		otherThing = other;
		if(otherThing.gameObject.tag == "p1bullet")
			Debug.Log("Player1 killed " + gameObject.tag);

		if(otherThing.gameObject.tag == "p2bullet")
			Debug.Log("Player2 killed " + gameObject.tag);

		if(otherThing.gameObject.tag == "p3bullet")
			Debug.Log("Player3 killed " + gameObject.tag);

		if(otherThing.gameObject.tag == "p4bullet")
			Debug.Log("Player4 killed " + gameObject.tag);

		if(playerSlot.playerSlot == 1 && (otherThing.gameObject.tag == "p2bullet" || otherThing.gameObject.tag == "p3bullet" || otherThing.gameObject.tag == "p4bullet"))
		{
			gameController.playerCount -= 1;
			if(controller.crosshair != null)
				Destroy(controller.crosshair);
			Destroy(gameObject);
		}
		if(playerSlot.playerSlot == 2 && (otherThing.gameObject.tag == "p1bullet" || otherThing.gameObject.tag == "p3bullet" || otherThing.gameObject.tag == "p4bullet"))
		{
			gameController.playerCount -= 1;
			Destroy(gameObject);
		}
		if(playerSlot.playerSlot == 3 && (otherThing.gameObject.tag == "p1bullet" || otherThing.gameObject.tag == "p2bullet" || otherThing.gameObject.tag == "p4bullet"))
		{
			gameController.playerCount -= 1;
			Destroy(gameObject);
		}
		if(playerSlot.playerSlot == 4 && (otherThing.gameObject.tag == "p1bullet" || otherThing.gameObject.tag == "p2bullet" || otherThing.gameObject.tag == "p3bullet"))
		{
			gameController.playerCount -= 1;
			Destroy(gameObject);
		}
	}
}