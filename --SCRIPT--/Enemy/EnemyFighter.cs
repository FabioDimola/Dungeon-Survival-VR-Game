using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyFighter : Enemy
{


    public float damage = 15;



    float minStopDistance = 1.5f;
    public AudioSource stepAudio;

    OnCollisionEnterDeath[] onCollisionEnterDeath;

    [HideInInspector] public PlayerHealth healthPlayer;
    public override void Awake()
    {
        base.Awake();

        onCollisionEnterDeath = GetComponentsInChildren<OnCollisionEnterDeath>();
        stopDistance = minStopDistance;
        healthPlayer = GameObject.FindFirstObjectByType<PlayerHealth>().GetComponent<PlayerHealth>();
    }

   


    public void PlayStepAudio()
    {
        stepAudio.Play();
    }

    public void StopAudio()
    {
        stepAudio.Stop();
    }



    public virtual void TakeDamage()
    {
        if (distance <= 3)
        {
            healthPlayer.currentHealth -= damage;
            Health.instance.UpdateHealthBar(100, healthPlayer.currentHealth);
            Debug.Log("Take Damage Player");
        }
    }



}
