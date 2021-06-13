using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField]
    private float speed = 900.0f;
    private Rigidbody2D rb;
    private float lifeTimer = 0.0f;
    private float maxLife = 2.0f;
    private Spawner spawner;
    private bool hasHit = false;

    public Spawner Spawn
    {
        get { return spawner; }
        set { spawner = value; }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        maxLife = Random.Range(0.7f, 2.3f);
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.right * speed * Time.deltaTime);

        if (lifeTimer >= maxLife && !GetComponent<Renderer>().isVisible)
        {
            //Add to score
            if (!hasHit)
            {
                GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
                if (playerObject)
                {
                    Player player = playerObject.GetComponent<Player>();
                    if (player)
                    {
                        Score score = player.GetComponent<Score>();
                        score.AddScore(5);
                    }
                }
            }

            spawner.Manager.CurrentFireballs--;
            Destroy(gameObject);
        }

        lifeTimer += Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Lose life
            Player player = other.GetComponent<Player>();
            if (player)
            {
                Health health = player.GetComponent<Health>();
                if (health)
                {
                    health.CurrentHealth--;
                }

                hasHit = true;
            }
        }

        if (other.gameObject.tag == "Tether")
        {
            Tether tether = other.GetComponent<Tether>();
            tether.OnHit();

            hasHit = true;
        }
    }
}
