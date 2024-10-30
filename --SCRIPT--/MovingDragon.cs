using MalbersAnimations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovingDragon : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;

    public float speed = 20f; 

    public bool startFly = false;
    private int count = 0;
    public GameObject eggsPrefab;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
       

    }



    private void Update()
    {
       
    }


    private void FixedUpdate()
    {
        
        if (startFly)
        {
            animator.SetBool("StartFly", true);
            transform.position += Time.deltaTime * speed * transform.up;

            if(count ==0)
            {
                Instantiate(eggsPrefab, transform.position, Quaternion.identity);
                count++;
            }
            
        }

    }

  

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Hand")
        {
            startFly = true;
            
        }


        if(other.gameObject.tag == "LimitUp")
        {
            startFly = false;
            transform.position += Time.deltaTime * speed * transform.forward;
            animator.SetBool("StartFly", false);
           
           
        }

    }


}
