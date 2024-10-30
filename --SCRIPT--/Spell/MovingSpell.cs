using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovingSpell : BasicSpell
{
    public Vector3 movingAxis; //the axis throw the spell are moving
    public float movingSpeed = 5f;
    private Vector3 movingWorldAxis; //reference to the world axis 


    public float collisionRadius = 0.2f;
    public LayerMask collisionLayer;

    
    public GameObject explosion;


    private PointManager pointManager;

    public int POINTS=0;
    public int currentScore;

    public AudioSource spellImpact;

    //or 
    

    [SerializeField] private float maxLifeTime = 6f;
    private float currentLifeTime;
    private Coroutine _deactiveCo;
   Collider _collider;
  
   

    //override the basic spell initialize function
    public override void Initialize(Transform spellShotPoint)
    {
        base.Initialize(spellShotPoint);

        //the transform direction will change the direction in local space to a direction in world space
        //with this method the spell are moving throw the direction of the finger
        movingWorldAxis = spellShotPoint.TransformDirection(movingAxis); 
        
    }

    private void Start()
    {

        _collider = GetComponent<Collider>();
       
        pointManager = GameObject.FindFirstObjectByType<PointManager>().GetComponent<PointManager>();
        currentScore = 0;
        _deactiveCo = StartCoroutine(DeactiveCO());

    }
    private void Update()
    {
       
        transform.position += Time.deltaTime * movingSpeed * movingWorldAxis  ;

       
        
      

    }

    IEnumerator DeactiveCO()
    {
        yield return new WaitForSeconds(currentLifeTime);
        _collider.enabled = true;
        PulledSpellPlayer.Instance.ReturnToPool(this);
    }
    private void OnEnable()
    {
        currentLifeTime = maxLifeTime;
    }

/*
    private void FixedUpdate()
    {
        if (!hasExploded)
        {
            //whit phisics overlap sphere I check the collision with the objects
            Collider[] results = Physics.OverlapSphere(transform.position, collisionRadius, collisionLayer);

            if (results.Length > 0)
            {
                //we found a collider
              //  Explode();
            }

            foreach (Collider coll in results)
            {
                switch(coll.gameObject.name)
                {
                    case "Hips":
                        pointManager.point += 2;
                        break;
                    case "Neck":
                        pointManager.point += 3;
                        break;
                    case "Spine_01":
                        pointManager.point += 3;
                        break;

                }

                pointManager.UpdatePointScored();
                logger.LogInfo("Punteggio " + currentScore);
            }
        }
    }
    */


    private void OnTriggerEnter(Collider other)
    {
        switch(other.gameObject.name)
        {

            case "Hips" :
                pointManager.point += 2;
                pointManager.UpdatePointScored();
                _collider.enabled = false;
                spellImpact.Play();
                break;
            case "Neck":
                pointManager.point += 8;
                pointManager.UpdatePointScored();
                _collider.enabled = false;
                spellImpact.Play();
                break;
                
            case "Spine_01":
                pointManager.point += 10;
                pointManager.UpdatePointScored();
                _collider.enabled = false;
                spellImpact.Play();
                break;

        }

        
        pointManager.UpdatePointScored();
    }



}
