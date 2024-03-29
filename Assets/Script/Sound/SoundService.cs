using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ShopInventory.Sound
{
    public class SoundService
    {
        private SoundSO soundScriptableObject;
        private AudioSource audioEffects;
        private AudioSource backgroundMusic;

        public SoundService(SoundModel model)
        {
            this.soundScriptableObject = model.SoundSO;
            this.audioEffects = model.AudioEffects;
            this.backgroundMusic = model.BackgroundMusic;
            PlaybackgroundMusic(SoundType.BackgroundMusic, true);
        }

        public void PlaySoundEffects(SoundType soundType, bool loopSound = false)
        {
            AudioClip clip = GetSoundClip(soundType);
            if (clip != null)
            {
                audioEffects.loop = loopSound;
                audioEffects.clip = clip;
                audioEffects.PlayOneShot(clip);
            }
            else
                Debug.LogError("No Audio Clip selected.");
        }

        private void PlaybackgroundMusic(SoundType soundType, bool loopSound = false)
        {
            AudioClip clip = GetSoundClip(soundType);
            if (clip != null)
            {
                backgroundMusic.loop = loopSound;
                backgroundMusic.clip = clip;
                backgroundMusic.Play();
            }
            else
                Debug.LogError("No Audio Clip selected.");
        }

        private AudioClip GetSoundClip(SoundType soundType)
        {
            Sounds sound = Array.Find(soundScriptableObject.audioList, item => item.soundType == soundType);
            if (sound.audio != null)
                return sound.audio;
            return null;
        }
    }
}