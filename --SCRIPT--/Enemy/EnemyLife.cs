using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    //Script for the enemy life
    //one hit -> Damage
    //second hit -> Dead

    private float currentHealth;
    private float maxHealth;

    private void Start()
    {
        currentHealth = maxHealth;

    }

}
