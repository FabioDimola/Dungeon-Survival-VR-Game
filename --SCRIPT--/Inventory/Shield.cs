using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Item
{
    private int countDifense = 0;
    // ShieldPoolingManager poolManager;
    public GameObject explosionVFX;
    private Coroutine _disableCo;
    private Coroutine _disableVFX;

    public float maxDuration = 80f;
    private Coroutine _disablePropsCo;
    private void Start()
    {
        //poolManager = GetComponentInParent<ShieldPoolingManager>();
       // _disablePropsCo = StartCoroutine(DisableProps());

    }
    // Update is called once per frame
    void Update()
    {


    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SpellEnemy")
        {
            countDifense++;
            explosionVFX.SetActive(true);
            _disableVFX = StartCoroutine(DisableVFX());

            if (countDifense == 3)
            {
                _disableCo = StartCoroutine(DisableShield());
            }
        }
    }




    IEnumerator DisableProps()
    {

        yield return new WaitForSeconds(maxDuration);
        ItemPooling.Instance.ReturnToPool(this);


    }

    IEnumerator DisableVFX()
    {
        yield return new WaitForSeconds(2);
        explosionVFX.SetActive(false);
    }



    IEnumerator DisableShield()
    {


        yield return new WaitForSeconds(2f);
        countDifense = 0;

        ItemPooling.Instance.ReturnToPool(this);
        explosionVFX.SetActive(false);

    }
}
