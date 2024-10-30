using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : Item 
{
    
    private bool _taken = false;
    private Coroutine _coroutine;
    private Animator _animator;
    PlayerHealth _player;
    private float minDistance = 2f;
    private void Start()
    {
        _animator = GetComponent<Animator>();
         _player = GameObject.FindFirstObjectByType<PlayerHealth>();

        _coroutine = StartCoroutine(DisableProps());
        StartCoroutine(DisableProps());
        
    }



    private void Update()
    {

        DisableAnimator();
    }


    private void DisableAnimator()
    {
        float distance = Vector3.Distance(_player.transform.position, transform.position);
        if (distance < minDistance)
        {
            _animator.enabled = false;
        }

        if (distance <= 1f)
        {
          //  ItemPooling.Instance.ReturnToPool(this);
            _taken = true;
        }
    }



    IEnumerator DisableProps()
    {
        while (!_taken)
        {
            yield return new WaitForSeconds(duration);
            ItemPooling.Instance.ReturnToPool(this);
        }

    }





}
