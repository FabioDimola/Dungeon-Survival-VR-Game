using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerWeapon : MonoBehaviour
{
    public float minTimeScale = 0.3f;
    public float sensitivity = 0.8f;
    private float initialTimeFixedDeltaTime;

    public float lowTimeDuration = 10f;
    private float timer = 0;
    public Enemy enemy;


    private void Start()
    {
        initialTimeFixedDeltaTime = Time.fixedDeltaTime * Time.timeScale;
    }

   /* private void Update()
    {

        if (enemy.isThrowing)
        {
            Time.timeScale = Mathf.Clamp01(minTimeScale * sensitivity);
            if (timer > lowTimeDuration)
            {
                Time.timeScale = 1;
                timer = 0;
                enemy.isThrowing = false;

            }
            timer += Time.deltaTime;
        }
    }*/
}
