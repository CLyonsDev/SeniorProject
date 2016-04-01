using UnityEngine;
using System.Collections;

public class RangedAttack : MonoBehaviour {

    [SerializeField]
    GameObject projectile;

    float attackRate = 1f;
    float attackTimer = 0f;

    public bool canAttack = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(canAttack)
        {
            if (attackTimer < attackRate)
            {
                attackTimer += Time.deltaTime;
            }
            if (attackTimer >= attackRate)
            {
                attackTimer = 0;
                ShootProjectile();
            }
        }        
	}

    void ShootProjectile()
    {
        Instantiate(projectile, transform.position, transform.rotation);
    }
}
