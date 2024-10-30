using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionEnterDeath : MonoBehaviour
{

    public string[] targetTag;
    public Enemy enemy;


    Collider collider;


    //Audio
   /// public AudioClip punchAttack;
   // public AudioSource audioSource;
    private void Awake()
    {
        enemy = GetComponentInParent<Enemy>();
        
        collider = GetComponent<Collider>();
        collider.isTrigger = true;
    }
    

    private void OnTriggerEnter(Collider collision)
    {
        for (int i = 0; i < targetTag.Length; i++)
        {
            //se voglio differenziare in base al colpo devo farlo qui
            if (collision.gameObject.tag == targetTag[i])
            {
                 enemy.Dead(collision.transform.position);
                collider.isTrigger = false;
                Debug.Log("Colpito");
               
   
            }
        }

        if(collision.gameObject.tag == "EnergyPunch")
        {
            // audioSource.PlayOneShot(OnCollisionEnterDeath.);
            //SoundManager.PlaySound(SoundManager.Sound.PunchHit);
           
        }
        
    }
    



    IEnumerator StandUp()
    {
        yield return new WaitForSeconds(2f);
        enemy.animator.enabled = true;
        enemy.SetUpRaggDoll();
        enemy.agent.enabled =true;
        enemy.enabled=true;
       
    }
    /*

    private void OnCollisionEnter(Collision collision)
    {
        for(int i = 0;i < targetTag.Length;i++)
        {
            if(collision.gameObject.tag == targetTag[i])
            {
                enemy.currentHealth--;
                if (enemy.currentHealth <= 0)
                {
                  //  enemy.Dead(collision.transform.position);
                    enemy.Dead(collision.contacts[0].point);
                }
                else
                {
                    enemy.animator.SetTrigger("Hit");
                }

            }
        }
    }*/
}
