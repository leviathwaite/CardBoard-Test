using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // TODO move hit and render color change to their own scripts
    
    public GameObject deathEffectPrefab;

    [SerializeField]
    private float startingHealth = 100;
    [SerializeField]
    private float currentHealth;
    [SerializeField]
    private float maxHealth = 100;
    [SerializeField]
    private bool isDead = false;
    [SerializeField]
    private float deathDelay = 1;
    [SerializeField]
    private Color hitColor = Color.yellow;
    [SerializeField]
    private bool recentlyHit = false;
    [SerializeField]
    private float hitCoolDownTime = 1;

    private Renderer rend;
    private Color origColor;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponentInChildren<Renderer>();
        origColor = rend.material.color;

        currentHealth = startingHealth;
    }

    public void ResetHealth()
    {
        rend = GetComponentInChildren<Renderer>();
        origColor = rend.material.color;

        currentHealth = startingHealth;
        isDead = false;
        ResetRecentlyHit();
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead && currentHealth != -1)
        {
            currentHealth = -1;
            Instantiate(deathEffectPrefab, transform.position, transform.rotation);
            // Destroy(gameObject, deathDelay);
            gameObject.SetActive(false);
        }
    }

    public void Damage(float amount)
    {
        if(!recentlyHit)
        {
           
            recentlyHit = true;
            rend.material.color = hitColor;
            Invoke("ResetRecentlyHit", hitCoolDownTime);
            currentHealth -= amount;

            UpdateHealth();
        }
        
    }

    public void Refill(float amount)
    {
        currentHealth += amount;
    }

    private void UpdateHealth()
    {
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        if(currentHealth < 1)
        {
            isDead = true;
        }
    }

    private void ResetRecentlyHit()
    {
        if(recentlyHit)
        {
            recentlyHit = false;
            ResetRenderer();
        }
        
    }

    private void ResetRenderer()
    {
        rend.material.color = origColor;
    }
}
