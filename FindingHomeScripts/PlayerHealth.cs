using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
	public static float playerHealth = 100.0f;
	public bool collided = false;
	public float timeLeft = 10.0f;
	public Text pHealthText;
	public Image healthBar;
	public float enemyTime = 2.0f;

	// Use this for initialization
	void Start()
	{
		SetHealthText ();
	}

	// Update is called once per frame
	void Update()
	{
		SetTimer ();

		SetHealthText ();

		SetHealthBar ();

	}

	void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.tag == "Enemy") {
			//playerHealth -= 5;

			if (enemyTime == 2.0f) {
				timeLeft = 10.0f;
				collided = true;
				playerHealth -= 5;
			} else if (enemyTime < 2f) {
				enemyTime -= Time.deltaTime;
			}
			else if (enemyTime <= 0.0f) 
			{
				enemyTime = 2.0f;
			}
		}
	}

//		if (collision.gameObject.tag == "Enemy")
//		{
//			timeLeft = 10.0f;
//			collided = true;
//			playerHealth -= 5;
//		}
//	}

	void SetHealthText()
	{

		pHealthText.text = "" + playerHealth;

	}

	void SetHealthBar()
	{
		float ratio = (playerHealth / 100.0f);
		if (ratio >= 0) {
			healthBar.rectTransform.localScale = new Vector3 (ratio, 1, 1);
		}
	}

	void SetTimer()
	{
		if (collided)
		{
			if (playerHealth <= 100.0f)
			{
				timeLeft -= Time.deltaTime;
				if (timeLeft <= 0.0f)
				{
					playerHealth += 2;
					timeLeft = 2.0f;
				}
			}
			if(playerHealth >= 100.0f)
			{
				collided = false;
				playerHealth = 100.0f;
				timeLeft = 10.0f;
			}
		}
	}


}
