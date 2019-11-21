using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour {

	public float bulletSpeed = 10;
	private GameObject bullet;
	public GameObject[] bullets;
	System.Random random = new System.Random();


	void Fire()
	{
		int rNum = random.Next (0, 2);
		bullet = bullets [rNum];
		GameObject bulletClone = (GameObject)Instantiate(bullet, transform.position, transform.rotation);
		bulletClone.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
	}

	void Update()
	{
		if (Input.GetButtonDown("Fire2"))
			Fire();
	}


}
