using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	public GUIText usableText;

	private Animator animator;
	public Character character;
	private Controller controller;
	private PlayerDie playerDie;
	private PlayerSlot playerSlot;
	private Weapon weapon;
	
	void Start()
	{
		animator = GetComponent<Animator>();
		character = GetComponent<Character>();
		controller = GetComponent<Controller>();
		playerDie = GetComponent<PlayerDie>();
		playerSlot = GetComponent<PlayerSlot>();
		weapon = GetComponent<Weapon>();

		weapon.WeaponInfo();
	}

	void Update()
	{
		usableText.text = "";

		animator.UpdateAnimationName();
		animator.Animate();

		character.UpdateCharacter();

		controller.Controlls();

		playerSlot.SetPlayerSlot();
	}
}