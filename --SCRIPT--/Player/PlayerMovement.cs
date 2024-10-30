using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  //  [SerializeField] Transform targetJump;

  //  [Header("Ground check Settings")]
 //   [SerializeField] private LayerMask _groundCheckMask; //layer su cui agisce la sfera che determina collisione terreno serve per escludere il collider dal player
 //   [SerializeField] private float _groundCheckRadius; //raggio sfera
 //   [SerializeField] private Vector3 _groundCheckOffset;

    [SerializeField] float JumpHeight = 0.5f;
    private float gravity = Physics.gravity.y;

    CharacterController _characterController;

  
    public bool isJumping = false;
    private Vector3 movement;
    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
      
       
    }

    private void Update()
    {
        //isGrounded = CheckIsGrounded();
        
        if(isJumping)
        {
            Jump();
          
        }

       
        movement.y += gravity * Time.deltaTime;
        _characterController.Move(movement * Time.deltaTime);


    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "RuneJump")
        {
           
            // StartCoroutine( StartJump());
            isJumping = true;
            Debug.Log("Jump");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "RuneJump")
        {
           
           
            // StartCoroutine( StartJump());
            isJumping = false;
            
            other.gameObject.SetActive(false);
        }
    }

    IEnumerator StartJump()
    {
        isJumping = true;
        yield return new WaitForSeconds(0.15f);
        isJumping = false;
        StopCoroutine(StartJump());
    }


    public void ThumbsUpJump()
    {
      // if (!isJumping)
        //{
            StartCoroutine(StartJump());
       // }
    }

    public void DebugInfo()
    {
        Debug.Log("Thumbs down");
        isJumping = false;
    }



  /*  private bool CheckIsGrounded()
    {
       return  Physics.CheckSphere(transform.TransformPoint(_groundCheckOffset), _groundCheckRadius, _groundCheckMask);
        
    }*/

    // Sei il giocatore e' a terra e utilizza input jump -> rb enable, balisticJump
    // Quando atterra -> rb disable, 

    public void Jump()
    {
        //isJumping = true;
         movement.y += Mathf.Sqrt(JumpHeight * -3 * gravity);
        //movement.z += 5;

       
    }


}
