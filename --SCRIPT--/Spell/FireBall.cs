using Meta.WitAi.Json;
using Oculus.Voice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FireBall : BasicSpell
{

    public float currentLifeTime = 6;



    private PointManager pointManager;

    public Vector3 movingAxis; //the axis throw the spell are moving
    private Vector3 movingWorldAxis; //reference to the world axis 
   public float timer = 1.3f;
    public float movingSpeed = 5f;
    private Coroutine _deactiveCo;
    private Coroutine _movingCo;
   Collider _collider;
    public override void Initialize(Transform spellShotPoint)
    {
        base.Initialize(spellShotPoint);

        //the transform direction will change the direction in local space to a direction in world space
        //with this method the spell are moving throw the direction of the finger
        movingWorldAxis = spellShotPoint.TransformDirection(movingAxis);
    }


    private void Start()
    {
        _deactiveCo = StartCoroutine(DeactiveCO());
        //  _movingCo = StartCoroutine(MovingCo());
           _collider = GetComponent<Collider>();
        
    }




    // Update is called once per frame
    void Update()
    {

      timer -= Time.deltaTime;
        if (timer <= 0)
        {
            transform.position += Time.deltaTime * movingSpeed * movingWorldAxis;
        }
            
        

     

    }


    

    IEnumerator MovingCo()
    {
        yield return new WaitForSeconds(timer);
        transform.position += Time.deltaTime * movingSpeed * movingWorldAxis;
    }

    IEnumerator DeactiveCO()
    {
        yield return new WaitForSeconds(currentLifeTime);
        timer = 1.3f;
        _collider.enabled = true;
        PulledFireBallPlayer.Instance.ReturnToPool(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            PulledFireBallPlayer.Instance.ReturnToPool(this);
             timer = 1.3f;
        }
        if(other.gameObject.tag == "SpellEnemy")
        {
            PulledFireBallPlayer.Instance.ReturnToPool(this);

             timer = 1.3f;
           

        }
        switch (other.gameObject.name)
        {

            case "Hips":
                pointManager.point += 5;
                pointManager.UpdatePointScored();
                _collider.enabled = false;
                
                break;
            case "Neck":
                pointManager.point += 10;
                pointManager.UpdatePointScored();
                _collider.enabled = false;
                break;


        }
    }

   

}
