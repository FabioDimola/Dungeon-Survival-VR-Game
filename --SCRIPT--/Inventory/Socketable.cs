using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socketable : MonoBehaviour
{
    [SerializeField] SocketSize _itemSize;
    [SerializeField]  float _checkerSize;
    Rigidbody rb;

    private Vector3 startScale;
    public float fractionScale;

    public Vector3 offset;
    public Vector3 Rotation;
    public Vector3 PositionOffset;
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(offset + transform.position, _checkerSize);
    }


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        startScale = transform.localScale;
    }

    private bool CanFitInSocket(Socket socket)
    {
        return socket.GetSocketSize() > _itemSize;
    }

    private void TryToEnterSocket()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _checkerSize);

        foreach(Collider collider in colliders)
        {
            if (collider.TryGetComponent<Socket>(out Socket socket) && CanFitInSocket(socket) && socket.GetComponentInChildren<Socketable>()== null)
            {
                Debug.Log("Enter in socket");
                transform.parent = socket.transform;
                transform.localRotation = Quaternion.Euler(Rotation);
                transform.localPosition = Vector3.zero + PositionOffset;
                transform.localScale = Vector3.one/fractionScale;
               // rb.isKinematic = true;
              //  rb.useGravity = false;
                break;
            }
        }
    }

   

 
    public void OnGrabStart()
    {
       // rb.useGravity = true;
      //  rb.isKinematic = false;
        transform.SetParent(null);
        transform.localScale = startScale;
    }

    public void OnGrabEnd()
    {
        
        TryToEnterSocket();
    }
}
