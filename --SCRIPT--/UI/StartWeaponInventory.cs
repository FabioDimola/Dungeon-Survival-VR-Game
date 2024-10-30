using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWeaponInventory : MonoBehaviour
{
    public GameObject swordBase;
    public GameObject asciaBase;

    private Vector3 startPosSword;
    private Vector3 startPosAscia;
    private bool isEnable = false;

    private void Awake()
    {
        startPosSword = swordBase.transform.position;
        startPosAscia = asciaBase.transform.position;
    }

    public void ActiveSword()
    {
        swordBase.SetActive(true);
        isEnable = true;
    }

    public void ActiveWeapon(GameObject go)
    {
        if(go.name == "AsciaBase")
        {
            swordBase.SetActive(false);
            asciaBase.SetActive(true);
        }
        if (go.name == "SwordBase")
        {
            swordBase.SetActive(true);
            asciaBase.SetActive(false);
        }
        

    }

    public void DeactiveGameObject(GameObject go)
    {
        if (go != null)
        {
            
            go.SetActive(false);
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "SwordBase")
        {
            swordBase.transform.position = startPosSword;
            swordBase.gameObject.SetActive(false);
        }
        if (other.gameObject.name == "AsciaBase")
        {
            asciaBase.transform.position= startPosAscia;
            asciaBase.gameObject.SetActive(false);

        }
    }
}
