using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using PDollarGestureRecognizer;
public class MovementRecognizer : MonoBehaviour
{
    public Transform movementSource;
    public float newPositionThresholdDistance = 0.5f;
    public GameObject debugCubePrefab;
    public bool creationMode = true;
    public string newGestureName;
    public float recognizeTreshold = 0.9f;
    public List<PDollarGestureRecognizer.Gesture> trainingSet = new List<PDollarGestureRecognizer.Gesture>();

    public bool isMoving = false;
    private List<Vector3> positionList = new List<Vector3>();



    public void RecordGesture()
    {
        
            UpdateMovement();
    }


    public void StartMovement()
    {

        //start record new gesture
        isMoving = true;
        positionList.Clear();

        AddPointFromMovementSource();

    }



    //add debug cube for register the position of the movement
    void AddPointFromMovementSource()
    {
        positionList.Add(movementSource.position);
        if(debugCubePrefab != null )
        {
            GameObject spawnedDebugCube = Instantiate(debugCubePrefab,movementSource.position,Quaternion.identity);
            Destroy(spawnedDebugCube, 5f);
        }
    }


   void UpdateMovement()
    {
        Vector3 lastPosition = positionList[positionList.Count-1];

        //check if the position of the current and the last cube have a distance grater than the treshold
        if (Vector3.Distance(movementSource.position,lastPosition) > newPositionThresholdDistance)
        {

            //add point
            AddPointFromMovementSource();
        }

       


    }



    public string EndMovement()
    {
        isMoving = false;
        AddPointFromMovementSource();

       Point[] pointArray = new Point[positionList.Count];

        for(int i = 0; i< positionList.Count; i++)
        {
            Vector2 screenPoint = Camera.main.WorldToScreenPoint(positionList[i]);
            pointArray[i] = new Point(screenPoint.x,screenPoint.y,0);
        }


        PDollarGestureRecognizer.Gesture newGesture = new   PDollarGestureRecognizer.Gesture(pointArray);


        if (creationMode)
        {
            newGesture.Name = newGestureName;
            trainingSet.Add(newGesture);
            return null;
        }
        else
        {
            Result result = PointCloudRecognizer.Classify(newGesture, trainingSet.ToArray());

            if (result.Score > recognizeTreshold)
            {
                return result.GestureClass;

            }
            else
            {
                return null;
            }
        }
    }
}
