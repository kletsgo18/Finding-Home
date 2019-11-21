using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove2 : MonoBehaviour {

	public GameObject player;
	public float speed;
	public bool wasd = true;
	public bool tfgh = false;
	public bool xbox = false;
	public float turnSpeed;


	//Use this for initialization
	void Start()
	{
		wasd = true;
	}

	//Update is called once per frame
	void Update()
	{
		if (GameManager.GM.mouseCam == false) {
			if (Input.GetKey (GameManager.GM.rotxl)) {
				transform.Rotate (Vector3.up, -turnSpeed * Time.deltaTime * 1000);
				Debug.Log (turnSpeed * Time.deltaTime);
			}

			if (Input.GetKey (GameManager.GM.rotxr)) {
				transform.Rotate (Vector3.up, turnSpeed * Time.deltaTime * 1000);
			}
		}
	}

	void FixedUpdate()
	{
		if (wasd == true) {;
			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical = Input.GetAxis ("Vertical");

			Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

			transform.Translate (movement * speed);
		}

		else if (tfgh == true) {
			float moveHorizontal = Input.GetAxis ("Horizontal2");
			float moveVertical = Input.GetAxis ("Vertical2");

			Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

			transform.Translate (movement * speed);
		}


	}

	public void WASDControl()
	{
		player.GetComponent<PlayerMove2> ().enabled = true;
		player.GetComponent<PlayerMovement> ().enabled = false;
		wasd = true;
		tfgh = false;
		xbox = false;
	}

	public void TFGHControl()
	{
		player.GetComponent<PlayerMove2> ().enabled = true;
		player.GetComponent<PlayerMovement> ().enabled = false;

		wasd = false;
		tfgh = true;
		xbox = false;
	}

	public void XBOXControl()
	{
		player.GetComponent<PlayerMove2> ().enabled = true;
		player.GetComponent<PlayerMovement> ().enabled = false;
		wasd = false;
		tfgh = false;
		xbox = true;
	}




}
