using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
	public float fireRate;
	public float totalRounds;
	public float movementSpeed;
	public float roundsLeft;

	public string weaponName = "hands";

	public void WeaponInfo()
	{
		if(weaponName == "thompson")
		{
			fireRate = 0.15f;
			totalRounds = 20;
			movementSpeed = 5;
			roundsLeft = 20;
		}
		if(weaponName == "mpk")
		{
			fireRate = 0.1f;
			totalRounds = 30;
			movementSpeed = 6;
			roundsLeft = 30;
		}
		if(weaponName == "revolver")
		{
			fireRate = 0.5f;
			totalRounds = 6;
			movementSpeed = 5;
			roundsLeft = 6;
		}
		if(weaponName == "hands")
		{
			fireRate = 0.1f;
			totalRounds = 0;
			movementSpeed = 7;
			roundsLeft = 0;
		}
	}
}