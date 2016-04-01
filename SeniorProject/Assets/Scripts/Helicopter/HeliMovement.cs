using UnityEngine;
using System.Collections;

public class HeliMovement : MonoBehaviour {

    [SerializeField]
    float speed = 5f;

	// Use this for initialization
	void Start ()
    {
        //StartCoroutine(FlyOut());
        StartCoroutine(FlyIntro());
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator FlyIntro()
    {
        yield return new WaitForSeconds(7f);
        GetComponent<Rigidbody2D>().AddForce(Vector2.right * speed);
    }

    IEnumerator FlyOut()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.right * speed);
        yield return new WaitForSeconds(10f);
        GetComponent<Rigidbody2D>().AddForce(Vector2.right * speed);
    }
}
