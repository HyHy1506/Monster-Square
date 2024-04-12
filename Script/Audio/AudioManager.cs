using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sounds[] sounds;
    public static AudioManager instance;

    void Awake()
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
       
        foreach (Sounds s in sounds)
        {
          s.source=  gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    
    public void Play(string name)
    {
       Sounds s= Array.Find(sounds, sound => sound.name == name);
        if(s==null)
        {
            Debug.LogWarning("sound name " + name + " not exist");
            return;
        }
        
        s.source.Play();
    }
    private void Start()
    {

       
    }

    public void DisPlay(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("sound name " + name + " not exist");
            return;
        }
       
        s.source.Stop();
    }
    private void Update()
    {
        sounds[0].source.volume = DataPlayer.GetMusic();
        sounds[1].source.volume = DataPlayer.GetMusic();
        foreach(Sounds s in sounds) 
        {
            if(s.name!="BackGround" && s.name!= "StartBefore")
            {
               s.source.volume= DataPlayer.GetSoundEffect();
            }
        }
    }
}
