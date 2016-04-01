using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectiveArrow : MonoBehaviour {

    List<GameObject> destArr = new List<GameObject>();

    public int destNum = 1;

    float speed = 25;

    Camera cam;

    public int defaultWidth = 1920, defaultHeight = 1080;
    public Vector3 scale;

    // Use this for initialization
    void Start ()
    {
        destArr.Add(GameObject.FindGameObjectWithTag("Objective 1"));
        destArr.Add(GameObject.FindGameObjectWithTag("Objective 2"));

        cam = Camera.main;

        scale = new Vector3(defaultWidth / Screen.width, defaultHeight / Screen.height, 1f);
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Scale arrow with screen size
        transform.localScale = Vector3.Scale(transform.localScale, scale);
        transform.position = Vector3.Scale(transform.position, scale);

        transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y+3, -30);
        RotateTowards();
	}

    void RotateTowards()
    {
        Vector3 vectorToTarget = destArr[destNum - 1].transform.position - transform.position;
        float angle = (Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg) -90;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
    }
}
