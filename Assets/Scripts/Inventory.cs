using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
	public int slotX, slotY;
	public List<Item> inventory = new List<Item> ();
	public List<Item> slots = new List<Item> ();
	private ItemDatabase database;
	private bool showInventory;
	private int x;
	private int y;
	public GUISkin skin;
	private bool showTooltip;
	private string tooltip;
	private bool draggingItem;
	private Item draggedItem;
	private int prevIndex;

	void Start () 
	{
		for(int i = 0; i < (slotX * slotY); i++) 
		{
			slots.Add (new Item());
			inventory.Add (new Item());
		}


		database = GameObject.FindGameObjectWithTag("Item Database").GetComponent<ItemDatabase> ();


		AddItem (0);
		AddItem (0);

	}

	void Update()
	{
		if (Input.GetButtonDown ("Inventory"))
		{
			showInventory = !showInventory;
		}
	}

	void OnGUI()
	{
		tooltip = "";

		GUI.skin = skin;

		if(showInventory)
		{
			DrawInventory();
		}
		if(showTooltip && showInventory)
		{
			GUI.Box (new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y, 200, 75), tooltip, skin.GetStyle("slot"));
		}

		if (draggingItem)
		{
			GUI.DrawTexture (new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y, 50, 50), draggedItem.itemIcon);
		}
	}
	
	//Inventory GUI
	void DrawInventory()
	{
		Event e = Event.current;
		int i = 0;

		for(int y = 0; y < slotY; y++)
		{
			for(int x = 0; x < slotX; x++)
			{
				Rect slotRect = new Rect(x * 60, y * 60,50,50);
				GUI.Box(slotRect, "", skin.GetStyle("slot"));
				slots[i] = inventory[i];
				if (slots[i].itemName != null)
				{
					GUI.DrawTexture(slotRect, slots[i].itemIcon);

					if(slotRect.Contains(e.mousePosition))
					{
						tooltip = CreateTooltip(slots[i]);
						showTooltip = true;

						//drag&drop
						if (e.button == 0 && e.type == EventType.mouseDrag && !draggingItem)
						{
							draggingItem = true;
							prevIndex = i;
							draggedItem = slots[i];
							inventory[i] = new Item();
						}
						if (e.type == EventType.mouseUp && draggingItem)
						{
							inventory[prevIndex] = inventory[i];
							inventory[i] = draggedItem;
							draggingItem = false;
							draggedItem = null;
						}
						
						
					}

				} 
				else 
				{
					if(slotRect.Contains(e.mousePosition))
					{
						if (e.type == EventType.mouseUp && draggingItem)
						{
							inventory[i] = draggedItem;
							draggingItem = false;
							draggedItem = null;
						}
					}
				}

				if (tooltip == "")
				{
					showTooltip = false;
				}
				i++;
			}
		}
	}

	//Method to addItem to Inventory by itemID
	void AddItem (int id)
	{
		for(int i = 0; i < inventory.Count; i++)
		{
			if(inventory[i].itemName == null)
			{
				for(int j = 0; j < database.items.Count; j++)
				{
					if(database.items[j].itemID == id)
					{
						inventory[i] = database.items[j];
					}
				}
				break;
			}
		}
			
	}

	//To check inventory for item by itemID
	bool InventoryContains(int id)
	{
		bool result = false;
		for (int i = 0; i < inventory.Count; i++)
		{
			result = inventory[i].itemID == id;
			if(result)
			{
				break;
			}
		}
		return result;
	}

	void RemoveItem (int id)
	{
		for(int i = 0; i < inventory.Count; i++)
		{
			if (inventory[i].itemID == id)
			{

				inventory[i] = new Item();
				break;
			}
		}

	}

	string CreateTooltip (Item item)
	{
		tooltip = item.itemName+ "\n\n" + item.itemDesc;
		return tooltip;
	}
}