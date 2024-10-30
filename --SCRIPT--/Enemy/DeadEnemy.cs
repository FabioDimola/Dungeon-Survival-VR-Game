using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEnemy : MonoBehaviour
{
    Enemy enemy;
    Coroutine DeathCo;
    // Update is called once per frame
    PointManager pointManager;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        pointManager = FindFirstObjectByType<PointManager>();
        
    }
    void Update()
    {
       
        if(enemy.isDeath)
        {
           
            DeathCo = StartCoroutine(VFX_Death());
        }

        
    }

    IEnumerator VFX_Death()
    {
        yield return new WaitForSeconds(4f);
        
        EnemyPooling.Instance.ReturnToPool(enemy);
        enemy.isDeath = false;
        enemy.agent.enabled = true;
        enemy.currentHealth = enemy.maxHealth;
        enemy.enabled = true;
       
        enemy.DeactiveRagdoll();

        if (DeathCo != null)
            StopCoroutine(DeathCo);

    }











}
