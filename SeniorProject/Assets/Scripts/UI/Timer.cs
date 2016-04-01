using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

    public float secO = 0;
    public float secT = 0;
    public float min = 0;

    [SerializeField]
    GameObject textGO;

    Text text;

	// Use this for initialization
	void Start () {
        text = textGO.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        text.text = min + ":" + secT + Mathf.Floor(secO);

        if (!GetComponent<GameManager>().gameOver)
        {
            if (GetComponent<GameManager>().started)
            {
                secO += Time.deltaTime;
            }

            if (secO >= 10)
            {
                secT++;
                secO = 0;
            }

            if (secT >= 6)
            {
                min++;
                secO = 0;
                secT = 0;
            }
        }
	}
}
