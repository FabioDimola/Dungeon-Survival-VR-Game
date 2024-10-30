using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
  private static AIManager _instance;

    public static AIManager Instance
    {
        get
        {
            return _instance;
        }
        private set
        {
            _instance = value;
        }
    }



    public Transform target;
    public float radiusTarget = 5f;
    public List<Enemy> Enemies = new List<Enemy>();

    private void Awake()
    {
            if(Instance != null)
        {
            Instance = this;

        }

            Destroy(gameObject);
    }


  

}
