using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {


    [SerializeField] int playerNum;

    float rotSpeed = 0.5f;

    Rigidbody2D rb;

    float horizontal;
    float vertical;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (playerNum == 1)
        {
            horizontal = Input.GetAxis("Horizontal2") * rotSpeed;
            vertical = Input.GetAxis("Vertical2") * rotSpeed;
        }else if(playerNum == 2)
        {
            horizontal = Input.GetAxis("P2Horizontal2") * rotSpeed;
            vertical = Input.GetAxis("P2Vertical2") * rotSpeed;
        }
        else if(playerNum == 3)
        {
            horizontal = Input.GetAxis("P3Horizontal2") * rotSpeed;
            vertical = Input.GetAxis("P3Vertical2") * rotSpeed;
        }

        Rotate();
    }

    void Rotate()
    {
        transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(vertical, horizontal) * 180 / Mathf.PI);
    }
}
