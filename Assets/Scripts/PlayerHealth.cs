using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public float health;
	public float food;
	public float drink;
	public float stamina;
	public bool alive;
	public float hungerRate = 0.1f;


	void Awake()
	{
		health = 0f;
		food = 100f;
		drink = 100f;
		stamina = 100f;
		alive = true;

	}

	void Start()
	{

	}

	void Update()
	{

		if(health <= 0)
		{
			health = 0;
			Debug.Log ("Dead");
		}

		Hunger ();
		if (food == 0)
		{
			Starvation();
		}
		Debug.Log (food);
	}


	void Starvation ()
	{
		int i = 0;
		for(int j = 0; j < 10; j++)
		{
			if(i >= 5)
			{
				health -= (hungerRate * 2);
			}
		}
		i++;	


		
	}

	void Hunger ()
	{
		int i = 0;
		for(int j = 0; j < 10; j++)
		{
			if(i >= 5)
			{
				food -= hungerRate;
			}
		}
		i++;	
	}
}





