using UnityEngine;
using System.Collections;

public class HammerPos : MonoBehaviour {

    [SerializeField] GameObject PivotPoint;
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = PivotPoint.transform.position; 
	}
}
