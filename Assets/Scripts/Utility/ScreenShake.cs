using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour 
{
	public float slide = 1;
	public float range = 10;

	private int combo;

	private float mx;
	private float my;

	void Update()
	{

		mx -= (mx/slide)*Time.deltaTime;
		my -= (my/slide)*Time.deltaTime;

		transform.position = new Vector3(mx, transform.position.y, my);
	}

	public void Shake()
	{
		combo = Random.Range(1,4);

		if(combo == 1)
		{
			mx = range;
			my = range;
		}
		if(combo == 2)
		{
			mx = range;
			my = -range;
		}
		if(combo == 3)
		{
			mx = -range;
			my = range;
		}
		if(combo == 4)
		{
			mx = -range;
			my = -range;
		}
	}
}
