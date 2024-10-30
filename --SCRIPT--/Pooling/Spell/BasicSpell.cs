using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSpell : MonoBehaviour
{

    //Pooling System timer




    //initialize the spell game object
    //virtual method could be overwritten by other script for personalize the various spell
    //not all spell do the same thing
    public virtual void Initialize(Transform spellShotPoint)
    {
        transform.position = spellShotPoint.position;
        transform.rotation = spellShotPoint.rotation;
    }

    

}
