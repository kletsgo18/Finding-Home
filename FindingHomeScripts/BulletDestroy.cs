﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour {

	public float timer = 5.0f;

	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0.0f) {
			Destroy (this.gameObject);
		}
		
	}

	void OnCollisionEnter (Collision collision)
	{

		Destroy (this.gameObject);
	}
}
