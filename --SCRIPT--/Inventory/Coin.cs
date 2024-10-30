using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Item
{
    public AudioSource audioSource;

    private void Awake()
    {
        audioSource.Play();
    }
}
