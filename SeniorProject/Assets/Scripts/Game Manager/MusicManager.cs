using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MusicManager : MonoBehaviour {

    [SerializeField]
    AudioClip[] soundtracks;

    AudioSource aus;

    bool gameStarted = false;

    [SerializeField]
    GameObject NowPlaying;

    int index = 99999;

	// Use this for initialization
	void Start ()
    {
        aus = GetComponent<AudioSource>();
        index = 0;
        aus.PlayOneShot(soundtracks[index]);
        aus.loop = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKeyDown(KeyCode.M))
        {
            aus.Stop();
            index = rand(0);
            aus.PlayOneShot(soundtracks[index]);
        }

        if(GetComponent<GameManager>().PlayerList.Count > 0 && !gameStarted)
        {
            aus.Stop();
            index = rand(index);
            aus.PlayOneShot(soundtracks[index]);
            gameStarted = true;
            aus.loop = false;
        }

        if(!aus.isPlaying)
        {
            index = rand(index);
            aus.PlayOneShot(soundtracks[index]);
        }

        NowPlaying.GetComponent<Text>().text = "Now Playing: " + soundtracks[index].name;
	}

    private int rand(int lastIndex)
    {
        int ret = 0;
        while(ret == lastIndex)
        {
            ret = Random.Range(1, soundtracks.Length - 1);
        }
        return(ret);
    }
}
