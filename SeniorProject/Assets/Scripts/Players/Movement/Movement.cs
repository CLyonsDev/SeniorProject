using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    [SerializeField] int playerNum;

    [SerializeField] float speed = 0.05f;

    Rigidbody2D rb;

    Vector2 dx;
    Vector2 dy;
    

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        MovePlayer();

        if (playerNum == 1)
        {
            dx = Vector2.right * Input.GetAxis("Horizontal") * speed;
            dy = Vector2.up * Input.GetAxis("Vertical") * speed;
        }
        else if (playerNum == 2)
        {
            dx = Vector2.right * Input.GetAxis("P2Horizontal") * speed;
            dy = Vector2.up * Input.GetAxis("P2Vertical") * speed;
        }
        else if (playerNum == 3)
        {
            dx = Vector2.right * Input.GetAxis("P3Horizontal") * speed;
            dy = Vector2.up * Input.GetAxis("P3Vertical") * speed;
        }
    }

    void MovePlayer()
    {
        rb.transform.Translate(dx, Space.World);
        rb.transform.Translate(dy, Space.World);
    }
}
