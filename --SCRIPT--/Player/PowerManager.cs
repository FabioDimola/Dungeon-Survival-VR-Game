using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerManager : MonoBehaviour
{
    PlayerHealth playerHealth;
    
    private void Awake()
    {
        playerHealth = FindFirstObjectByType<PlayerHealth>();
    }



    public void ActiveEnergyPunch(GameObject energyPunch)
    {
        if(playerHealth != null)
        {
            if(playerHealth.isPowerUp)
            {
                energyPunch.SetActive(true);
                playerHealth.isPowerUp = false;
            }
        }
    }
}
