using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager 
{
    public enum Sound
    {
        EnemyHit,
        PunchHit,
        EnemyDead,
        EnemyWalk
    }
   
    public static void PlaySound(Sound sound)
    {
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
       // audioSource.PlayOneShot(GetAudioClip(sound));
    }

  /*  private static AudioClip GetAudioClip(Sound sound)
    {
        foreach(AudioAsset.SoundAudioClip soundAudioClip in AudioAsset.Instance.soundAudioClipArray)
        {
            if(soundAudioClip.sound == sound)
            {
                return soundAudioClip.audioClip;
            }
        }
        Debug.LogError("Sound "+sound.ToString()+" not found");
        return null;
    }

    */
}
