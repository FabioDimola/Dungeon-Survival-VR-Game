using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem; //for controllers
using Oculus.Voice;
using Meta.WitAi.Json;

public class SpellCastManager : MonoBehaviour
{

    public UIManager uiManager;
    public Transform spellShotPoint;
    public Transform fireBallShotPoint;

    public Transform spellShootCTRLPoint;

    public InputActionProperty spellInput;
    public Animator ballAnimator;

    //spell casting with voice
    // public AppVoiceExperience voiceRecognizer;


    // private string saidSpell;

    public AudioSource EmptySpellSound;
    //Ammo
    public int maxAmmo = 5;
    int currentAmo;

    [System.Serializable]
    public class SpellData{

        //All info about a spell
        public BasicSpell spell;
        
        public string spellName;
        public string spellVoiceName;
        public bool useVoice;
   }


    private void Start()
    {
        // voiceRecognizer.VoiceEvents.OnPartialResponse.AddListener(SetSaidSpell);
        currentAmo = maxAmmo;
    }


    //impostare inizio recording voce 
  /*  public void StartRecordSpellCast()
    {
        voiceRecognizer.Activate();
        saidSpell = "";
    }

    public void StopRecordSpellCast()
    {
        voiceRecognizer.Deactivate();
    }


    private void SetSaidSpell(WitResponseNode response)
    {
        string intentName = response["intents"][0]["name"].Value.ToString();
        saidSpell = intentName;
    }



    public void AttackWithVoice()
    {
        if(saidSpell != null && saidSpell != "")
        {
            if(saidSpell == "Fire")
            {
                ballAnimator.SetTrigger("Attack");
            }
        }
    }
  */

    // if we want use the controllers for the spell cast 
    //  public InputActionProperty spellInput; //for controllers

    private void Update()
    {


      /*  if (spellInput.action.WasPressedThisFrame())
        {
            //do something
            //    start casting
        }else if(spellInput.action.WasReleasedThisFrame()){
            StartSpellCTRL();
            SpellShot();
            Debug.Log("Shoot");
    }*/
    }


    //I am going to use the hand tracking and pose recognize for the attack mechanism
    // this is the SpellShootManager for the player with pooling System

    public void SpellShot()
    {
       
            var spawnedSpell = PulledSpellPlayer.Instance.GetBullet();
            spawnedSpell.Initialize(spellShotPoint);
            spawnedSpell.gameObject.SetActive(true);
        
        
    }




    private void StartSpellCTRL()
    {
        var spawnedSpell = PulledSpellPlayer.Instance.GetBullet();
        spawnedSpell.Initialize(spellShootCTRLPoint);
        spawnedSpell.gameObject.SetActive(true);
    }

    public void FireBallShoot()
    {
        
        if (currentAmo > 0)
        {
            currentAmo--;
            var spawnedSpell = PulledFireBallPlayer.Instance.GetBullet();
            spawnedSpell.Initialize(fireBallShotPoint);
            spawnedSpell.gameObject.SetActive(true);
        }else if (currentAmo <= 0)
        {
            //playSound
            EmptySpellSound.Play();
        }
    }
   
  
}
