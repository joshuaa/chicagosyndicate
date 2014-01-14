using UnityEngine;
using System.Collections;

public class Animator : MonoBehaviour 
{
	public GameObject spriteQuad;
	private PlayerSlot ps;
	private Weapon weapon;

	private int frameNum = 0;

	private float frameX;
	private float frameY;
	private float totalframesX;
	private float totalframesY;
	private float nextFrame = 0;
	private float frameRate;

	private string animation = "idle";

	private bool inverse = false;

	void Start()
	{
		ps = GetComponent<PlayerSlot>();
		weapon = GetComponent<Weapon>();

		frameX = 1;
		frameY = ps.playerSlot + 2;
		frameNum = 1;
		totalframesX = 16;
		totalframesY = 8;
	}

	public void UpdateAnimationName()
	{
		//if not moving, make it idle. if it is moving and not shooting, make it moving. if it is shooting, make it firing.
		if(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0 && !Input.GetButton("Fire1"))
			animation = "idle";
		else if(!Input.GetButton("Fire1"))
			animation = "moving";
		else
			animation = "firing";
	}

	public void Animate()
	{
		float x = frameX/totalframesX;
		float y = frameY/totalframesY;

		spriteQuad.renderer.material.mainTextureOffset = new Vector2(x,y);

		if(ps.playerSlot == 1)
		{
			if(weapon.weaponName == "thompson")
			{
				if(animation == "moving" && Time.time > nextFrame)
				{
					frameRate = 0.3f;
					nextFrame = Time.time + frameRate;

					if(frameNum == 1)
					{
						frameNum += 1;
						frameX = 7;
					}
					else if(frameNum == 2)
					{
						frameNum += 1;
						frameX = 8;

						inverse = false;
					}
					else if(frameNum == 3)
					{
						frameNum += 1;
						frameX = 7;
						inverse = false;
					}
					else if(frameNum == 4)
					{
						frameNum = 1;
						frameX = 9;
						inverse = false;
					}
				}
				if(animation == "firing" && Time.time > nextFrame)
				{
					frameRate = 0.05f;
					nextFrame = Time.time + frameRate;

					if(frameNum == 1)
					{
						frameNum += 1;
						frameX = 10;
						inverse = false;
					}
					else if(frameNum == 2)
					{
						frameNum = 1;
						frameX = 7;
						inverse = false;
					}
				}
				if(animation == "idle" && Time.time > nextFrame)
				{
					//only one frame in idle animation, no need to change anything
					frameX = 7;
					frameNum = 1;
				}
			}
			else if(weapon.weaponName == "hands")
			{
				if(animation == "moving" && Time.time > nextFrame)
				{
					frameRate = 0.1f;
					nextFrame = Time.time + frameRate;

					if(frameNum == 1)
					{
						frameNum += 1;
						frameX = 0;
						inverse = false;
					}
					else if(frameNum == 2)
					{
						frameNum += 1;
						frameX = 1;

						inverse = false;
					}
					else if(frameNum == 3)
					{
						frameNum += 1;
						frameX = 0;
					}
					else if(frameNum == 4)
					{
						frameNum = 1;
						frameX = 1;
						inverse = true;
					}
				}
				if(animation == "idle" && Time.time > nextFrame)
				{
					//only one frame in idle animation, no need to change anything
					frameX = 0;
					frameNum = 1;
				}
			}
		}
		else
		{
			//not screwing with players 2-4 right now
			frameX = 0;
		}

		//checks for inverse of sprite, inverses by making scale negative
		if(!inverse)
			spriteQuad.transform.localScale = new Vector3(1,1,1);
		else
			spriteQuad.transform.localScale = new Vector3(-1,1,1);
	}
}