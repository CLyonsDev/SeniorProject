using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    [SerializeField] float speed = 1300f;

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
        Destroy(gameObject);
    }

    IEnumerator DespawnBullet()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
