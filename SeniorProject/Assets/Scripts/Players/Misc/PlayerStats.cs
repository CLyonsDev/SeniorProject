using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerStats : MonoBehaviour {

    [SerializeField]
    float maxHealth = 100;
    float currentHealth;
    [SerializeField]
    float regen = 0.5f;

    [SerializeField]
    GameObject healthBarGO;

    Image healthBar;

    public bool dead = false;
    public bool joined = false;
    public bool lasOn = false;
    bool hideHammer = true;

    GameObject gm;

	// Use this for initialization
	void Start () {
        gm = GameObject.Find("Game Manager");
        currentHealth = maxHealth;
        healthBar = healthBarGO.GetComponent<Image>();
        StartCoroutine(healPlayer());
        if(gameObject.name == "Player3")
        {
            transform.GetChild(0).transform.GetChild(1).GetComponent<ParticleSystem>().Stop();
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, currentHealth / maxHealth, Time.deltaTime * 16);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            dead = true;

            gm.GetComponent<GameManager>().deadPlayers++;

            healthBar.fillAmount = 0;

            if(gameObject.name == "Player2")
            {
                GetComponent<HammerSwing>().enabled = false;
            }
            else if(gameObject.name == "Player1")
            {
                GetComponent<Shooting>().enabled = false;
            }
            else if (gameObject.name == "Player3")
            {
                GetComponent<SniperRifle>().enabled = false;
            }

                SwitchEnabled();
        }
    }

    IEnumerator healPlayer()
    {
        while(true)
        {
            if (currentHealth < maxHealth && !dead)
            {
                currentHealth += regen;
            }
            yield return new WaitForSeconds(0.75f);
        }
    }

    public void SwitchEnabled()
    {
        GetComponent<Movement>().enabled = !GetComponent<Movement>().enabled;
        GetComponent<Rotation>().enabled = !GetComponent<Rotation>().enabled;
        GetComponent<SpriteRenderer>().enabled = !GetComponent<SpriteRenderer>().enabled;
        GetComponent<CircleCollider2D>().enabled = !GetComponent<CircleCollider2D>().enabled;
        transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = !transform.GetChild(0).GetComponent<SpriteRenderer>().enabled;

        if (gameObject.name == "Player2")
        {
            GameObject.Find("Hammer").GetComponent<SpriteRenderer>().enabled = hideHammer;
            hideHammer = !hideHammer;
        }

        if (gameObject.name == "Player3")
        {
            lasOn = !lasOn;
            if (!lasOn)
            {
                transform.GetChild(0).transform.GetChild(1).GetComponent<ParticleSystem>().Stop();
            }
            else
            {
                transform.GetChild(0).transform.GetChild(1).GetComponent<ParticleSystem>().Play();
            }              
        }
        
        joined = true;
        if(!GameObject.Find("Game Manager").GetComponent<GameManager>().started)
        {
            GameObject.Find("Game Manager").GetComponent<GameManager>().started = true;
        }


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Objective 1")
        {
            GameObject.Find("Arrow").GetComponent<ObjectiveArrow>().destNum++;
            other.GetComponent<BoxCollider2D>().enabled = false;
        }
        

        if(other.tag == "Objective 2")
        {
            if(gm.GetComponent<GameManager>().victory)
            {
                /*GetComponent<Movement>().canMove = false;
                GetComponent<Rotation>().canLook = false;*/
                SwitchEnabled();
                gm.GetComponent<GameManager>().escapedPlayers++;
                gm.GetComponent<GameManager>().PlayerEscape();
            }  
        }
    }
}
