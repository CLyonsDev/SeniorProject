﻿using UnityEngine;
using System.Collections;

public class CameraLocation : MonoBehaviour {

    [SerializeField] GameObject[] players;

    float lerpSpeed = 0.1f;

	// Use this for initialization
	void Start ()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        if (players.Length > 1)
        {
            transform.position = CalcCenter();
        }
        else
        {
            transform.position = players[0].transform.position;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(players.Length > 1)
        {
            transform.position = Vector2.Lerp(transform.position, CalcCenter(), lerpSpeed);
        }
        else
        {
            transform.position = Vector2.Lerp(transform.position, players[0].transform.position, lerpSpeed);
        }
        


	}

    Vector2 CalcCenter()
    {
        Vector2 center1 = new Vector2((players[0].transform.position.x - players[1].transform.position.x) * 0.5f + players[1].transform.position.x, (players[0].transform.position.y - players[1].transform.position.y) * 0.5f + players[1].transform.position.y);
        Vector2 center2 = new Vector2((center1.x - players[2].transform.position.x) * 0.5f + players[2].transform.position.x, (center1.y - players[2].transform.position.y) * 0.5f + players[2].transform.position.y);
        return (center2);
    }
}
