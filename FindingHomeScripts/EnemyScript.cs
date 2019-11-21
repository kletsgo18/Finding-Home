using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour {

	public static float enemyHealth = 100.0f;
	public TextMesh healthText;
	public string enemyHealthText = enemyHealth.ToString();

	// Use this for initialization
	void Start () {
		SetHealthText ();

		
	}
	
	// Update is called once per frame
	void Update () {
		if (enemyHealth != 100.0f) {
			SetHealthText ();
		}
		
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet1")
        {
            enemyHealth -= 20;
            Debug.Log("Enemy health: " + enemyHealth);
        }

        if (collision.gameObject.tag == "Bullet2")
        {
            enemyHealth -= 10;
            Debug.Log("Enemy health: " + enemyHealth);
        }

		if (enemyHealth <= 0) {
			Destroy (this.gameObject);
		}
    }

	void SetHealthText()
	{
		healthText.text = "" + enemyHealth;
	}
}
