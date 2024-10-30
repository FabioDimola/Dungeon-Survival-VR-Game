using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyManagerPooling : MonoBehaviour
{



    [SerializeField] private float spawnTime = 25f;
    [SerializeField] private float spawnGhostTime = 25f;
    private Coroutine _spawnCoroutine;
    private Coroutine _spawnGhostCoroutine;
    PointManager _pointManager;

    private void Start()
    {

        _pointManager = FindFirstObjectByType<PointManager>();
        _spawnCoroutine = StartCoroutine(EnemyDrop());
        if(EnemyPooling.Instance.spawnGhostPoint.Length > 0)
        _spawnGhostCoroutine = StartCoroutine(GhostDrop());
        
    }

   

    IEnumerator EnemyDrop()
    {
        Debug.Log("Coroutine Started");


        while(true)
        {
            var enemy = EnemyPooling.Instance.GetEnemy();
            enemy.gameObject.SetActive(true);
            if (spawnTime > 30)
            {
                spawnTime -= 1f;
            }
            yield return new WaitForSeconds(spawnTime);
        }


       

    }


    IEnumerator GhostDrop()
    {
        
            while (true)
            {
                var ghost = EnemyPooling.Instance.GetGhost();
                ghost.gameObject.SetActive(true);
                
                yield return new WaitForSeconds(spawnGhostTime);
            }

           
        
    }
}
