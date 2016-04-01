using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerBox : MonoBehaviour {

    [SerializeField]
    int playerIndex = 0;

    public List<GameObject>PlayerBoxList = new List<GameObject>();

    GameObject playerGO;

    [SerializeField]
    GameObject joinPrompt;

	// Use this for initialization
	void Start ()
    {
        joinPrompt.GetComponent<Image>().enabled = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        switch (playerIndex)
        {
            case 1:
                playerGO = GameObject.Find("Player1");
                break;
            case 2:
                playerGO = GameObject.Find("Player2");
                break;
            case 3:
                playerGO = GameObject.Find("Player3");
                break;
        }

        if (!playerGO.GetComponent<PlayerStats>().joined)
        {
            joinPrompt.GetComponent<Image>().enabled = true;
            foreach (GameObject go in PlayerBoxList)
            {
                if (go.GetComponent<Image>() != null)
                {
                    go.GetComponent<Image>().enabled = false;
                }
                else
                {
                    go.GetComponent<Text>().enabled = false;
                }
            }
        }
        else
        {
            foreach (GameObject go in PlayerBoxList)
            {
                if (go.GetComponent<Image>() != null)
                {
                    go.GetComponent<Image>().enabled = true;
                }
                else
                {
                    go.GetComponent<Text>().enabled = true;
                }


            }
            joinPrompt.GetComponent<Image>().enabled = false;
        }
    }
}
