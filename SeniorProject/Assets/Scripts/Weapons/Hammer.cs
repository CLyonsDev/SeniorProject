using UnityEngine;
using System.Collections;

public class Hammer : MonoBehaviour
{
    [SerializeField]
    GameObject particleSpawner;
    ParticleSystem ps;

    float damage = 50;

    void Start()
    {
        ps = particleSpawner.GetComponent<ParticleSystem>();
        ps.startLifetime = ps.startLifetime;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(transform.parent.transform.parent.GetComponent<HammerSwing>().swinging)
        {
            ps.Play();
            //coll.gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * 25, ForceMode2D.Impulse);
            if (coll.gameObject.tag == "Enemy")
            {
                coll.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
                coll.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 2000, ForceMode2D.Impulse);
            }
            if (coll.gameObject.tag == "Portal")
            {
                coll.gameObject.GetComponent<PortalHealth>().TakeDamage(damage);
            }
        }
    }
}
