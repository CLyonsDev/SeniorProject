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

        if(currentHealth <= 0)
        {
            healthBar.fillAmount = 0;
            Destroy(gameObject);
            Destroy(healthBarGO.transform.parent.gameObject);
            Destroy(healthBarGO);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Player Projectile")
        {
            currentHealth -= 25;
        }
    }
}
