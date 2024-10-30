using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCellDoor1 : MonoBehaviour
{
    public Animator cellDoor1;
    public Animator cellDoor2;

   
    PointManager pointManager;
    // Start is called before the first frame update
    void Start()
    {
        pointManager = FindFirstObjectByType<PointManager>();
        cellDoor1.enabled = false;
        cellDoor2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(pointManager.point >=20 && pointManager.key >= 1)
        {
            cellDoor1.enabled = true;
        }
        if (pointManager.point >= 200 && pointManager.key >= 2)
        {
            cellDoor2.enabled = true;
        }
    }
}
