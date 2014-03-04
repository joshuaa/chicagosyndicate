using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour 
{
	private PlayerSlot ps;
	private Weapon weapon;
	private Animator animator;

	public GameObject bullet;
	public GameObject sprite;
	public GameController gc;
	public Vector3 mouse;

	private float nextFire;

	private float x;
	private float y;
	private float aimingRotation;
	private float h;
	private float v;

	public enum ControlType { xbox = 0, crammedKeyboard = 1}
	public ControlType ct = ControlType.xbox;

	void Start()
	{
		ps = GetComponent<PlayerSlot>();
		weapon = GetComponent<Weapon>();
		animator = GetComponent<Animator>();
	}

	public void Controlls()
	{
		//controlls if no xbox controller
		if(ct == ControlType.crammedKeyboard)
		{
			if(ps.playerSlot == 1)
				P1CrammedKeyboard();
			if(ps.playerSlot == 2)
				P2CrammedKeyboard();
			if(ps.playerSlot == 3)
				P3CrammedKeyboard();
			if(ps.playerSlot == 4)
				P4CrammedKeyboard();
		}

		//controlls if xbox controller
		if(ct == ControlType.xbox)
		{
			if(ps.playerSlot == 1)
				P1XBbox();
			if(ps.playerSlot == 2)
				P2XBbox();
			if(ps.playerSlot == 3)
				P3XBbox();
			if(ps.playerSlot == 4)
				P4XBbox();
		}
	}

	public void Shoot()
	{
		if(Time.time > nextFire)
		{
			nextFire = Time.time + weapon.fireRate;
			Instantiate(bullet, sprite.transform.position, sprite.transform.rotation);
		}
	}

	public void P1CrammedKeyboard()
	{
		//WASD controls for Player1 movement
		//X to shoot
		
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
			if(weapon.weaponName == "hands")
			{
				
			}
			else
			{
				Shoot();
			}
		}
	}

	public void P2CrammedKeyboard()
	{
		//TFGH controls for Player2 movement
		//V to shoot
		
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
		if(Input.GetKey(KeyCode.M))
		{
			if(weapon.weaponName == "hands")
			{

			}
			else
			{
				Shoot();
			}
		}
	}

	public void P3CrammedKeyboard()
	{
		//IJKL controls for Player2 movement
		//M to shoot

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
			if(weapon.weaponName == "hands")
			{

			}
			else
			{
				Shoot();
			}
		}
	}

	public void P4CrammedKeyboard()
	{
		//Arrow Keys for Player3 movement
		//Right Shift to shoot
		
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
			if(weapon.weaponName == "hands")
			{

			}
			else
			{
				Shoot();
			}
		}
	}

	public void P1XBbox()
	{
		h = Mathf.Clamp(Input.GetAxis("P1 Left Thumbstick Horizontal"),-0.5f,0.5f)*Time.deltaTime*7.5f;
		v = -Mathf.Clamp(Input.GetAxis("P1 Left Thumbstick Vertical"), -0.5f, 0.5f)*Time.deltaTime*7.5f;
		x = Input.GetAxis("P1 Right Thumbstick Horizontal");
		y = Input.GetAxis("P1 Right Thumbstick Vertical");

		if(x > 0.3f || y > 0.3f || x < -0.3f || y < -0.3f)
		{
			if(x > 0)
				aimingRotation = Mathf.Atan(y/x)* Mathf.Rad2Deg + 90;
			if(x < 0)
				aimingRotation = Mathf.Atan(y/x)* Mathf.Rad2Deg - 90;
		}
		if(Input.GetAxis("P1 Triggers") < -0.1f && weapon.weaponName != "hands")
			Shoot();
		//Debug.Log(aimingRotation);

		transform.Translate(h,0,v);
		sprite.transform.rotation = Quaternion.Euler(0,aimingRotation,0);
	}

	public void P2XBbox()
	{
	}

	public void P3XBbox()
	{
	}

	public void P4XBbox()
	{
	}
}