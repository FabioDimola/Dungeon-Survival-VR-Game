using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBub : MonoBehaviour
{
    Renderer _renderer;
    [SerializeField] AnimationCurve _DisplacementCurve;
    [SerializeField] float _DisplacementMagnitude;
    [SerializeField] float _LerpSpeed;
    [SerializeField] float _DisolveSpeed;
    public bool _shieldOn;
    Coroutine _disolveCoroutine;
    public SphereCollider _collider;
    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer>();
       // _collider = GetComponent< SphereCollider>();
        _collider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                HitShield(hit.point);
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            OpenCloseShield();
        }

        float disolve = _renderer.material.GetFloat("_Disolve");

        if(disolve > 0.5)
        {
            _collider.enabled=false;
        }
        else
        {
            _collider.enabled=true;
        }

    }

    public void HitShield(Vector3 hitPos)
    {
        _renderer.material.SetVector("_HitPos", hitPos);
        StopAllCoroutines();
        StartCoroutine(Coroutine_HitDisplacement());
    }

    public void OpenCloseShield()
    {
        float target = 1;
        if (_shieldOn)
        {
            target = 0;
            
        }
       
      
        _shieldOn = !_shieldOn;
        _collider.enabled = !_collider.enabled;
        if (_disolveCoroutine != null)
        {
            StopCoroutine(_disolveCoroutine);
        }
        _disolveCoroutine = StartCoroutine(Coroutine_DisolveShield(target));
    }

    IEnumerator Coroutine_HitDisplacement()
    {
        float lerp = 0;
        while (lerp < 1)
        {
            _renderer.material.SetFloat("_DisplacementStrength", _DisplacementCurve.Evaluate(lerp) * _DisplacementMagnitude);
            lerp += Time.deltaTime*_LerpSpeed;
            yield return null;
        }
    }

    IEnumerator Coroutine_DisolveShield(float target)
    {
        float start = _renderer.material.GetFloat("_Disolve");
        float lerp = 0;
        while (lerp < 1)
        {
            _renderer.material.SetFloat("_Disolve", Mathf.Lerp(start,target,lerp));
            lerp += Time.deltaTime * _DisolveSpeed;
            yield return null;
        }
    }




   
}
