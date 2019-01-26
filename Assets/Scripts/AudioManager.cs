﻿using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public Sound[] sounds;

	// Use this for initialization
	void Awake () {
		
        foreach (Sound sound in sounds)
        {
           sound.source = gameObject.AddComponent<AudioSource>();
           sound.source.clip = sound.clip;

           sound.source.volume = sound.volume;
           sound.source.pitch = sound.pitch;
        }

	}

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        
        s.source.Play();
    }

    public void ChangePitch(string name, float pitch)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.pitch = pitch;

    }

    // Update is called once per frame
    void Update () {
		
	}
}
