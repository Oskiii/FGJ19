using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript2 : MonoBehaviour
{
    AudioSource myAudio;
    [SerializeField] AudioClip loopMusic;

    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
        Invoke("audioFinished", myAudio.clip.length -0.5f);
    }

    void audioFinished()
    {
        myAudio.clip = loopMusic;
        myAudio.loop = true;
        myAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
