using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolvingController : MonoBehaviour
{
   public SkinnedMeshRenderer SkinnedMeshRenderer;
    private Material[] skinnedMaterial;
    public float dissolveRate = 0.00125f;
    public float refreshRate = 0.025f;

    private void Start()
    {
        if(SkinnedMeshRenderer != null)
        {
            skinnedMaterial = SkinnedMeshRenderer.materials;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(DissolveCo());
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Restart());
        }
    }

    IEnumerator DissolveCo()
    {
        if(skinnedMaterial.Length > 0)
        {
            float counter = 0;  
            while (skinnedMaterial[0].GetFloat("_DissolveAmmount") < 1)
            {
                counter += dissolveRate;
                for(int i = 0; i < skinnedMaterial.Length; i++)
                {
                    skinnedMaterial[i].SetFloat("_DissolveAmmount", counter);
                }
                yield return new WaitForSeconds(refreshRate);
            }
        }
    }


    IEnumerator Restart()
    {
        if (skinnedMaterial.Length > 0)
        {
            float counter = 1;
            while (skinnedMaterial[0].GetFloat("_DissolveAmmount") >= 0)
            {
                counter -= dissolveRate;
                for (int i = 0; i < skinnedMaterial.Length; i++)
                {
                    skinnedMaterial[i].SetFloat("_DissolveAmmount", counter);
                }
                yield return new WaitForSeconds(refreshRate);
            }
        }
    }

    public void Dissolve()
    {
        if (skinnedMaterial.Length > 0)
        {
            float counter = 0;
            while (skinnedMaterial[0].GetFloat("_DissolveAmmount") < 1)
            {
                counter += dissolveRate;
                for (int i = 0; i < skinnedMaterial.Length; i++)
                {
                    skinnedMaterial[i].SetFloat("_DissolveAmmount", counter);
                }
               
            }
        }
    }
}
