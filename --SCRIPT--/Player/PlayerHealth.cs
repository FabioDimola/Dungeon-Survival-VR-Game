
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private float maxExp = 100;
    public float currentHealth;
    private float currentExp;

    public  Health healthBar;
    //[SerializeField] private Experience expBar;
  
    public bool isDead = false;
   

    public PointManager pointManager;
    public  TMP_Text scoreText;
    [SerializeField] private GameObject deathCanvas;
    [SerializeField] private GameObject highScoreTable;
    private Enemy enemy;

    public static PlayerHealth instance;
    private Coroutine deathCoroutine;
    private bool stopCoroutine= false;

    public GameObject RunicSource;
    public bool isPowerUp = false;
    //Audio Source
    public AudioSource gameOverClip;
    public AudioSource theme;
    public AudioSource cureClip;
    public AudioSource coinTake;
    public AudioSource keyTake;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        currentHealth = maxHealth;
    }

    private void Start()
    {
        
        //currentHealth = maxHealth;
        currentExp = 0;
        healthBar.UpdateHealthBar(maxHealth, currentHealth);
       // expBar.UpdateExpBar(maxExp, 0);
        
    }


    

    private void Update()
    {

        
        if (currentHealth <= 0 )
        {
            // animator.SetLayerWeight(3, 1);

          
            isDead = true;
            gameOverClip.Play();
            deathCanvas.SetActive(true);
            theme.Stop();
            
            scoreText.text = "Hai totalizzato: "+pointManager.point.ToString() + "Punti";
           deathCoroutine =  StartCoroutine(BackToStart());
           // Time.timeScale = 0f;
            

        }

        if (stopCoroutine)
        {
            StopCoroutine(deathCoroutine);
        }

    }




    IEnumerator BackToStart()
    {
        Debug.Log("Back");
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene(0);
        stopCoroutine = true;
        
    }




    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "SpellEnemy")
        {
            if (currentHealth > 0)
            {


                currentHealth -= 12;
            }

            healthBar.UpdateHealthBar(maxHealth, currentHealth);
        }

        if (other.gameObject.tag == "PigPunch")
        {
            if (currentHealth > 0)
            {


                currentHealth -= 50;
            }

            healthBar.UpdateHealthBar(maxHealth, currentHealth);
        }
        if (other.gameObject.tag == "ShamanPunch")
        {
            if (currentHealth > 0)
            {


                currentHealth -= 20;
            }

            healthBar.UpdateHealthBar(maxHealth, currentHealth);
        }

        if (other.gameObject.tag == "Potion")
        {
            Debug.Log("Life is   " + currentHealth);
            if (currentHealth > 0)
            {
                cureClip.Play();
                Debug.Log("Audio Cura");
                currentHealth += 10;
                ItemPooling.Instance.ReturnToPool(other.gameObject.GetComponent<Item>());
            }

            healthBar.UpdateHealthBar(maxHealth, currentHealth);
        }

        if(other.gameObject.tag == "Runic")
        {
            RunicSource.SetActive(true);
            isPowerUp = true;
        }
        if(other.gameObject.tag == "Coin")
        {
            ItemPooling.Instance.ReturnToCoinPool(other.gameObject.GetComponent<Item>());
            pointManager.coin++;
            coinTake.Play();
            pointManager.UpdateCoinTake();
        }

        if( other.gameObject.tag == "Key")
        {
            pointManager.key++;
            pointManager.UpdateKeyTake();
            keyTake.Play();
            Destroy(other.gameObject);
        }
    }

  

    public void Cure()
    {
        if (currentHealth > 0)
        {
            currentHealth += 5;
        }
    }

    


   


    public void TakeDamage(float damage)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damage;
            healthBar.UpdateHealthBar(maxHealth, currentHealth);
        }


    }
}
