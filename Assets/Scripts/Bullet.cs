using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
{
	private ScreenShake screenShake;
	public float lifetime = 1;
	public float speed = 1;

	void Start()
	{
		GameObject screenShakeObject = GameObject.FindWithTag("MainCamera");
		if(screenShakeObject != null)
			screenShake = screenShakeObject.GetComponent<ScreenShake>();
		screenShake.Shake();

		Destroy(gameObject, lifetime);
	}
	void Update()
	{
		transform.Translate(0,0,speed*Time.deltaTime*50);
	}

	void OnTriggerEnter(Collider other)
	{
		Destroy(gameObject);
	}
}
