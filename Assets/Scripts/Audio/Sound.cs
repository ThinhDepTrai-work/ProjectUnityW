using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[Serializable]
public class Sound
{
    public string Name;
    public AudioClip Clip;

    public AudioMixerGroup Output;

    [Range(0f, 1f)]
    public float Volume = 1;
    [Range(.01f, 3f)]
    public float Pitch = 1;
    public bool Loop = false;

    [HideInInspector]
    public AudioSource Source;

}
