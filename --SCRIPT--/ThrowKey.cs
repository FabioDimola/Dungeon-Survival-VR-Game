using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowKey : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject key;
    PointManager pointManager;
    Enemy enemy;
    PlayerHealth player;

    public int pointMax = 150;
    private void Start()
    {
        pointManager = FindFirstObjectByType<PointManager>();  
        player = GameObject.FindFirstObjectByType<PlayerHealth>();
        enemy = GetComponent<Enemy>();
    }
    // Update is called once per frame
    void Update()
    {
        if( enemy.isDeath)
        {
            ThrowObject();
            Destroy(this.gameObject, 4f);
        }
        
    }

    //only ghost
    public void ThrowObject()
    {
       

        // separate the object from the parent
        key.transform.parent = null;
        key.SetActive(true);
       // float distance = Vector3.Distance(player.gameObject.transform.position, key.transform.position);
        Rigidbody rb = key.GetComponent<Rigidbody>();
       // if (distance > )
       // {
            rb.velocity = BalisticVelocity(key.transform.position, player.transform.position, 65);
            rb.angularVelocity = Vector3.zero;
      //  }

    }



    //only ghost
    Vector3 BalisticVelocity(Vector3 source, Vector3 target, float angle)
    {
        Vector3 direction = target - source;
        float h = direction.y;
        direction.y = 0;
        float distance = direction.magnitude;
        float a = angle * Mathf.Deg2Rad;
        direction.y = distance * Mathf.Tan(a);
        distance += h / Mathf.Tan(a);

        //Calculate the velocity
        float velocity = Mathf.Sqrt(distance * Physics.gravity.magnitude / Mathf.Sin(2 * a));
        return velocity * direction.normalized;
    }
}
