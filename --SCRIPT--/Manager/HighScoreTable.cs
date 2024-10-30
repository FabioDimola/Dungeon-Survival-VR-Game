using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using OVRSimpleJSON;
using UnityEngine.SocialPlatforms.Impl;

public class HighScoreTable : MonoBehaviour
{

    private Transform entryContainer;
    private Transform entryTamplate;


    private List<Transform> highScoreEntryTransformList;
    private List<HighScoreEntry> highScoreEntryList;


    public PointManager pointManager;

    public PlayersName playerName;

   
    private void Awake()
    {
        entryContainer = transform.Find("HighScoreEntryContainer");
        entryTamplate = entryContainer.Find("HighScoreEntryTamplate");


        //deactive the sample tamplate
        entryTamplate.gameObject.SetActive(false);

        // Quando bisogna reinizializzare la tabella abilita questa funzione
        ReInitializeScoreTable("highScoreTable");


        string name = playerName.GetName();
     
        Debug.Log("your Name is: "+name);
        //Aggiunta nuovo punteggio
        if (pointManager != null)
        {
            AddHighScoreEntry(pointManager.point, name);
        }

        
        //delete key




     //Load dei punteggio precedentemente caricati e conversione da json
        string jsonString = PlayerPrefs.GetString("highScoreTable");
         HighScores highscores =  JsonUtility.FromJson<HighScores>(jsonString);

       
        



        //sort entry list by score
        for (int i = 0; i < highscores.highScoreEntryList.Count; i++)
              {
                  for (int j = i + 1; j < highscores.highScoreEntryList.Count; j++)
                  {
                      if (highscores.highScoreEntryList[j].score > highscores.highScoreEntryList[i].score)
                      {
                          //Swap
                          HighScoreEntry tmp = highscores.highScoreEntryList[i];
                          highscores.highScoreEntryList[i] = highscores.highScoreEntryList[j];
                          highscores.highScoreEntryList[j] = tmp;

                      }
                  }

          }



        highScoreEntryTransformList = new List<Transform>();
        foreach(HighScoreEntry highScoreEntry in highscores.highScoreEntryList)
        {
            CreateHighScoreEntryTransform(highScoreEntry, entryContainer, highScoreEntryTransformList);
        }
        
      


    }



    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            
            Debug.Log("Table cancellata");
        }
    }


  







    private void CreateHighScoreEntryTransform(HighScoreEntry highScoreEntry, Transform container, List<Transform> transformList)
    {
        float tamplateHeight = 0.03f;

       
            Transform entryTransform = Instantiate(entryTamplate, container);
            RectTransform entryrectTransform = entryTransform.GetComponent<RectTransform>();
            entryrectTransform.anchoredPosition = new Vector2(0f, -tamplateHeight * transformList.Count);
            entryTransform.gameObject.SetActive(true);

            int rank = transformList.Count + 1;
            string rankString;

            switch (rank)
            {
                default:
                    rankString = rank + "TH";
                    break;
                case 1:
                    rankString = "1ST";
                    break;
                case 2:
                    rankString = "2ND";
                    break;
                case 3:
                    rankString = "3RD";
                    break;

            }
            entryTransform.Find("posText").GetComponent<TMP_Text>().text = rankString;

            int score = highScoreEntry.score;
            entryTransform.Find("scoreText").GetComponent<TMP_Text>().text = score.ToString();

            string name = highScoreEntry.name;
            entryTransform.Find("nameText").GetComponent<TMP_Text>().text = name;


            transformList.Add(entryTransform);

        

    }

    /*
     * Rapresents a single high score entries
     */

    
    //class that contains the store of the high score
    private class HighScores
    {
        public List<HighScoreEntry> highScoreEntryList;
    }

    [System.Serializable]
    private class HighScoreEntry
    {
        
        public string name;
        public int score;

    }


    
  public void AddHighScoreEntry(int score, string name)
    {

        //Create high score entry
        HighScoreEntry highScoreEntry = new HighScoreEntry { score = score, name = name };


        //Load saved high score entry
        string jsonString = PlayerPrefs.GetString("highScoreTable");
        HighScores highscores = JsonUtility.FromJson<HighScores>(jsonString);

        //Add new entry to high score
        highscores.highScoreEntryList.Add(highScoreEntry);
        string json = JsonUtility.ToJson(highscores);

        //save update
        PlayerPrefs.SetString("highScoreTable", json);
        PlayerPrefs.Save();

    }





    private void ReInitializeScoreTable( string key)
    {
        PlayerPrefs.DeleteAll();
        HighScores highScores = new HighScores { highScoreEntryList = highScoreEntryList };
        string json = JsonUtility.ToJson(highScores);
       
        //save update
        PlayerPrefs.SetString(key, json);
        PlayerPrefs.Save();


    }




}
