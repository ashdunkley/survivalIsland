using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour 
{

	public List<Item> items = new List<Item> ();


	


	void Awake()
		{
		//Knife
		items.Add(new Item("Knife", 0, "This can be used as more than just a Weapon", 0, 0, 0, Item.ItemType.Weapon, Item.ItemType2.Utility));
		//Wild Berries
		items.Add(new Item("Wild Berries", 1, "They aren't poisonous", 10, 10, 10, Item.ItemType.Consumable, Item.ItemType2.None));

	
	
	
		}


}