using UnityEngine;
using System.Collections;

public class MeleeAttack : MonoBehaviour {

    [SerializeField]
    float stopDistance = 1.15f;

    float timer = 0f;
    float attackRate = 1f;

    bool canAttack = false;

    float damage = 3f;

    // Use this for initialization
    void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(GetComponent<PlaceholderPathfinding>().dist <= stopDistance)
        {
            if (timer < attackRate)
            {
                canAttack = false;
                timer += Time.deltaTime;
            }
            else
            {
                Attack();
                timer = 0;
            }
        }
	}

    void Attack()
    {
        GetComponent<PlaceholderPathfinding>().target.GetComponent<PlayerStats>().TakeDamage(damage);
    }
}
