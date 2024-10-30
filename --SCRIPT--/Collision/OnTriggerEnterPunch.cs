using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnterPunch : MonoBehaviour
{
    private PointManager pointManager;

    public AudioSource audioSource;
    public AudioSource GoblinHit;
    public AudioSource PigHit;
    private void Start()
    {

        pointManager = GameObject.FindFirstObjectByType<PointManager>().GetComponent<PointManager>();
        
    }


    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.name)
        {

            case "Hips":
                pointManager.point += 10;
                audioSource.Play();
                pointManager.UpdatePointScored();
               
                break;
            case "Neck":
                pointManager.point += 15;
                audioSource.Play();
                pointManager.UpdatePointScored();
                
                break;
            case "Spine_01":
                pointManager.point += 10;
                audioSource.Play();
                pointManager.UpdatePointScored();
               
                break;

        }

      /*  if(other.gameObject.GetComponentInParent<Enemy>().EnemyType.ToString() == "Goblin")
        {
            GoblinHit.Play();
        }

        if (other.gameObject.GetComponentInParent<Enemy>().EnemyType.ToString() == "Orc")
        {
            PigHit.Play();
        }
      */
        pointManager.UpdatePointScored();
    }

}
