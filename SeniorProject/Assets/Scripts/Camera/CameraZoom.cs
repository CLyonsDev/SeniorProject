using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraZoom : MonoBehaviour {

    [SerializeField] GameObject[] players;

    Camera cam;

    float increment = 0.25f;
    float zoomSpeed = 2f;

    bool growing = false;

    List<GameObject> playersExpanding = new List<GameObject>();

    // Use this for initialization
    void Start () {
        cam = GetComponent<Camera>();
        players = GameObject.FindGameObjectsWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        CheckPlayerLoc();
    }

    void CheckPlayerLoc()
    {
        foreach (GameObject go in players)
        {
            Vector2 playerPos = go.transform.position;

            if (playerPos.x > cam.orthographicSize * Screen.width / Screen.height && cam.orthographicSize <= 8f || playerPos.x < (cam.orthographicSize * Screen.width / Screen.height) / 2.0f)
            {
                cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, cam.orthographicSize + increment, zoomSpeed * Time.deltaTime);
                if(playersExpanding.Count <= 1)
                {
                    playersExpanding.Add(go);
                }
            }

            if (cam.orthographicSize > 5 && playersExpanding.Count > 0)
            {
                for (int i = 0; i < playersExpanding.Count; i++)
                {
                    Debug.Log(playersExpanding[i]);
                    if (playersExpanding[i].transform.position.x < cam.orthographicSize * Screen.width / Screen.height)
                    {
                        playersExpanding.Remove(playersExpanding[i]);
                    }
                }
            }

            if (playersExpanding.Count <= 0 && cam.orthographicSize >= 5)
            {
                cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, cam.orthographicSize - increment, zoomSpeed * Time.deltaTime);
                //Debug.Log("Shrinking");
            }
        }
    }
}
