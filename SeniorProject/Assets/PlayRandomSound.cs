using UnityEngine;
using System.Collections;

public class PlayRandomSound : MonoBehaviour {

    [SerializeField]
    AudioClip[] clips;

	// Use this for initialization
	void Start () {
        GetComponent<AudioSource>().PlayOneShot(clips[Random.Range(0, clips.Length - 1)]);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
