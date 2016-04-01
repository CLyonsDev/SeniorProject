using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    [SerializeField]
    float maxHealth = 100;
    float health;

    [SerializeField]
    GameObject soundPlayer;

	// Use this for initialization
	void Start ()
    {
        health = maxHealth;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void TakeDamage(float damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Instantiate(soundPlayer, transform.position, transform.rotation);
            GameObject.Find("Game Manager").GetComponent<ScoreManager>().enemiesKilled++;
            Destroy(gameObject);
        }
    }
}
