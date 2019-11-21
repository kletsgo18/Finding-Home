using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

	Transform menuPanel;
	Transform crossHair;
	Event keyEvent;
	Text buttonText;
	KeyCode newKey;
	public GameObject cameraLook;
	public GameObject player;
	GameManager gm;
	public bool mouseCam;

	//public bool menu = menuPanel.gameObject.SetActive();

	bool waitingForKey;

	void Awake()
	{
		cameraLook = GameObject.FindGameObjectWithTag ("MainCamera");
	}

	// Use this for initialization
	void Start () {
		menuPanel = transform.Find("Panel");
		menuPanel.gameObject.SetActive (false);
		crossHair = transform.Find("Crosshair");
		crossHair.gameObject.SetActive (true);
		waitingForKey = false;

		for (int i = 0; i < 5; i++) 
		{
			if (menuPanel.GetChild (i).name == "ForwardKey") 
			{
				menuPanel.GetChild (i).GetComponentInChildren<Text> ().text = GameManager.GM.forward.ToString ();
			}
			else if (menuPanel.GetChild (i).name == "BackwardKey") 
			{
				menuPanel.GetChild (i).GetComponentInChildren<Text> ().text = GameManager.GM.backward.ToString ();
			}
			else if (menuPanel.GetChild (i).name == "LeftKey") 
			{
				menuPanel.GetChild (i).GetComponentInChildren<Text> ().text = GameManager.GM.left.ToString ();
			}
			else if (menuPanel.GetChild (i).name == "RightKey") 
			{
				menuPanel.GetChild (i).GetComponentInChildren<Text> ().text = GameManager.GM.right.ToString ();
			}
			else if (menuPanel.GetChild (i).name == "JumpKey") 
			{
				menuPanel.GetChild (i).GetComponentInChildren<Text> ().text = GameManager.GM.jump.ToString ();
			}
			else if (menuPanel.GetChild (i).name == "rotateRKey") 
			{
				menuPanel.GetChild (i).GetComponentInChildren<Text> ().text = GameManager.GM.rotxr.ToString ();
			}
			else if (menuPanel.GetChild (i).name == "rotateLKey") 
			{
				menuPanel.GetChild (i).GetComponentInChildren<Text> ().text = GameManager.GM.rotxl.ToString ();
			}

			 
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Tab) && !menuPanel.gameObject.activeSelf) {
			//Pause game
			PauseGame ();
			menuPanel.gameObject.SetActive (true);
			crossHair.gameObject.SetActive (false);
		} else if (Input.GetKeyDown (KeyCode.Tab) && menuPanel.gameObject.activeSelf) {
			//unpause game
			ContinueGame ();
			menuPanel.gameObject.SetActive (false);
			crossHair.gameObject.SetActive (true);
		} 


	}

	void OnGUI()
	{
		keyEvent = Event.current;

		if (keyEvent.isKey && waitingForKey) 
		{
			newKey = keyEvent.keyCode;
			waitingForKey = false;
		}
	}

	public void StartAssignment (string keyName)
	{
		if (!waitingForKey) 
		{
			StartCoroutine (AssignKey (keyName));
		}
	}

	public void SendText(Text text)
	{
		buttonText = text;
	}

	IEnumerator WaitForKey()
	{
		while (!keyEvent.isKey) 
		{
			yield return null;
		}
	}

	public IEnumerator AssignKey(string keyName)
	{
		waitingForKey = true;

		yield return WaitForKey ();

		switch (keyName) 
		{
		case "forward":
			GameManager.GM.forward = newKey;
			buttonText.text = GameManager.GM.forward.ToString ();
			PlayerPrefs.SetString ("forwardKey", GameManager.GM.forward.ToString ());
			break;
		case "backward":
			GameManager.GM.backward = newKey;
			buttonText.text = GameManager.GM.backward.ToString ();
			PlayerPrefs.SetString ("backwardKey", GameManager.GM.backward.ToString ());
			break;
		case "left":
			GameManager.GM.left = newKey;
			buttonText.text = GameManager.GM.left.ToString ();
			PlayerPrefs.SetString ("leftKey", GameManager.GM.left.ToString ());
			break;
		case "right":
			GameManager.GM.right = newKey;
			buttonText.text = GameManager.GM.right.ToString ();
			PlayerPrefs.SetString ("rightKey", GameManager.GM.right.ToString ());
			break;
		case "jump":
			GameManager.GM.jump = newKey;
			buttonText.text = GameManager.GM.jump.ToString ();
			PlayerPrefs.SetString ("jumpKey", GameManager.GM.jump.ToString ());
			break;
		case "rotxr":
			GameManager.GM.rotxr = newKey;
			buttonText.text = GameManager.GM.rotxr.ToString ();
			PlayerPrefs.SetString ("rotateRKey", GameManager.GM.rotxr.ToString ());
			break;
		case "rotxl":
			GameManager.GM.rotxl = newKey;
			buttonText.text = GameManager.GM.rotxl.ToString ();
			PlayerPrefs.SetString ("rotateLKey", GameManager.GM.rotxl.ToString ());
			break;
		}

		yield return null;
	}

	private void PauseGame()
	{
		Time.timeScale = 0;
		cameraLook.GetComponent<MouseLook> ().enabled = false;
	}

	private void ContinueGame()
	{
		Time.timeScale = 1;
		if (mouseCam == true) {
			cameraLook.GetComponent<MouseLook> ().enabled = true;
		}

	}

	public void CameraChoice()
	{
		
	}


	public void CameraMouse()
	{
		mouseCam = true;
		cameraLook.GetComponent<MouseLook> ().enabled = true;
		player.GetComponent<PlayerMove2> ().enabled = true;
		player.GetComponent<PlayerMovement> ().enabled = false;
	}

	public void CameraArrow()
	{
		mouseCam = false;
		cameraLook.GetComponent<MouseLook> ().enabled = false;
		player.GetComponent<PlayerMove2> ().enabled = false;
		player.GetComponent<PlayerMovement> ().enabled = true;
	}
}
