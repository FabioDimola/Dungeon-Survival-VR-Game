using Oculus.Interaction.Input;
using Ragdoll;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;



public abstract class Enemy : MonoBehaviour
{

    [SerializeField] EnemyType enemyType;
    public EnemyType EnemyType => enemyType;

    [HideInInspector] public NavMeshAgent agent;
    [HideInInspector] public Animator animator;
   
    Coroutine DeathCo;

    [HideInInspector] public int maxHealth=1;
    public int currentHealth;
    [HideInInspector] public float stopDistance = 2f;
    [HideInInspector] public GameObject player;
    public bool isDeath = false;
    [HideInInspector] public float distance;
   
    public float radiusAroundTarget;

    LevelManager levelManager;


   
    public virtual void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        levelManager = FindFirstObjectByType<LevelManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        currentHealth = maxHealth;
       SetUpRaggDoll();
        Debug.Log(isDeath);
    }


    public virtual void Update()
    {
        
        distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance < 5)
        {
            LookTarget();
        }
        
        MovingToPlayer();

       
     
        if (PlayerHealth.instance.currentHealth <= 0|| levelManager.win)
        {
            Dead(transform.position);
       }


    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Shield")
        {
            animator.SetTrigger("Difense");
        }
    }




    public void LookTarget()
    {
        Vector3 lookPos = player.transform.position - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.2f);
    }







    public void MoveTo()
    {
        int i = Random.Range(0, 360);
        int count = Random.Range(0, 360);


        agent.SetDestination(new Vector3(
        player.transform.position.x + radiusAroundTarget * Mathf.Cos(2 * Mathf.PI * i / count),
        player.transform.position.y,
        player.transform.position.z + radiusAroundTarget * Mathf.Sin(2 * Mathf.PI * i / count)

                ));
    }


   
    public virtual void MovingToPlayer()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance < stopDistance && !isDeath)
        {
            agent.isStopped = true;

            animator.SetBool("Attack", true);
        }
        else if (distance > stopDistance)
        {

            animator.SetBool("Attack", false);

            agent.isStopped = false;
            agent.SetDestination(player.transform.position);


        }
    }


  
    public void SetUpRaggDoll()
    {
        foreach(var item in GetComponentsInChildren<Rigidbody>())
        {
            item.isKinematic = true;
        }
    }

    public void DeactiveRagdoll()
    {
        foreach (var item in GetComponentsInChildren<Rigidbody>())
        {
            item.isKinematic = false;
        }
    }


    public virtual void Dead(Vector3 hitPosition)
    {
        isDeath = true;
        animator.enabled = false;

       
        this.transform.LookAt(Vector3.up);

        DeactiveRagdoll();

       HitWithForce(hitPosition);


   
       
        agent.enabled = false;
        
       this.enabled = false;



        Debug.Log("Etchu");
    }


    public void HitWithForce(Vector3 hitPosition)
    {
        foreach (var item in Physics.OverlapSphere(hitPosition, 0.3f))
        {
            Rigidbody rb = item.GetComponent<Rigidbody>();

            if (rb)
            {
                rb.AddExplosionForce(5000, hitPosition, 0.3f);
            }
        }


    }



   

}


public enum EnemyType
{
    Ghost,
    Goblin,
    Orc,
    Golem,
    MinGolem,
    Soldier,
    Puncher
}