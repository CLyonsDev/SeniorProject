using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CameraZoomFollow : MonoBehaviour
{
    [SerializeField] float Padding = 1;
    List<GameObject> Players = new List<GameObject>();

    public void Start()
    {
	}

	private Rect GetBounds() //Getting the boundaries of out camera
	{
		float minx = float.MaxValue; //Left
		float miny = float.MaxValue; //Right
		float maxx = float.MinValue; //Top
		float maxy = float.MinValue; //Bottom

		for (int i = 0; i < Players.Count; i++) {
			minx = Mathf.Min (minx, Players[i].transform.position.x);
			miny = Mathf.Min (miny, Players[i].transform.position.y);
			maxx = Mathf.Max (maxx, Players[i].transform.position.x);
			maxy = Mathf.Max (maxy, Players[i].transform.position.y);
		}

		Rect bounds = new Rect (minx - Padding / 2f, maxy + Padding / 2f, maxx - minx + Padding, maxy - miny + Padding);
			
		return bounds;
	}

	public void Update()
	{
        GameObject[] allPlayers = GameObject.FindGameObjectsWithTag("Player");
        Players.Clear();
        foreach (GameObject go in allPlayers)
        {
            if(go.GetComponent<PlayerStats>().joined)
            {
                Players.Add(go); //Gets all players
            }
        }

        if(Players.Count > 0)
        {
            Rect bounds = GetBounds();

            float height = bounds.height * 100;
            float width = bounds.width * 100;

            float w = Screen.width / width;
            float h = Screen.height / height;

            float ratio = w / h;

            float size = (height / 2) / 100f;

            if (w < h)
                size /= ratio;

            Camera.main.orthographicSize = size;

            Vector2 position = bounds.position + new Vector2(bounds.width / 2f, -bounds.height / 2f); ;

            Vector3 camPosition = position;
            Vector3 point = Camera.main.WorldToViewportPoint(camPosition);
            Vector3 delta = camPosition - Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
            Vector3 destination = transform.position + delta;

            transform.position = destination;
        }   
	}



}
