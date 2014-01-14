using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour 
{
	private PlayerSlot ps;
	private Weapon weapon;

	public GameObject bullet;
	public GameObject crosshair;
	public GameObject sprite;
	public GameController gc;
	public Vector3 mouse;

	private float nextFire;

	private float x;
	private float y;
	private float h;
	private float v;

	public enum ControlType { crammedKeyboard = 0, hotlineMiami = 1, xbox = 2}
	public ControlType ct = ControlType.crammedKeyboard;

	void Start()
	{
		ps = GetComponent<PlayerSlot>();
		weapon = GetComponent<Weapon>();
	}

	public void Controlls()
	{
		//controlls if no xbox controller
		if(ct == ControlType.crammedKeyboard)
		{
			if(ps.playerSlot == 1)
				P1CK();
			if(ps.playerSlot == 2)
				P2CK();
			if(ps.playerSlot == 3)
				P3CK();
			if(ps.playerSlot == 4)
				P4CK();
		}

		//controlls if xbox controller for player1 only
		if(ct == ControlType.hotlineMiami)
		{
			if(ps.playerSlot == 1)
				P1HM();
		}

		//controlls if xbox controller for other players
		if(ct == ControlType.xbox)
		{
			if(ps.playerSlot == 1)
				P1XB();
		}
	}

	public void P1CK()
	{
		//WASD controls for Player1 movement
		//X to shoot
		
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

	public void P2CK()
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
		if(Input.GetKey(KeyCode.M) && Time.time > nextFire)
		{
			nextFire = Time.time + weapon.fireRate;
			Instantiate(bullet, transform.position, transform.rotation);
		}
	}

	public void P3CK()
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
			nextFire = Time.time + weapon.fireRate;
			Instantiate(bullet, transform.position, transform.rotation);
		}
	}

	public void P4CK()
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
			nextFire = Time.time + weapon.fireRate;
			Instantiate(bullet, transform.position, transform.rotation);
		}
	}

	public void P1HM()
	{
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

	public void P1XB()
	{
		//destroy crosshair, it's unnecesary 
		Destroy(crosshair);
	}
}