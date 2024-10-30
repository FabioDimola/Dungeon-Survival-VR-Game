using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
  

    public float minTimeScale = 0.3f;
    public float sensitivity = 0.8f;
    private float initialTimeFixedDeltaTime;

    private GameObject player;





    private void Start()
    {
        initialTimeFixedDeltaTime = Time.fixedDeltaTime;
         player = GameObject.FindGameObjectWithTag("Player");

    }

    private void Update()
    {

       

        Time.fixedDeltaTime = initialTimeFixedDeltaTime;
    }


    public void LowTime()
    {
       
       
        Time.timeScale = Mathf.Clamp01(minTimeScale * sensitivity);
    }

    public void NormalTime()
    {
        Time.timeScale = 1;
    }


}





