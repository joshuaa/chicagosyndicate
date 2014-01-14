using UnityEngine;
using System.Collections;

public class PlayerSlot : MonoBehaviour 
{
	public int playerSlot;

	public void SetPlayerSlot()
	{
		//sets player number
		if(gameObject.tag == "Player1")
			playerSlot = 1;
		if(gameObject.tag == "Player2")
			playerSlot = 2;
		if(gameObject.tag == "Player3")
			playerSlot = 3;
		if(gameObject.tag == "Player4")
			playerSlot = 4;	
	}
}