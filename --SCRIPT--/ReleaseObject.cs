using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseObject : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    public float speed = 10;
    public float angularVelocity = 3;


    public Vector3 movingAxis;
    private Vector3 movingWorldAxis;
    private GameObject lookingPlayer;

    private void Start()
    {
       rb = GetComponent<Rigidbody>();
        lookingPlayer = GameObject.FindWithTag("Eye");

        Destroy(this.gameObject,15f);
        
    }

    private void FixedUpdate()
    {
        movingWorldAxis = lookingPlayer.transform.TransformDirection(movingAxis);
    }

    public void Throw()
    {
      
           

            if (rb != null)
            {
                rb.isKinematic = false;

            rb.velocity = movingWorldAxis * speed + Vector3.up * 2;
            
               
            }
      
           

          
     }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            PlayerHealth.instance.currentHealth -= 5f;
            Health.instance.UpdateHealthBar(100,PlayerHealth.instance.currentHealth);
        }
    }

}

