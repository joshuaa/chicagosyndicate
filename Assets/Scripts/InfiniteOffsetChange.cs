using UnityEngine;
using System.Collections;

public class InfiniteOffsetChange : MonoBehaviour 
{
	public float changeX;
	public float changeY;

	private float offsetY;
	private float offsetX;

	void FixedUpdate()
	{
		offsetX += changeX;
		offsetY += changeY;

		renderer.material.mainTextureOffset = new Vector2(offsetX*Time.deltaTime, offsetY*Time.deltaTime);
		//renderer.material.SetTextureOffset("GridNoise", new Vector2(offsetX, 0));
	}
}
