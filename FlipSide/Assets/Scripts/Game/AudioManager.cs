using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    
    public Sound[] sounds;
    public int background;

    void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = this.gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        
    }

    void Start()
    {
        if(!Options.mute)
            play(sounds[background].name);
    }

    void Update()
    {

        foreach (Sound s in sounds)
        {
            if(Options.mute)
                s.source.volume = 0;
            else
                s.source.volume = Options.volume;

        }
    }


    public void play(string soundName)
    {
        if (Options.mute)
            return;

        Sound s =  Array.Find(sounds, sound => sound.name == soundName);
        if (s == null)
        {
            Debug.LogWarning("Sound name " + soundName + " Does not exist!");
            return;
        }
        s.source.Play();
    }


    public void stop(string soundName)
    {
        Sound s = Array.Find(sounds, sound => sound.name == soundName);
        if (s == null)
        {
            Debug.LogWarning("Sound name " + soundName + " Does not exist!");
            return;
        }
        s.source.Stop();
    }
}
