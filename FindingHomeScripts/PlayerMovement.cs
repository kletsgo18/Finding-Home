using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
	public float turnSpeed;

    // Use this for initialization
    void Start()
    {
		
    }

    // Update is called once per frame
	void Update(){



		if (Input.GetKey (GameManager.GM.forward)) {
			transform.position += transform.forward * speed;
		}

		if (Input.GetKey (GameManager.GM.backward)) {
			transform.position += -transform.forward * speed;
		}

		if (Input.GetKey (GameManager.GM.left)) {
			transform.position += -transform.right * speed;
		}

		if (Input.GetKey (GameManager.GM.right)) {
			transform.position += transform.right * speed;
		}

		if (Input.GetKeyDown (GameManager.GM.jump)) {
			transform.position += Vector3.up * speed;
		}

		if (Input.GetKey (GameManager.GM.rotxl)) {
			transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime * 1000);
			Debug.Log (turnSpeed * Time.deltaTime);
		}

		if (Input.GetKey (GameManager.GM.rotxr)) {
			transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * 1000);
		}
    }

    void FixedUpdate()
    {
		
    }   
}

/*
float moveHorizontal = Input.GetAxis("Horizontal");
         float moveVertical = Input.GetAxis("Vertical");

         Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

         transform.Translate(movement * speed);*/
