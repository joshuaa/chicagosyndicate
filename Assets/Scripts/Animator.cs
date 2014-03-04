	using UnityEngine;
using System.Collections;

public class Animator : MonoBehaviour 
{
	public GameObject spriteQuad;
	public GameObject spriteWeapon;
	private PlayerSlot ps;
	private Weapon weapon;

	private int frameNum = 0;

	public float frameX;
	public float frameY;
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
		frameNum = 1;
		totalframesX = 16;
		totalframesY = 8;
	}

	public void UpdateAnimationName()
	{
		
		//if not moving, make it idle. if it is moving and not shooting, make it moving. if it is shooting, make it firing.
		if(Input.GetAxis("P1 Left Thumbstick Horizontal") == 0 && Input.GetAxis("P1 Left Thumbstick Horizontal") == 0 && Input.GetAxis("P1 Triggers") == 0)
			animation = "idle";
		else if(Input.GetAxis("P1 Triggers") < 0)
			animation = "firing";
		else
			animation = "moving";
	}

	public void Animate()
	{
		float averageSpeed = Mathf.Abs(Input.GetAxis("P1 Left Thumbstick Horizontal")) + Mathf.Abs(Input.GetAxis("P1 Left Thumbstick Vertical"));
		float x = frameX/totalframesX;
		float y = frameY/totalframesY;

		spriteQuad.renderer.material.mainTextureOffset = new Vector2(x,y);

		if(ps.playerSlot == 1)
		{
			if(weapon.weaponName == "thompson")
			{
				spriteWeapon.renderer.material.mainTextureOffset = new Vector2(0,0);

				if(animation == "moving" && Time.time > nextFrame)
				{
					Debug.Log(averageSpeed);
					if(averageSpeed > 0.5)
						frameRate = 0.2f;
					else
						frameRate = 0.7f;
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
					frameRate = weapon.fireRate/2;
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
				spriteWeapon.renderer.material.mainTextureOffset = new Vector2(1,0);

				if(animation == "moving" && Time.time > nextFrame)
				{
					frameRate = averageSpeed/10;
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