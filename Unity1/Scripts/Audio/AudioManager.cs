using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
   public AudioClass[] sounds;
   public static AudioManager instance;

   void Awake()
   {
       if(instance == null)
       {
           instance = this;
       }
       else
       {
           Destroy(gameObject);
           return;
       }

       DontDestroyOnLoad(gameObject);

       foreach(AudioClass sVar in sounds)
       {
           sVar.source = gameObject.AddComponent<AudioSource>();
           sVar.source.clip = sVar.clip;
           sVar.source.volume = sVar.volume;
           sVar.source.pitch = sVar.pitch;
           sVar.source.loop = sVar.loop;
       }
   }

   void Start()
   {
       PlaySound("Theme");
   }

   public void PlaySound(string nameOfSound)
   {
       AudioClass track = Array.Find(sounds, soundItself => soundItself.Name == nameOfSound);
       if(track == null)
       {
           Debug.LogWarning("Sound: " + nameOfSound + " not found!");
           return;
       }
       track.source.Play();
   }
}
