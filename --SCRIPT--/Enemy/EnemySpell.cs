using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpell :BasicSpell
{
    public Vector3 movingAxis; //the axis throw the spell are moving
    public float movingSpeed = 5f;
    private Vector3 movingWorldAxis; //reference to the world axis 

    private float collisionRadius = 0.2f;
    public LayerMask collisionLayer;


    public float maxLifeTime = 15f;
    private float currentLifeTime;
    private bool difense = false;


    [SerializeField] float _ProjectileSpeed;
    [SerializeField] GameObject _HitEffect;
    Vector3 _hitNormal;
    Vector3 _hitPos;
    Ray ray;
    RaycastHit hit;

    // public GameObject collisionSpell;

    //or 
    //   public GameObject explosion;
    public GameObject spell;



    //override the basic spell initialize function
    public override void Initialize(Transform spellShotPoint)
    {
      base.Initialize(spellShotPoint);
        //the transform direction will change the direction in local space to a direction in world space
        //with this method the spell are moving throw the direction of the finger
        movingWorldAxis = spellShotPoint.TransformDirection(movingAxis) ;
        
    }



    private void Awake()
    {
        transform.position += Time.deltaTime * movingSpeed * movingWorldAxis;
        
    }



    private void Update()
    {

        Vector3 delta = Time.deltaTime * movingSpeed * movingWorldAxis;
        transform.position += delta;
        ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out hit))
        {
            _hitNormal = hit.normal;
            _hitPos = hit.point;

            if (difense)
            {
                Hit(hit.collider);

            }
        }
        currentLifeTime -= Time.deltaTime;
        if (currentLifeTime <= 0 || difense)
        {
            BulletManager.Instance.ReturnToPool(this);
            difense = false;
        }

    }

    void Hit(Collider collider)
    {
        GameObject hit = Instantiate(_HitEffect, _hitPos, Quaternion.identity);
        ShieldBub shield = collider.GetComponentInParent<ShieldBub>();
        if (shield != null)
        {
            shield.HitShield(_hitPos);
        }
        hit.transform.forward = _hitNormal;

    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Shield")
        {
            difense = true;
        }
        if(other.gameObject.tag == "Spell")
        {
            BulletManager.Instance.ReturnToPool(this);
        }
    }


    private void OnEnable()
    {
        currentLifeTime = maxLifeTime;
    }

  


   

}
