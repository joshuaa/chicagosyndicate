using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
	private GameObject gameController;
	public GameController gc;

	public float slide = 1;

	private float mx;
	private float my;

	private float p1x;
	private float p1y;
	private float p2x;
	private float p2y;
	private float p3x;
	private float p3y;
	private float p4x;
	private float p4y;

	void Start()
	{
		gameController = GameObject.FindWithTag("GameController");
		Screen.lockCursor = true;
	}

	void Update()
	{
		CheckAlivePlayers();

		float endX = (p1x + p2x + p3x + p4x)/gc.playerCount;
		float endY = (p1y + p2y + p3y + p4y)/gc.playerCount;

		mx += ((endX - mx)/slide)*Time.deltaTime;
		my += ((endY - my)/slide)*Time.deltaTime;

		transform.position = new Vector3(mx,transform.position.y,my);
	}

	void CheckAlivePlayers()
	{
		if(gc.player1 != null)
		{
			p1x = gc.player1.transform.position.x;
			p1y = gc.player1.transform.position.z;
		}
		else
		{
			p1x = 0;			
			p1y = 0;
		}
		if(gc.player2 != null)
		{
			p2x = gc.player2.transform.position.x;
			p2y = gc.player2.transform.position.z;
		}
		else
		{
			p2x = 0;
			p2y = 0;
		}
		if(gc.player3 != null)
		{
			p3x = gc.player3.transform.position.x;
			p3y = gc.player3.transform.position.z;
		}
		else
		{
			p3x = 0;
			p3y = 0;
		}
		if(gc.player4 != null)
		{
			p4x = gc.player4.transform.position.x;
			p4y = gc.player4.transform.position.z;
		}
		else
		{
			p4x = 0;
			p4y = 0;
		}
	}
}