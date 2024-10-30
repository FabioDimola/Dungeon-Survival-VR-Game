using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class SceneLoader : MonoBehaviour
{
    public GameObject BlackPanel;
    public GameObject WelcomePanel;
    public GameObject Scene;



    public void IntroStart()
    {
        WelcomePanel.SetActive(false);
        
        BlackPanel.SetActive(true);
        Scene.SetActive(false);
        StartCoroutine(LoadingNextScene());

    }

    IEnumerator LoadingNextScene()
    {
        yield return new WaitForSeconds(3f);
        LoadScene(1);

    }

   public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "EnergyPunch")
        {
            SceneManager.LoadScene(0);
        }
    }
}
