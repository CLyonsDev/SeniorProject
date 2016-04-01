using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PortalHealth : MonoBehaviour
{
    [SerializeField]
    GameObject healthBarGO;

    Image healthBar;

    float currentHealth;
    float maxHealth = 1000;

    // Use this for initialization
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar = healthBarGO.GetComponent<Image>();

        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, currentHealth / maxHealth, Time.deltaTime * 16);

        if(Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(maxHealth);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            GameObject.Find("Game Manager").GetComponent<GameManager>().PortalDeath();
            GameObject.Find("Game Manager").GetComponent<ScoreManager>().portalsDestroyed++;
            healthBar.fillAmount = 0;
            Destroy(gameObject);
            Destroy(healthBarGO.transform.parent.gameObject);
            Destroy(healthBarGO);
        }
    }
}
