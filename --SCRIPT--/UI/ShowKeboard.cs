using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Microsoft.MixedReality.Toolkit.Experimental.UI;
public class ShowKeboard : MonoBehaviour
{
    public TMP_InputField inputField;

    /// <summary>
    /// for the highscore table
    /// </summary>
    public string highScoreName;

    private void Start()
    {
        inputField = GetComponent<TMP_InputField>();
        inputField.onSelect.AddListener(x => OpenKeyboard());
    }



    public void OpenKeyboard()
    {
        NonNativeKeyboard.Instance.InputField = inputField;
        NonNativeKeyboard.Instance.PresentKeyboard(inputField.text);
    }


    public void StoreName()
    {
        highScoreName = inputField.text;

    }
}
