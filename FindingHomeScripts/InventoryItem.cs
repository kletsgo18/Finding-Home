using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem {

	int count;
	float useRate;
	float effectValue;
	InventoryItem nextItem;

	void Use()
	{}

	void Equip()
	{}

	public InventoryItem (int count_input, float useRate_input, float effectValue_input)
	{
		count = count_input;
		useRate = useRate_input;
		effectValue = effectValue_input;
	}


}
