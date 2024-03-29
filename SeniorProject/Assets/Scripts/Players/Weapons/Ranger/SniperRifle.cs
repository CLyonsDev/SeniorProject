﻿using UnityEngine;
using System.Collections;

public class SniperRifle : MonoBehaviour {

    [SerializeField]
    GameObject bullet;

    [SerializeField]
    GameObject barrel;

    float shootTimer = 0;
    float rof = 1f;

    [SerializeField]
    AudioClip[] sounds;

    AudioSource aus;

    // Use this for initialization
    void Start ()
    {
        aus = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetAxis("P3Fire1") <= -1 && shootTimer >= rof)
        {
            Instantiate(bullet, barrel.transform.position, transform.localRotation);
            shootTimer = 0;
            aus.PlayOneShot(sounds[Random.Range(0, sounds.Length - 1)]);

        }
        if (shootTimer < rof)
        {
            shootTimer += Time.deltaTime;
        }
    }
}
