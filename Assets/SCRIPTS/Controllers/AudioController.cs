using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public class AudioController 
    {
       private AudioYB sounds;
       private AudioYB fon;

       private string nameMusic;

        public AudioController(AudioYB sounds, AudioYB fon, string nameMusic)
        {
            this.sounds = sounds;
            this.fon = fon;
            this.nameMusic = nameMusic;
        }

        public void PlaySpawn() => sounds.PlayOneShot("Spawn", 0.75f);
        
        public void PlayMusic() => fon.Play(nameMusic);
        
        public void PlayJump() => sounds.PlayOneShot("Jump", 0.75f);
        
    }
}
