using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public struct Gesture
{
    public string name; //name of the pose
    public List<Vector3> fingerDatas; //position of the finger bones
    public UnityEvent onRecognize; //event for recongnize of the gesture

}


public class GestureDetector : MonoBehaviour
{
    public OVRSkeleton skeleton;
    public List<Gesture> gestures;
    public bool debugMode = true;
    private List<OVRBone> fingerBones; // we get information about the finger

    private void Start()
    {
        fingerBones = new List<OVRBone>(skeleton.Bones); // insert in the list all the skeleton information
    }

    private void Update()
    {
        if(debugMode && Input.GetKeyDown(KeyCode.Space))
        {
            SaveGesture();
        }
    }


    void SaveGesture()
    {
        Gesture g = new Gesture();
        g.name = "New Gesture";
        List<Vector3> data = new List<Vector3>();

        foreach (var bone in fingerBones)
        {
            //we can compare a gesture with local positiom, local rotation, flex of the finger, distance between them 
            //I use the finger position relative to root (both position and rotate)
            data.Add(skeleton.transform.InverseTransformPoint(bone.Transform.position));
        }

        g.fingerDatas = data;
        gestures.Add(g);
    }
}
