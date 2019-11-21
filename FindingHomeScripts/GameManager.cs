using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject player;
	public GameObject cameraLook;
	public bool mouseCam = true;
	public static GameManager GM;
	public KeyCode jump { get; set; }
	public KeyCode forward { get; set; }
	public KeyCode backward { get; set; }
	public KeyCode left { get; set; }
	public KeyCode right { get; set; }
	public KeyCode rotxl { get; set; }
	public KeyCode rotxr { get; set; }

	public bool customControl = false;



	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		if (GM == null) {
			DontDestroyOnLoad (gameObject);
			GM = this;
		} else if (GM != this) {
			Destroy (gameObject);
		}

		jump = (KeyCode)System.Enum.Parse (typeof(KeyCode), PlayerPrefs.GetString ("jumpKey", "Space"));
		forward = (KeyCode)System.Enum.Parse (typeof(KeyCode), PlayerPrefs.GetString ("forwardKey", "W"));
		backward = (KeyCode)System.Enum.Parse (typeof(KeyCode), PlayerPrefs.GetString ("backwardKey", "S"));
		left = (KeyCode)System.Enum.Parse (typeof(KeyCode), PlayerPrefs.GetString ("leftKey", "A"));
		right = (KeyCode)System.Enum.Parse (typeof(KeyCode), PlayerPrefs.GetString ("rightKey", "D"));
		rotxl = (KeyCode)System.Enum.Parse (typeof(KeyCode), PlayerPrefs.GetString ("rotationLeft", "LeftArrow"));
		rotxr = (KeyCode)System.Enum.Parse (typeof(KeyCode), PlayerPrefs.GetString ("rotationRight", "RightArrow"));
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CustomControl()
	{		
		customControl = true;
		ControlManager ();
	}

	public void ControlManager()
	{
		if (customControl == true) {
			player.GetComponent<PlayerMovement> ().enabled = true;
			player.GetComponent<PlayerMove2> ().enabled = false;
		} else if (customControl == false) 
		{
			player.GetComponent<PlayerMovement> ().enabled = false;
			player.GetComponent<PlayerMove2> ().enabled = true;
		}
	}

	public void CameraMouse()
	{
		mouseCam = true;
		cameraLook.GetComponent<MouseLook> ().enabled = true;
		ControlManager ();
	}

	public void CameraArrow()
	{
		mouseCam = false;
		cameraLook.GetComponent<MouseLook> ().enabled = false;
		ControlManager ();
	}
}
