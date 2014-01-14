using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour 
{
	public GUIText text1;
	public GUIText text2;
	public GUIText text3;

	public GameObject bar1;
	public GameObject bar2;
	public GameObject bar3;

	private int barSelected;

	public string menu = "main";

	void Start()
	{
		barSelected = 1;
	}

	void Update()
	{
		if(menu == "main")
			mainMenu();
		if(menu == "play")
			playMenu();
		if(menu == "level")
			levelMenu();
		if(menu == "options")
			optionsMenu();
		if(menu == "extras")
			extrasMenu();

		BarSelected();
		Enter();

	}

	void BarSelected()
	{
		if(Input.GetKeyDown(KeyCode.S) && barSelected <= 2)
		{
			if(menu != "main" && barSelected <= 1 && menu != "options")
				barSelected += 1;
			else if(menu == "main")
				barSelected += 1;
		}
		if(Input.GetKeyDown(KeyCode.W) && barSelected >= 2)
			barSelected -= 1;

		if(barSelected == 1)
		{	
			text1.fontSize = 75;
			text2.fontSize = 50;
			text3.fontSize = 50;
			bar1.transform.localScale = new Vector3(18,3,1);
			bar2.transform.localScale = new Vector3(16,2,1);
			bar3.transform.localScale = new Vector3(16,2,1);
		}
		if(barSelected == 2)
		{	
			text1.fontSize = 50;
			text2.fontSize = 75;
			text3.fontSize = 50;
			bar1.transform.localScale = new Vector3(16,2,1);
			bar2.transform.localScale = new Vector3(18,3,1);
			bar3.transform.localScale = new Vector3(16,2,1);
		}
		if(barSelected == 3)
		{	
			text1.fontSize = 50;
			text2.fontSize = 50;
			text3.fontSize = 75;
			bar1.transform.localScale = new Vector3(16,2,1);
			bar2.transform.localScale = new Vector3(16,2,1);
			bar3.transform.localScale = new Vector3(18,3,1);
		}
	}

	void Enter()
	{
		if(Input.GetKeyDown(KeyCode.Return))
		{
			if(menu == "main")
			{
				if(barSelected == 1)
				{
					barSelected = 1;
					menu = "play";
				}
				else if(barSelected == 2)
				{
					barSelected = 1;
					menu = "options";
				}
				else if(barSelected == 3)
				{
					barSelected = 1;
					menu = "extras";
				}
			}
			else if(menu == "play")
			{
				if(barSelected == 1)
				{
					barSelected = 1;
					menu = "level";
				}
				else if(barSelected == 2)
				{
					barSelected = 1;
					menu = "main";
				}
				else if(barSelected == 3)
				{
					barSelected = 2;
				}
			}
			else if(menu == "level")
			{
				if(barSelected == 1)
				{
					Application.LoadLevel("Test");
				}
				else if(barSelected == 2)
				{
					barSelected = 1;
					menu = "play";
				}
				else if(barSelected == 3)
				{
					barSelected = 2;
				}
			}
			else if(menu == "options")
			{
				if(barSelected == 1)
				{
					barSelected = 1;
					menu = "main";
				}
				else if(barSelected == 2)
				{
					barSelected = 1;
				}
				else if(barSelected == 3)
				{
					barSelected = 1;
				}
			}
			else if(menu == "extras")
			{
				if(barSelected == 1)
				{
					//load level editor
				}
				else if(barSelected == 2)
				{
					barSelected = 1;
					menu = "main";
				}
				else if(barSelected == 3)
				{
					barSelected = 2;
				}
			}
		}
	}

	void mainMenu()
	{
		text1.text = "Play";
		text2.text = "Options";
		text3.text = "Extras";
		bar1.transform.localPosition = new Vector3(0,0,20);
		bar2.transform.localPosition = new Vector3(0,-3,20);
		bar3.transform.localPosition = new Vector3(0f,-6f,20f);
		text1.transform.localPosition = new Vector3(0.5f,-0.5f,10);
		text2.transform.localPosition = new Vector3(0.5f,-0.66f,10);
		text3.transform.localPosition = new Vector3(0.5f,-0.82f,10);

	}

	void playMenu()
	{
		bar1.transform.localPosition = new Vector3(0,0,20);
		bar2.transform.localPosition = new Vector3(0,-3,20);
		bar3.transform.localPosition = new Vector3(0f,-100,20);
		text1.transform.localPosition = new Vector3(0.5f,-0.5f,10);
		text2.transform.localPosition = new Vector3(0.5f,-0.66f,10);
		text3.transform.localPosition = new Vector3(0.5f,-0.82f,10);
		text1.text = "Level Select";
		text2.text = "Back";
		text3.text = "";
	}

	void levelMenu()
	{
		bar1.transform.localPosition = new Vector3(0,0,20);
		bar2.transform.localPosition = new Vector3(0,-3,20);
		bar3.transform.localPosition = new Vector3(0,-100,20);
		text1.transform.localPosition = new Vector3(0.5f,-0.5f,10);
		text2.transform.localPosition = new Vector3(0.5f,-0.66f,10);
		text3.transform.localPosition = new Vector3(0.5f,-0.82f,10);
		text1.text = "Test";
		text2.text = "Back";
		text3.text = "";
	}

	void optionsMenu()
	{
		bar1.transform.localPosition = new Vector3(0,0,20);
		bar2.transform.localPosition = new Vector3(0,-100,20);
		bar3.transform.localPosition = new Vector3(0,-100,20);
		text1.transform.localPosition = new Vector3(0.5f,-0.5f,10);
		text2.transform.localPosition = new Vector3(0.5f,-0.66f,10);
		text3.transform.localPosition = new Vector3(0.5f,-0.82f,10);
		text1.text = "Back";
		text2.text = "";
		text3.text = "";
	}

	void extrasMenu()
	{
		bar1.transform.localPosition = new Vector3(0f,0f,20f);
		bar2.transform.localPosition = new Vector3(0,-3f,20f);
		bar3.transform.localPosition = new Vector3(0f,-100f,20f);
		text1.transform.localPosition = new Vector3(0.5f,-0.5f,10f);
		text2.transform.localPosition = new Vector3(0.5f,-0.66f,10f);
		text3.transform.localPosition = new Vector3(0.5f,-0.82f,10f);
		text1.text = "Level Editor";
		text2.text = "Back";
		text3.text = "";
	}
}