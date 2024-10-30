using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class DestroySpell : MonoBehaviour
{
    public GameObject spell;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Sword")
        {
            spell.SetActive(false);
        }
    }
}
