using UnityEngine;
using System.Collections;


public class MusicScript : MonoBehaviour
{
    AudioSource myAudio;

    // Use this for initialization
    void Start()
    {

        myAudio = GetComponent<AudioSource>();
        Invoke("audioFinished", myAudio.clip.length);

    }

    void audioFinished()
    {
        Debug.Log("Audio Finished");
    }
}