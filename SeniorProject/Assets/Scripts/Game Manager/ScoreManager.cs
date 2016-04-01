using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    public int enemiesKilled = 0;
    public int portalsDestroyed = 0;
    int score = 0;

    GameManager gm;
    Timer t;

    // Use this for initialization
    void Start () {
        gm = GetComponent<GameManager>();
        t = GetComponent<Timer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public int CalculateScore()
    {
        score += enemiesKilled * 250;
        score += portalsDestroyed * 700;

        int msecO = (int)t.secO;
        int msecT = (int)t.secT;
        int mmin = (int)t.min;

        return (score + ((gm.PlayerList.Count - gm.deadPlayers) * 3500) + (480 - (msecO + (msecT * 10)) + (mmin * 60)));
    }
}
