using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    private Enemy enemy;
   // public GameObject weapon;
    public GameObject VFX_death;
    Animator animator;

    Coroutine DeathCo;
    

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        animator = GetComponent<Animator>();
       
    }


    /*  private void Update()
      {
          if(enemy.isDeath)
          {

             DeathCo = StartCoroutine(VFX_Death());

          }


      }


      IEnumerator VFX_Death()
      {
          yield return new WaitForSeconds(4f);

          PoolingEnemy.Instance.ReturnToPool(enemy);
          enemy.isDeath = false;
          enemy.agent.enabled = true;
          enemy.enabled = true;
          animator.enabled = true;
          enemy.DeactiveRagdoll();

      }
     */



}
