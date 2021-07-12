using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour {
    public AudioClip[] clips;
    private AudioSource audiosource;
    bool playing;

    // Use this for initialization
    void Start () 
    {
        DontDestroyOnLoad(gameObject);
        audiosource = FindObjectOfType<AudioSource>();
        audiosource.loop = false;
        playing = true;
    }

    // Update is called once per frame
    void Update () 
    {
        if (!audiosource.isPlaying)
        {
            audiosource.clip = GetrandomClip();
            audiosource.Play();
        }
    }
    private AudioClip GetrandomClip()
    {
        return clips[Random.Range(0, clips.Length)];
    }


}
