using UnityEngine;
using System.Collections;

public class underWater : MonoBehaviour {

	public float waterLevel = 74.0f;
	public bool under = false;
	public Color normalColorDay;
	public Color normalColorNight;
	public Color underColorDay;
	public Color underColorNight;
	private PlayerController Controller;


	void Start () 
	{
		Controller = GetComponent<PlayerController> ();

	}

	void Update () 
	{

		if ((transform.position.y < waterLevel) != under)
			under = transform.position.y < (waterLevel);

		if (under) 
		{
			setUnder ();
		}

		if(!under)
		{
			setNormal();
		}

	}
	
	private void setUnder ()
	{
		if (under) 
		{	
			RenderSettings.fogColor = underColorDay;
			RenderSettings.fogDensity = 0.1f;
			RenderSettings.fogEndDistance = 50;
			Controller.gravity = 2;
			Controller.speed = 4;
			Controller.runSpeed = 6;
			Controller.jumpSpeed = 3;
		}

	}

	private void setNormal ()
	{
			RenderSettings.fogColor = normalColorDay;


		/**{
			RenderSettings.fogColor = normalColorNight;
		}**/

		RenderSettings.fogDensity = 0.001f;
		Controller.speed = 6.0f;
		Controller.jumpSpeed = 8.0f;
		Controller.gravity = 20.0f;
		Controller.runSpeed = 10.0f;

	}
}
