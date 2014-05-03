﻿using UnityEngine;
using System.Collections;


[System.Serializable]
public class Item {

	public string itemName;
	public int itemID;
	public string itemDesc;
	public Texture2D itemIcon;
	public int itemStat1;
	public int itemStat2;
	public int itemStat3;
	public ItemType itemType;
	public ItemType2 itemType2;

	public enum ItemType
	{
		Weapon,
		Consumable,
		Craftable,
		Utility
	}

	public enum ItemType2
	{
		Weapon,
		Consumable,
		Craftable,
		Utility,
		None
	}

	public Item(string name, int ID, string desc, int s1, int s2, int s3, ItemType type, ItemType2 type2)
	{
		itemName = name;
		itemID = ID;
		itemDesc = desc;
		itemIcon = Resources.Load<Texture2D>("Item Icons/" + itemName);
		itemStat1 = s1;
		itemStat2 = s2;
		itemStat3 = s3;
		itemType = type;
		itemType2 = type2;
		
	}

	public Item()
	{

	}
}