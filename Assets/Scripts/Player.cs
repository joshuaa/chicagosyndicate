using UnityEngine;
using System.Collections;

[System.Serializable]
public class Weapon
{
	public string weaponName = "thompson";

	public float fireRate = 0.1f;
	public float totalRounds = 30;
	public float movementSpeed = 5;
	public float roundsLeft = 30;

	public void Update()
	{
		if(weaponName == "thompson")
		{
			fireRate = 0.1f;
			totalRounds = 30;
			movementSpeed = 5;
			roundsLeft = 30;
		}
	}
	
}

public class Player : MonoBehaviour 
{
	public string weaponName = "thompson";

	public Weapon weapon;

	public enum ControlType { crammedKeyboard = 0, hotlineMiami = 1, xbox = 2}
	public ControlType ct = ControlType.crammedKeyboard;

	public GameObject bullet;
	public GameObject crosshair;
	public GameObject sprite;
	public GameObject spriteQuad;
	public GameController gc;
	public Vector3 mouse;

	private int playerSlot;

	private float nextFire;

	public float x;
	public float y;
	public float h;
	public float v;

	public float totalframesX;
	public float totalframesY;

	public float frameX;
	public float frameY;

	public string animation = "idle";

	void Start()
	{
		SetPlayerSlot();
		totalframesX = 16;
		totalframesY = 1;
	}

	void Update()
	{
		Controls();
		UpdateAnimationName();
		Animate();
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "p1bullet")
			Debug.Log("Player1 killed " + gameObject.tag);

		if(other.gameObject.tag == "p2bullet")
			Debug.Log("Player2 killed " + gameObject.tag);

		if(other.gameObject.tag == "p3bullet")
			Debug.Log("Player3 killed " + gameObject.tag);

		if(other.gameObject.tag == "p4bullet")
			Debug.Log("Player4 killed " + gameObject.tag);

		if(playerSlot == 1 && (other.gameObject.tag == "p2bullet" || other.gameObject.tag == "p3bullet" || other.gameObject.tag == "p4bullet"))
		{
			gc.playerCount -= 1;
			if(crosshair != null)
				Destroy(crosshair);
			Destroy(gameObject);
		}
		if(playerSlot == 2 && (other.gameObject.tag == "p1bullet" || other.gameObject.tag == "p3bullet" || other.gameObject.tag == "p4bullet"))
		{
			gc.playerCount -= 1;
			Destroy(gameObject);
		}
		if(playerSlot == 3 && (other.gameObject.tag == "p1bullet" || other.gameObject.tag == "p2bullet" || other.gameObject.tag == "p4bullet"))
		{
			gc.playerCount -= 1;
			Destroy(gameObject);
		}
		if(playerSlot == 4 && (other.gameObject.tag == "p1bullet" || other.gameObject.tag == "p2bullet" || other.gameObject.tag == "p3bullet"))
		{
			gc.playerCount -= 1;
			Destroy(gameObject);
		}
	}

	void SetPlayerSlot()
	{
		if(gameObject.tag == "Player1")
			playerSlot = 1;
		if(gameObject.tag == "Player2")
			playerSlot = 2;
		if(gameObject.tag == "Player3")
			playerSlot = 3;
		if(gameObject.tag == "Player4")
			playerSlot = 4;	
	}

	void Controls()
	{
		//controlls if no xbox controller
		/*if(ct == ControlType.crammedKeyboard)
		{
			//WASD controls for Player1 movement
			//X to shoot
			if(playerSlot == 1)
			{
			//destroy crosshair, it's unnecesary 
				Destroy(crosshair);
			//right(d)
			if(Input.GetKey(KeyCode.D))
			{
				transform.rotation = Quaternion.Euler(0,90,0);
				transform.Translate(0,0,weapon.movementSpeed*Time.deltaTime);
			}
			//left(a)
			if(Input.GetKey(KeyCode.A))
			{
				transform.rotation = Quaternion.Euler(0,-90,0);
				transform.Translate(0,0,weapon.movementSpeed*Time.deltaTime);
			}
			//down(s)
			if(Input.GetKey(KeyCode.S))
			{
				transform.rotation = Quaternion.Euler(0,-180,0);
				transform.Translate(0,0,weapon.movementSpeed*Time.deltaTime);
			}
			//up(w)
			if(Input.GetKey(KeyCode.W))
			{
				transform.rotation = Quaternion.Euler(0,0,0);
				transform.Translate(0,0,weapon.movementSpeed*Time.deltaTime);
			}
			//shoot(x)
			if(Input.GetKey(KeyCode.X) && Time.time > nextFire)
			{
				nextFire = Time.time + weapon.fireRate;
				Instantiate(bullet, transform.position, transform.rotation);
			}
			}

			//TFGH controls for Player2 movement
			//V to shoot
			if(playerSlot == 2)
			{
			//right(l)
			if(Input.GetKey(KeyCode.L))
			{
				transform.rotation = Quaternion.Euler(0,90,0);
				transform.Translate(0,0,weapon.movementSpeed*Time.deltaTime);
			}
			//left(j)
			if(Input.GetKey(KeyCode.J))
			{
				transform.rotation = Quaternion.Euler(0,-90,0);
				transform.Translate(0,0,weapon.movementSpeed*Time.deltaTime);
			}
			//down(k)
			if(Input.GetKey(KeyCode.K))
			{
				transform.rotation = Quaternion.Euler(0,-180,0);
				transform.Translate(0,0,weapon.movementSpeed*Time.deltaTime);
			}
			//up(i)
			if(Input.GetKey(KeyCode.I))
			{
				transform.rotation = Quaternion.Euler(0,0,0);
				transform.Translate(0,0,weapon.movementSpeed*Time.deltaTime);
			}
			//shoot(M)
			if(Input.GetKey(KeyCode.M) && Time.time > nextFire)
			{
				nextFire = Time.time + weapon.fireRate;
				Instantiate(bullet, transform.position, transform.rotation);
			}
			}

			//IJKL controls for Player2 movement
			//M to shoot
			if(playerSlot == 3)
			{
			//right(right arrow)
			if(Input.GetKey(KeyCode.RightArrow))
			{
				transform.rotation = Quaternion.Euler(0,90,0);
				transform.Translate(0,0,weapon.movementSpeed*Time.deltaTime);
			}
			//left(left arrow)
			if(Input.GetKey(KeyCode.LeftArrow))
			{
				transform.rotation = Quaternion.Euler(0,-90,0);
				transform.Translate(0,0,weapon.movementSpeed*Time.deltaTime);
			}
			//down(down arrow)
			if(Input.GetKey(KeyCode.DownArrow))
			{
				transform.rotation = Quaternion.Euler(0,-180,0);
				transform.Translate(0,0,weapon.movementSpeed*Time.deltaTime);
			}
			//up(up arrow)
			if(Input.GetKey(KeyCode.UpArrow))
			{
				transform.rotation = Quaternion.Euler(0,0,0);
				transform.Translate(0,0,weapon.movementSpeed*Time.deltaTime);
			}
			//shoot(right shift)
			if(Input.GetKey(KeyCode.RightShift) && Time.time > nextFire)
			{
				nextFire = Time.time + weapon.fireRate;
				Instantiate(bullet, transform.position, transform.rotation);
			}
			}

			//Arrow Keys for Player3 movement
			//Right Shift to shoot
			if(playerSlot == 4)
			{
			//right(num 3)
			if(Input.GetKey(KeyCode.Keypad3))
			{
				transform.rotation = Quaternion.Euler(0,90,0);
				transform.Translate(0,0,weapon.movementSpeed*Time.deltaTime);
			}
			//left(num 1)
			if(Input.GetKey(KeyCode.Keypad1))
			{
				transform.rotation = Quaternion.Euler(0,-90,0);
				transform.Translate(0,0,weapon.movementSpeed*Time.deltaTime);
			}
			//down(num 2)
			if(Input.GetKey(KeyCode.Keypad2))
			{
				transform.rotation = Quaternion.Euler(0,-180,0);
				transform.Translate(0,0,weapon.movementSpeed*Time.deltaTime);
			}
			//up(num 5)
			if(Input.GetKey(KeyCode.Keypad5))
			{
				transform.rotation = Quaternion.Euler(0,0,0);
				transform.Translate(0,0,weapon.movementSpeed*Time.deltaTime);
			}
			//shoot(num 0)
			if(Input.GetKey(KeyCode.Keypad0) && Time.time > nextFire)
			{
				nextFire = Time.time + weapon.fireRate;
				Instantiate(bullet, transform.position, transform.rotation);
			}
			}
		}*/

		//controlls if xbox controller for player1 only
		if(ct == ControlType.hotlineMiami)
		{
			Debug.Log(weapon.movementSpeed);
			h = Input.GetAxis("Horizontal")*weapon.movementSpeed*Time.deltaTime;
			v = Input.GetAxis("Vertical")*weapon.movementSpeed*Time.deltaTime;
			x += (Input.GetAxis("Mouse X")*10)*Time.deltaTime;
			y += (Input.GetAxis("Mouse Y")*10)*Time.deltaTime;
			mouse = new Vector3 (x,1,y);

			crosshair.transform.position = mouse + new Vector3(0,3,0);
			//rigidbody.rotation = sprite.transform.rotation;
			transform.Translate(h,0,v);
			//sprite.transform.rotation = Quaternion.Euler(0,sprite.transform.rotation.y,0);
			sprite.transform.LookAt(mouse);
			if(Input.GetButton("Fire1") && Time.time > nextFire)
			{
				nextFire = Time.time + weapon.fireRate;
				Instantiate(bullet, sprite.transform.position, sprite.transform.rotation);
			}
		}

		//controlls if xbox controller for other players
		if(ct == ControlType.xbox)
		{
			//destroy crosshair, it's unnecesary 
				Destroy(crosshair);
		}
	}

	void UpdateAnimationName()
	{
		spriteQuad.renderer.material.mainTextureOffset = new Vector2(frameX/totalframesX, frameX/totalframesY);

		/*if(playerScript.weapon.weaponName == "thompson")
		{
			if(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0 && !Input.GetButton("Fire1"))
			{
				animation = "2h idle";
			}
			else if(!Input.GetButton("Fire1"))
			{
				animation = "2h moving";
			}
			else
			{
				animation = "2h firing";
			}
		}*/
	}

	void Animate()
	{
		if(animation == "2h idle")
		{
			frameX = 7;
		}
	}
}