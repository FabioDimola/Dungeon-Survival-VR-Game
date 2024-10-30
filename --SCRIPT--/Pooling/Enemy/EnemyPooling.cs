using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPooling : MonoBehaviour
{

    [SerializeField] private Enemy[] pulledEnemyPrefab;
    [SerializeField] private Enemy[] pulledGhostPrefab;
    private Queue<Enemy> enemyPool = new Queue<Enemy>();
    private Queue<Enemy> ghostPool = new Queue<Enemy>();
    [SerializeField] private Transform[] spawnPoint;

    public Transform[] spawnGhostPoint;
    public static EnemyPooling Instance { get; private set; }

    private void Awake()
    {
        Instance = this;

    }

    
    private void IncreasePoolSize(int count) //count grandezza pool
    {
        for (int i = 0; i < count; i++)
        {

            int randomEnemy = Random.Range(0, pulledEnemyPrefab.Length);
            int randomPos = Random.Range(0, spawnPoint.Length);
            var health = Instantiate(pulledEnemyPrefab[randomEnemy], spawnPoint[randomPos].transform);//instanzia enemy nel parent a cui è collegato lo script
            health.gameObject.SetActive(false); //deve essere disattivato inizialmente
            enemyPool.Enqueue(health); //inserimento in coda del enemy creato

        }

    }

    private void IncreasePooGhostlSize(int count) //count grandezza pool
    {
        for (int i = 0; i < count; i++)
        {

            int randomEnemy = Random.Range(0, pulledGhostPrefab.Length);
            int randomPos = Random.Range(0, spawnPoint.Length);
            var ghost = Instantiate(pulledGhostPrefab[randomEnemy], spawnGhostPoint[randomPos].transform);//instanzia enemy nel parent a cui è collegato lo script
            ghost.gameObject.SetActive(false); //deve essere disattivato inizialmente
            ghostPool.Enqueue(ghost); //inserimento in coda del enemy creato

        }

    }

    private void Start()
    {

        IncreasePoolSize(80);
        if(spawnGhostPoint.Length > 0) 
        IncreasePooGhostlSize(30);

    }

    public Enemy GetEnemy()
    {
        if (enemyPool.Count == 0)
            IncreasePoolSize(80); // se la coda si svuota la ririempi
        return enemyPool.Dequeue(); //ritorna un enemy pulled (il primoche è stato messo in coda)

    }

    public Enemy GetGhost()
    {
        if (ghostPool.Count == 0)
            IncreasePooGhostlSize(30);
        return ghostPool.Dequeue();
    }


    public void ReturnGhostToPool(Enemy ghost)
    {
        ghost.gameObject.SetActive(false); //disattivo proiettile prima di farlo rientrare nella coda
        enemyPool.Enqueue(ghost); //ritorno in coda del bullet

    }

    public void ReturnToPool(Enemy health)
    {
        health.gameObject.SetActive(false); //disattivo proiettile prima di farlo rientrare nella coda
        enemyPool.Enqueue(health); //ritorno in coda del bullet

    }




}
