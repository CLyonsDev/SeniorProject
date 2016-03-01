using UnityEngine;
using System.Collections;

public class PlaceholderPathfinding : MonoBehaviour {

    GameObject target;

    [SerializeField]
    float speed = 0.25f;
    [SerializeField]
    float stopDistance = 2f;

	// Use this for initialization
	void Start ()
    {
        target = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Vector2.Distance(transform.position, target.transform.position) > stopDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
        transform.rotation = Quaternion.LookRotation(Vector3.forward, target.transform.position);
	}
}
