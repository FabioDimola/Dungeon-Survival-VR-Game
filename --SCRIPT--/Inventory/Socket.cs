using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socket : MonoBehaviour
{
    [SerializeField] SocketSize _socketSize;


    public SocketSize GetSocketSize()
    {
        return _socketSize; 
    }

    
}
