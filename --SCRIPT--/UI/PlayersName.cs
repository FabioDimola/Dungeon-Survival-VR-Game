using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayersName : MonoBehaviour
{
    public ShowKeboard keyboard;

    public string[] names;


    public string namePlayer;


    private void Awake()
    {
      

    }







    public void SaveNamePlayer()
    {
        //PlayerPrefs.DeleteKey("PlayersName");
        PlayerPrefs.SetString("PlayersName", keyboard.inputField.text);
      /*  names = new string[1];
        names[0] = ;
        string json = JsonUtility.ToJson(names);
        */
       // PlayerPrefs.Save();

        Debug.Log("Your name is" + PlayerPrefs.GetString("PlayersName"));
    }


    public string GetName()
    {
        return PlayerPrefs.GetString("PlayersName");
    }


}
