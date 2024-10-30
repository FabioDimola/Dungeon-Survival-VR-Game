using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPoolingManager : MonoBehaviour
{
    public float spawnPotionTime = 15f;
    public float spawnCoinTime = 10f;
    private Coroutine _spawnCoroutine;
    private Coroutine _spawnCoinCoroutine;
    




    private void Start()
    {


        _spawnCoroutine = StartCoroutine(ItemDrop());
        _spawnCoinCoroutine = StartCoroutine(CoinDrop());

    }

   

    IEnumerator ItemDrop()
    {


        while (true)
        {


            yield return new WaitForSeconds(spawnPotionTime);
            var shieldPool = ItemPooling.Instance.GetItem();
            shieldPool.gameObject.SetActive(true);



        }







    }


   


    IEnumerator CoinDrop()
    {


        while (true)
        {


            yield return new WaitForSeconds(spawnCoinTime);
            var coinPool = ItemPooling.Instance.GetCoin();
            coinPool.gameObject.SetActive(true);



        }

    }
}
