using UnityEngine;
using System.Collections;

public class PlaceholderPathfinding : MonoBehaviour {

    GameObject[] players;

    public GameObject target;

    [SerializeField]
    float speed = 0.25f;
    [SerializeField]
    float rotSpeed = 25f;
    [SerializeField]
    float stopDistance = 2f;

    public float dist;

	// Use this for initialization
	void Start ()
    {

	}

    // Update is called once per frame
    void Update ()
    {
        if (target != null && !target.GetComponent<PlayerStats>().dead)
        {
            dist = Vector2.Distance(transform.position, target.transform.position);

            if (dist > stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            }
            FacePlayer();
        }
        else
        {
            target = GetClosestPlayer();
        } 
    }

    GameObject GetClosestPlayer()
    {

        players = GameObject.FindGameObjectsWithTag("Player");

        float minDistance = 9999999;

        foreach(GameObject go in players)
        {
            if(Vector2.Distance(transform.position, go.transform.position) < minDistance && !go.GetComponent<PlayerStats>().dead)
            {
                minDistance = Vector2.Distance(transform.position, go.transform.position);
                target = go;
            }
        }

        return target;
    }

    void FacePlayer()
    {
        Vector3 vectorToTarget = target.transform.position - transform.position;
        float angle = (Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg) - 90;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
    }
}
