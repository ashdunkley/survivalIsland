using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
	
	public float health;
	public float food;
	public float drink;
	public float energy;
	public bool alive;
	public float hungerRate = 0.1f;
	public float staminaMultiplier = 0.25f;
	public float interval;
	private float lastUpadateTime;
	private PlayerController Controller;
	private float prevSpeed;
	private float prevJumpSpeed;
	private float prevRunSpeed;



	void Awake ()
	{
		health = 100f;
		food = 100f;
		drink = 100f;
		energy = 100f;
		alive = true;
		
	}
	
	void Start ()
	{
		lastUpadateTime = Time.time;
		Controller = GetComponent<PlayerController> ();
		prevSpeed = Controller.speed;
		prevRunSpeed = Controller.runSpeed;
		prevJumpSpeed = Controller.jumpSpeed;
	}
	
	void Update ()
	{
		//Health Regen

		//timer for updating players shit
		if (Time.time - lastUpadateTime > interval) {
			UpdatePlayerState();
			lastUpadateTime = Time.time;
		}

		//SNAKE? SNAKE?! SNAAAAAAAAKKKKKKEEEEE!!!!
		if(health <= 0)
		{
			alive = false;
			health = 0;
			Debug.Log("Player died");
			Destroy (gameObject);
		}

		Stamina ();

		if (health >= 100f) {health = 100;}
		if (food >= 100f)   {food = 100;}
		if (drink >= 100f)  {drink = 100;}
		if (energy >= 100f) {energy = 100;}

	
		if (energy <= 0f) {energy = 0;}


		//Debug.Log (health);
	}
	
	void UpdatePlayerState()
	{
		food -= hungerRate;
		drink -= hungerRate;
		energy -= staminaMultiplier;

		if(food <= 0)
		{
			health -= hungerRate * 2;//starvation multiplier
			food = 0;
			energy = energy / 2;
		}

		if(drink <= 0)
		{
			health -= hungerRate * 4; //thirst multiplier
			drink = 0;
			energy = energy / 10;
		}

		if (energy <= 0)
		{
			energy = 0;
			food -= hungerRate * 2;
			drink -= hungerRate * 2;
		}


		
		//do conditionals for what the effects are here
		
	}

	void Stamina()
	{
		if(energy <= 60 || health <= 40)
		{
			Controller.speed = 4;
			Controller.jumpSpeed = 6;
			Controller.runSpeed = 6;



			if(energy <= 30 || health <= 20)
			{
				Controller.speed = 2;
				Controller.jumpSpeed = 3;
				Controller.runSpeed = 3;

			}

					
		}
		else
		{
			Controller.speed = prevSpeed;
			Controller.jumpSpeed = prevJumpSpeed;
			Controller.runSpeed = prevRunSpeed;
		}



	}




}
