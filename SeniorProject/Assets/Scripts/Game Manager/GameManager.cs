using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

public class GameManager : MonoBehaviour {

    [SerializeField]
    GameObject[] Players;
    [SerializeField]
    GameObject objArrow;

    public bool started = false;
    public bool victory = false;
    public bool gameOver = false;

    GameObject[] portals;
    int portalCount = 0;

    public int escapedPlayers = 0;
    public int deadPlayers = 0;

    public List<GameObject> PlayerList = new List<GameObject>();

    GameObject textGO;
    Text text;

    GameObject scoreGO;
    Text scoreTxt;

    // Use this for initialization
    void Start ()
    {
        Players = GameObject.FindGameObjectsWithTag("Player").OrderBy(go => go.name).ToArray(); //Never used this before, but didn't want to convert everything to GameObject Lists
        portals = GameObject.FindGameObjectsWithTag("Portal");
        foreach(GameObject go in portals)
        {
            portalCount++;
        }

        textGO = GameObject.Find("EventText");
        text = textGO.GetComponent<Text>();
        text.text = "";

        scoreGO = GameObject.Find("ScoreText");
        scoreTxt = scoreGO.GetComponent<Text>();
        scoreTxt.text = "";
	}
	
	// Update is called once per frame
	void Update ()
    {

        GameObject[] allPlayers = GameObject.FindGameObjectsWithTag("Player");
        PlayerList.Clear();
        foreach (GameObject go in allPlayers)
        {
            if (go.GetComponent<PlayerStats>().joined)
            {
                PlayerList.Add(go); //Gets all players
            }
        }

        if (Input.GetButtonDown("P1Join"))
        {
            if(!Players[0].GetComponent<PlayerStats>().joined)
            {
                Players[0].GetComponent<PlayerStats>().SwitchEnabled();
                Players[0].GetComponent<Shooting>().enabled = true;
                return;
            }
        }

        if (Input.GetButtonDown("P2Join"))
        {
            if (!Players[1].GetComponent<PlayerStats>().joined)
            {
                Players[1].transform.GetChild(0).transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
                Players[1].GetComponent<HammerSwing>().enabled = true;                
                Players[1].GetComponent<PlayerStats>().SwitchEnabled();
                return;
            }
        }

        if (Input.GetButtonDown("P3Join"))
        {
            if (!Players[2].GetComponent<PlayerStats>().joined)
            {
                Players[2].GetComponent<SniperRifle>().enabled = true;
                Players[2].GetComponent<PlayerStats>().SwitchEnabled();
                return;
            }
        }

       
    }

    void LateUpdate()
    {
        CheckPlayers();
    }

    public void PortalDeath()
    {
        portalCount--;
        if(portalCount <= 0)
        {
            victory = true;
            objArrow.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    void CheckPlayers()
    {
        if (escapedPlayers >= PlayerList.Count && victory && !gameOver)
        {
            gameOver = true;
            text.text = "All players have escaped!";
            scoreTxt.text = "Your team score was: " + GetComponent<ScoreManager>().CalculateScore();
        }

        if(deadPlayers >= PlayerList.Count && !victory && PlayerList.Count > 0)
        {
            gameOver = true;
            text.text = "All players have died! Restarting in 5 seconds...";
            StartCoroutine(RestartGame());
        }
    }

    public void PlayerEscape()
    {
        text.text = escapedPlayers + " players have escaped!";
        StartCoroutine(RestartGame());
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
