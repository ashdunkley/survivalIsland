using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour 
{

	public List<Item> items = new List<Item> ();




	void Awake()
		{
		items.Add(new Item("Knife", 0, "This can be used as more than just a Weapon", 0, 0, 0, Item.ItemType.Weapon, Item.ItemType2.Utility));
		}

}