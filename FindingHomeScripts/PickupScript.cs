using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum itemType {health, weapon, ammo};

public class PickupScript : MonoBehaviour {

	public int count;
	public int useRate;
	public int effectValue;
	public itemType type;


}
