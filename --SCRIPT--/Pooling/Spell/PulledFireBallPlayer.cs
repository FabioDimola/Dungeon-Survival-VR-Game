using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulledFireBallPlayer : MonoBehaviour
{
    [SerializeField] private FireBall pulledBulletPrefab;
    private Queue<FireBall> bulletPool = new Queue<FireBall>();
    public static int counter;
    public static PulledFireBallPlayer Instance { get; private set; } //questo è un singleton che non persiste se cambia scena (bisogna mettere don't destroy Onload)


    private void Awake()
    {
        Instance = this; //iniz Singleton


    }



    private void IncreasePoolSize(int count) //count grandezza pool
    {
        for (int i = 0; i < count; i++)
        {

            var bullet = Instantiate(pulledBulletPrefab, transform);//instanzia bullet nel parent a cui è collegato lo script
            bullet.gameObject.SetActive(false); //deve essere disattivato inizialmente
            bulletPool.Enqueue(bullet); //inserimento in coda del bullet creato

        }

    }


    private void Start()
    {

        IncreasePoolSize(20);


    }


    private void Update()
    {

    }

    public FireBall GetBullet()
    {
        if (bulletPool.Count == 0)
            IncreasePoolSize(20); // se la coda si svuota la ririempi
        return bulletPool.Dequeue(); //ritorna un pulled bullet (il primoche è stato messo in coda)

    }

    public void ReturnToPool(FireBall bullet)
    {
        bullet.gameObject.SetActive(false); //disattivo proiettile prima di farlo rientrare nella coda
        bulletPool.Enqueue(bullet); //ritorno in coda del bullet

    }

}
