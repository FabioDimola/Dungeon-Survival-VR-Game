using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ghost : Enemy
{
    [SerializeField] BasicSpell enemySpell;


    public GameObject objectToThrow;
    public Transform spawnObjectPoint;
    public Transform spellShotPoint;
    public bool isThrowing = false;


    Quaternion localRotationObj;
    Coroutine DeathCo;
    OnCollisionEnterDeath[] onCollisionEnterDeath;


    public override void Awake()
    {
        base.Awake();
     
        onCollisionEnterDeath = GetComponentsInChildren<OnCollisionEnterDeath>();
        stopDistance = Random.Range(3, 5);
        //the object will spawn  with the same rotation of the initial point
        localRotationObj = objectToThrow.transform.localRotation;
    }

    public override void Update()
    {
        //agent.enabled = false;
       LookPlayer();    
    }

    public void LookPlayer()
    {
        Vector3 lookPos = player.transform.position - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.2f);
    }


    public override void Dead(Vector3 hitPosition)
    {
        base.Dead(hitPosition);

        foreach (OnCollisionEnterDeath collision in onCollisionEnterDeath)
        {
            if ( objectToThrow != null)
            {
                ThrowObject();


            }
        }
    }
    //only ghost
    public void ThrowObject()
    {
        isThrowing = true;
        objectToThrow.transform.localRotation = localRotationObj;

        // separate the object from the parent
        objectToThrow.transform.parent = null;
        objectToThrow.SetActive(true);
        float distance = Vector3.Distance(player.transform.position, objectToThrow.transform.position);
        Rigidbody rb = objectToThrow.GetComponent<Rigidbody>();
        if (distance > 3)
        {
            rb.velocity = BalisticVelocity(spawnObjectPoint.transform.position, player.transform.position, 65);
            rb.angularVelocity = Vector3.zero;
        }

    }



    //only ghost
    Vector3 BalisticVelocity(Vector3 source, Vector3 target, float angle)
    {
        Vector3 direction = target - source;
        float h = direction.y;
        direction.y = 0;
        float distance = direction.magnitude;
        float a = angle * Mathf.Deg2Rad;
        direction.y = distance * Mathf.Tan(a);
        distance += h / Mathf.Tan(a);

        //Calculate the velocity
        float velocity = Mathf.Sqrt(distance * Physics.gravity.magnitude / Mathf.Sin(2 * a));
        return velocity * direction.normalized;
    }


    //only ghost
    public void EnemySpellShoot()
    {
        //  BasicSpell spawnedSpell = Instantiate(enemySpell);

        Vector3 playerHeadPosition = player.transform.position - Random.Range(0.6f, 1.3f) * -Vector3.up;

        var spawnedSpell = BulletManager.Instance.GetBullet();
        spawnedSpell.Initialize(spellShotPoint);
        spellShotPoint.up = (playerHeadPosition - spellShotPoint.position).normalized;
        spawnedSpell.gameObject.SetActive(true);
    }


}
