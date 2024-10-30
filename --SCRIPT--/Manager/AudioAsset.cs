using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioAsset : MonoBehaviour
{
  /*  public static AudioAsset Instance {  get; private set; }
    public SoundAudioClip[] soundAudioClipArray;

    [System.Serializable]
    public class SoundAudioClip
    {
        public SoundManager.Sound sound;
        public AudioClip audioClip;
    }
  */
    AudioSource audioSource;
    public AudioClip clip;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
         audioSource.PlayOneShot(clip);
            Debug.Log("Sound");
        }
    }
}
