using UnityEngine;
using System.Collections;

public class HammerSwing : MonoBehaviour {

    [SerializeField] GameObject pivotPoint;
    [SerializeField] GameObject hammer;
    [SerializeField] GameObject particleSpawner;

    ParticleSystem ps;

    Quaternion swing;
    Vector3 currentAngle;

    float lerpRate = 9.5f;

    float shootTimer = 0;
    float rof = 0.5f;

    public bool swinging = false;

    bool swingLeft = false;

    [SerializeField]
    AudioClip[] sounds;

    AudioSource aus;

    // Use this for initialization
    void Start ()
    {
        currentAngle = transform.eulerAngles;
        swing = new Quaternion(0, 0, 90, 0);
        ps = particleSpawner.GetComponent<ParticleSystem>();

        aus = GetComponent<AudioSource>();
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("P2Fire1") <= -0.35f && shootTimer >= rof && !swinging)
        {
            shootTimer = 0;
            aus.PlayOneShot(sounds[Random.Range(0, sounds.Length - 1)]);

            swinging = true;
        }
        if (shootTimer < rof)
        {
            shootTimer += Time.deltaTime;
        }

        if(swinging)
        {

            ps.Play();

            if (swingLeft)
            {
                swing = new Quaternion(0, 0, -25, 0);
                if (currentAngle.z <= -24.5)
                {
                    StopSwing();
                }

            }
            else
            {
                swing = new Quaternion(0, 0, 125, 0);
                if (currentAngle.z >= 124.5f)
                {
                    StopSwing();
                }
            }
            currentAngle = new Vector3(
                Mathf.LerpAngle(currentAngle.x, swing.x, lerpRate * Time.deltaTime),
                Mathf.LerpAngle(currentAngle.y, swing.y, lerpRate * Time.deltaTime),
                Mathf.LerpAngle(currentAngle.z, swing.z, lerpRate * Time.deltaTime));

            pivotPoint.transform.localEulerAngles = currentAngle;

            //Debug.Log(currentAngle);
            //Debug.Log(Mathf.DeltaAngle(currentAngle., swing.eulerAngles))
        }
    }

    void StopSwing()
    {
        ps.Stop();
        swinging = false;
        swingLeft = !swingLeft;
    }
}
