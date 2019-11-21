using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	private LinkedList<InventoryItem> totalInventory = new LinkedList<InventoryItem>();
	private InventoryItem health;
	private InventoryItem weapon;
	private InventoryItem ammo;
	public int inventoryCount = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void AddItem(PickupScript a)
	{
		InventoryItem temp = new InventoryItem(a.count, a.useRate, a.effectValue);
		totalInventory.AddLast (temp);
		inventoryCount++;
	}

	void SubtractItem()
	{}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "InvItem") 
		{
			AddItem (other.gameObject.GetComponent<PickupScript>());
			Destroy (other.gameObject);
		}
	}
}
