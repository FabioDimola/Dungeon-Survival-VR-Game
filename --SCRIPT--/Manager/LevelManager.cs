using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    PointManager pointManager;
    [SerializeField] GameObject winPanel;
    Enemy enemy;
    public int Level;
    public bool win = false;

    [SerializeField] int maxLevelPoint=200;
    // Start is called before the first frame update
    void Start()
    {
        pointManager = FindFirstObjectByType<PointManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pointManager.point >= maxLevelPoint && pointManager.key >=3)
        {
            winPanel.SetActive(true);
            win = true;
           StartCoroutine(NextLevel(Level));
        }
    }


    IEnumerator NextLevel(int level)
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(level);
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "EnergyPunch")
        {
            SceneManager.LoadScene(Level);
        }
    }
}
