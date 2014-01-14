using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour 
{
	private Animator animator;
	public string character = "Thug";
	public int color = 1;

	void Start()
	{
		animator = GetComponent<Animator>();
	}

	public void UpdateCharacter()
	{
		if(character == "Thug")
		{
			if(color == 1)
				animator.frameY = 6;
			if(color == 2)
				animator.frameY = 7;
		}
		if(character == "Mafia")
		{
			if(color == 1)
				animator.frameY = 2;
			if(color == 2)
				animator.frameY = 3;
		}
		if(character == "Spy")
		{
			if(color == 1)
				animator.frameY = 4;
			if(color == 2)
				animator.frameY = 5;
		}
		if(character == "Cop")
		{
			if(color == 1)
				animator.frameY = 6;
			if(color == 2)
				animator.frameY = 7;
		}
	}
}