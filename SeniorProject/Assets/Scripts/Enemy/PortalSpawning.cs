using UnityEngine;
using System.Collections;

public class PortalSpawning : MonoBehaviour {

    [SerializeField]
    GameObject[] enemies;

    [SerializeField]
    GameObject[] players;

    int spawnNum = 6;

    float spawnRate = 7f;
    float timer = 0;

    float spawnRange = 10f;

    bool canSpawn;

    Vector2 portalLoc;

	// Use this for initialization
	void Start ()
    {
        portalLoc = transform.position;
        players = GameObject.FindGameObjectsWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;

        foreach(GameObject go in players)
        {
            if(Vector2.Distance(transform.position, go.transform.position) <= spawnRange)
            {
                Debug.Log(Vector2.Distance(transform.position, go.transform.position));
                canSpawn = true;
            }
        }

        if (canSpawn)
        {
            if (timer >= spawnRate)
            {
                SpawnEnemies();
                timer = 0;
            }
        }
	}

    void SpawnEnemies()
    {
        for(int i = 0; i < spawnNum; i++)
        {
            switch (i)
            {
                case 0:
                    Instantiate(enemies[0], portalLoc, Quaternion.identity);
                    break;
                case 1:
                    Instantiate(enemies[0], new Vector2(portalLoc.x + 0.5f, portalLoc.y), Quaternion.identity);
                    break;
                case 2:
                    Instantiate(enemies[0], new Vector2(portalLoc.x, portalLoc.y + 0.5f), Quaternion.identity);
                    break;
                case 3:
                    Instantiate(enemies[0], new Vector2(portalLoc.x, portalLoc.y - 0.5f), Quaternion.identity);
                    break;
                case 4:
                    Instantiate(enemies[0], new Vector2(portalLoc.x - 0.5f, portalLoc.y), Quaternion.identity);
                    break;
                case 5:
                    Instantiate(enemies[1], new Vector2(portalLoc.x - 0.75f, portalLoc.y + 0.75f), Quaternion.identity);
                    break;
            }
        }
    }
}
