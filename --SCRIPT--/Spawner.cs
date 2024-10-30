using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Spawner : MonoBehaviour
{
   
    public GameObject[] spawnableEnemies;
    public Transform[] spawnPoints;

    public float spawnTime = 10f;
    public int Counter = 0;
    private Coroutine _spawnCoroutine;
    private int enemiesActive;
    private GameObject enemy;


    private void Start()
    {
       

        _spawnCoroutine = StartCoroutine(EnemyDrop());
    }

    private void Update()
    {
       

        enemy = GameObject.FindGameObjectWithTag("Enemy");

        if (enemy == null)
        {
            Counter = 0;
        }

        if (enemiesActive == 4)
        {
            StopCoroutine(_spawnCoroutine);


        }
        else if (Counter == 0)
        {
            enemiesActive = 0;
            StartCoroutine(EnemyDrop());
        }

    }


    IEnumerator EnemyDrop()
    {


        while (enemiesActive < 2)
        {

            Counter++;

            int randomEnemy = Random.Range(0, spawnableEnemies.Length);
            Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(spawnableEnemies[randomEnemy].gameObject, randomPoint.position, randomPoint.rotation);

            yield return new WaitForSeconds(spawnTime);
            enemiesActive++;
        }

    }


}
