using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
{
    //class that store the points of the player

    public int point =0;
    public int coin = 0;
    public int key = 0;


    public TMP_Text PointTXT;
    public TMP_Text coin_TXT;
    public TMP_Text key_TXT;

    public GameObject enemyKey;

   
  


    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


      if(point >= 200 && key >= 2 && enemyKey!= null)
        {
            enemyKey.SetActive(true); 
        }


     /*   if (playerHealth != null)
        {
            if (playerHealth.isDead)
            {

                if (count == 0)
                {
                   // highScoreTable.AddHighScoreEntry(point, );
                    count++;
                }
                // highScoreTable.AddHighScoreEntry(point, "Toni");
                return;
            }
        }*/
    }

    public void UpdatePointScored()
    {
        PointTXT.SetText($"Points : {point}");
    }

    public void UpdateCoinTake()
    {
        coin_TXT.SetText($" {coin}");
    }


    public void UpdateKeyTake()
    {
        key_TXT.SetText($" {key}");
    }
}
