using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;

    [SerializeField]
    private int maxHealth;

    private int currentHealth;

    [SerializeField]
    private GameObject playerDeathEffectPreFab;
    public int CurrentHealth { get => currentHealth; set => currentHealth = value; }

    [Header("Variables for a invincible time for player in order lifes don't go too fast")]
    [SerializeField]
    private float invincibleLength;
    private float invincibleCounter;

    private SpriteRenderer sr;

    private void Awake()
    {
        if (instance == null)
            instance = this; //aplicar singleton TBD
    }

    // Start is called before the first frame update
    void Start()
    {
        initLifes();
        sr = GetComponent<SpriteRenderer>();
    }

    public void initLifes()
    {
        currentHealth = maxHealth;
        Debug.Log("current Health: "+currentHealth);
    }
    // Update is called once per frame
    void Update()
    {
        if(invincibleCounter > 0)
        {
            invincibleCounter -= Time.deltaTime;

            if(invincibleCounter <= 0)
                sr.color = new Color(sr.color.r,sr.color.g, sr.color.b,1f); //Efecto Desvanecer
        }
            
    }

    public void DealDamage(int damage)
    {
        if(invincibleCounter <= 0) //don't have more invinciblity
        {
            currentHealth = currentHealth - damage;
            Player.instance.Animation.SetTrigger("Hurt"); //Animation of hurt
            AudioManager.instance.PlaySFX(9);

            if (currentHealth <= 0)
            {
                Instantiate(playerDeathEffectPreFab, Player.instance.transform.position, Player.instance.transform.rotation);
                AudioManager.instance.PlaySFX(8);
                LevelManager.instance.RespawnPlayer();
            }

            else
            {
                invincibleCounter = invincibleLength; // reset invicililty
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.5f); //Efecto Desvanecer
            }


            UIController.instance.UpdateHealthDisplay();
        }

    }

    public void AddHealth()
    {
        if(currentHealth < maxHealth)
        {
            currentHealth++;
            UIController.instance.UpdateHealthDisplay();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Platform")
            transform.parent = other.transform;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Platform")
            transform.parent = null;
    }
}
