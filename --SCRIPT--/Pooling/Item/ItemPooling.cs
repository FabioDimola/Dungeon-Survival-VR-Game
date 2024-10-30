using NUnit.Framework.Internal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPooling : MonoBehaviour
{
    [SerializeField] private Item[] itemPrefab;

    [SerializeField] private Item CoinPrefab;

    private Queue<Item> itemPool = new Queue<Item>();

    private Queue<Item> coinPool = new Queue<Item>();
    [SerializeField] private Transform[] spawnPoint;
    [SerializeField] private Transform[] coinSpawnPoint;


    public static ItemPooling Instance { get; private set; }

    private void Awake()
    {
        Instance = this;

    }

    private void IncreasePoolSize(int count) //count grandezza pool
    {
        for (int i = 0; i < count; i++)
        {
           


                int randomPos = Random.Range(0, spawnPoint.Length);
                int randomItem = Random.Range(0, itemPrefab.Length);

                var items = Instantiate(itemPrefab[randomItem], spawnPoint[randomPos].transform);//instanzia enemy nel parent a cui è collegato lo script
                items.gameObject.SetActive(false); //deve essere disattivato inizialmente
                itemPool.Enqueue(items); //inserimento in coda del enemy creato
            
        }

    }


    private void IncreaseCoinPoolSize(int count)
    {
        for (int i = 0; i < count; i++)
        {
            int randomPos = Random.Range(0,coinSpawnPoint.Length);
                var coins = Instantiate(CoinPrefab, coinSpawnPoint[randomPos].transform);
                coins.gameObject.SetActive(false);
                coinPool.Enqueue(coins);
           
        }
    }




    private void Start()
    {

        IncreasePoolSize(10);
        IncreaseCoinPoolSize(20);

    }

    public Item GetItem()
    {
        if (itemPool.Count == 0)
            IncreasePoolSize(10); // se la coda si svuota la ririempi
        return itemPool.Dequeue(); //ritorna un enemy pulled (il primoche è stato messo in coda)

    }

    public Item GetCoin()
    {
        if (coinPool.Count == 0)
            IncreaseCoinPoolSize(10); // se la coda si svuota la ririempi
        return coinPool.Dequeue();

    }



    public void ReturnToPool(Item item)
    {
        item.gameObject.SetActive(false); //disattivo proiettile prima di farlo rientrare nella coda
        itemPool.Enqueue(item); //ritorno in coda del bullet

    }

    public void ReturnToCoinPool(Item item)
    {
        item.gameObject.SetActive(false);
        coinPool.Enqueue(item);

    }
}
