using UnityEngine;
using System.Collections;

public class GameTime : MonoBehaviour {

	public enum TimeOfDay 
	{
		Idle,
		SunRise,
		Noon,
		SunSet
	}

	public Transform[] sun;

	public float sunRise;
	public float sunSet;
	public float skyBlendModifier;
	public float noon;

	private const float second = 1;
	private const float minute = 60 * second;
	private const float hour = 60 * minute;
	private const float day = 24 * hour;
	public int Day = 1;


	public float dayCycleInMinutes = 1;
	private float dayCycleInSeconds;
	public float timeOfDay;

	private float degreesPerSecond = 360 / day;
	private float degreeRotation;
	public TimeOfDay _tod;
	private Light Sun;

	void Start () {

		Sun = GameObject.FindGameObjectWithTag ("Sun").GetComponent<Light> ();

		_tod = TimeOfDay.Idle;

		dayCycleInSeconds = dayCycleInMinutes * minute;
		
		timeOfDay = 0;
		degreeRotation = degreesPerSecond * day / (dayCycleInSeconds);
		RenderSettings.skybox.SetFloat ("_Blend", 0);

		sunRise *= dayCycleInSeconds;
		sunSet *= dayCycleInSeconds;
		noon = dayCycleInSeconds / 2;


		//OnGui ();


	}
	
	// Update is called once per frame
	void Update () {

		sun [0].Rotate (new Vector3(degreeRotation, 0, 0) * Time.deltaTime);

		timeOfDay += Time.deltaTime;


		if (timeOfDay >= dayCycleInSeconds) {
			timeOfDay -= dayCycleInSeconds;
			Day += 1;
			//OnGui ();
			//Debug.Log (Day);
		}


		
		//Debug.Log (timeOfDay);
		if 
		   (timeOfDay > sunRise &&
			timeOfDay < sunSet  &&
			RenderSettings.skybox.GetFloat ("_Blend") < 1)
			
		{
			_tod = GameTime.TimeOfDay.SunRise;
			blendSky ();
			float i = 0f;
			for(int j = 0; j < 10; j++)

			{
				Sun.intensity = i;
			}

			i = i +0.1f;
		
		}

		else if
			(timeOfDay > sunSet &&
			RenderSettings.skybox.GetFloat ("_Blend") > 0)
		{
			_tod = GameTime.TimeOfDay.SunSet;
			blendSky();
			int i = 10;
			for(int j = 0; j < 5; j++)
				
			{
				Sun.intensity = (i / 10);
				i--;
			}
		}
		else
		{
			_tod = GameTime.TimeOfDay.Idle;
		}

	}

	private void blendSky() 
	{
		float sunDown = 0;

		switch (_tod) 
		{
			case TimeOfDay.SunRise:
				sunDown = (timeOfDay - sunRise) / dayCycleInSeconds * skyBlendModifier;
				break;
			case TimeOfDay.SunSet:
				sunDown = (timeOfDay - sunSet) / dayCycleInSeconds * skyBlendModifier;
				sunDown = 1- sunDown;
				break;
		}

		RenderSettings.skybox.SetFloat ("_Blend", sunDown);


		//Debug.Log (sunDown);

	}
}
	