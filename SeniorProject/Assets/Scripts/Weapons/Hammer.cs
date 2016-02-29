using UnityEngine;
using System.Collections;

public class Hammer : MonoBehaviour
{
    [SerializeField]
    GameObject particleSpawner;
    ParticleSystem ps;

    void Start()
    {
        ps = particleSpawner.GetComponent<ParticleSystem>();
        ps.startLifetime = ps.startLifetime;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(transform.parent.transform.parent.GetComponent<HammerSwing>().swinging)
        {
            ps.Play();
            //coll.gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * 25, ForceMode2D.Impulse);
            Destroy(coll.gameObject);
        }
    }
}
