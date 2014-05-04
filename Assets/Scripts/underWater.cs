using UnityEngine;
using System.Collections;

public class underWater : MonoBehaviour {

	public float waterLevel = 74.0f;
	public bool under = false;
	public Color normalColorDay;
	public Color normalColorNight;
	public Color underColorDay;
	public Color underColorNight;

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
		if(under)
		{
			RenderSettings.fog = true;
			RenderSettings.fogColor = underColorDay;
			RenderSettings.fogDensity = 0.1f;
			RenderSettings.fogEndDistance = 50;
		}


	}

	private void setNormal ()
	{
		RenderSettings.fog = false;
		RenderSettings.fogDensity = 0.001f;
	}
}
