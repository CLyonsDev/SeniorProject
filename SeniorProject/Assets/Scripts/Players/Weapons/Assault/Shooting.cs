using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

    [SerializeField] GameObject bullet;
    [SerializeField] Transform barrel;

    float shootTimer = 0;
    float rof = 0.15f;
	
    void Start()
    {

    }

	// Update is called once per frame
	void Update ()
    {
        if(Input.GetAxis("Fire1") <= -1 && shootTimer >= rof)
        {
            Instantiate(bullet, barrel.transform.position, transform.localRotation);
            shootTimer = 0;
        }

        if(shootTimer < rof)
        {
            shootTimer += Time.deltaTime;
        }
	}
}
