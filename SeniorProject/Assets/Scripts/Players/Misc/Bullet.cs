using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    [SerializeField] float speed = 1300f;
    [SerializeField] float damage = 15;

    Rigidbody2D rb;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up* speed);
        //StartCoroutine(DespawnBullet());
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Enemy" && this.gameObject.tag == "Player Projectile")
        {
            col.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
        }else if(col.gameObject.tag == "Portal" && this.gameObject.tag == "Player Projectile")
        {
            col.gameObject.GetComponent<PortalHealth>().TakeDamage(damage);
        }
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerStats>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }

    /*IEnumerator DespawnBullet()
    {
        if(!GetComponent<SpriteRenderer>().isVisible)
        {
            yield return new WaitForSeconds(.75f);
            Destroy(gameObject);
        }      
    }*/
}
