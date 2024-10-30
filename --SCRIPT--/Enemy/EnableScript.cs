using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableScript : MonoBehaviour
{
    //only for skeleton soldier
    public Enemy enemyScript;

    private void Awake()
    {
        
    }
    public void ActiveScript()
    {
        enemyScript.enabled = true;
        Debug.Log("Active");
    }

}
