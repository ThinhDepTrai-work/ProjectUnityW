using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constant;

public class AudioManager : MonoBehaviour
{
    public List<Sound> sounds;

    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (var sound in sounds)
        {
            sound.Source = gameObject.AddComponent<AudioSource>();
            sound.Source.clip = sound.Clip;
            sound.Source.pitch = sound.Pitch;
            sound.Source.volume = sound.Volume;
            sound.Source.loop = sound.Loop;
            sound.Source.outputAudioMixerGroup = sound.Output;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        PlaySound(SoundName.IntroTheme);
    }

    public void PlaySound(string name)
    {
        Sound sound = sounds.Find(s => s.Name == name);

        foreach (var playingSound in sounds)
        {
            playingSound.Source.Stop();
        }

        if (sound != null)
        {
            Debug.LogWarning($"There is no sound with sound name: {name}");
        }

        sound.Source.Play();
    }
}
