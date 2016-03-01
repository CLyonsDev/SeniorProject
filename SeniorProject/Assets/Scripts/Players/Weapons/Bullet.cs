using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    [SerializeField] float speed = 1300f;
    [SerializeField] float damage = 25;

    Rigidbody2D rb;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up* speed);
        StartCoroutine(DespawnBullet());
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
        }

        Destroy(gameObject);
    }

    IEnumerator DespawnBullet()
    {
        if(!GetComponent<Renderer>().isVisible)
        {
            yield return new WaitForSeconds(.75f);
            Destroy(gameObject);
        }      
    }
}
