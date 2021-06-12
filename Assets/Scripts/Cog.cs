using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cog : MonoBehaviour
{
    [SerializeField]
    private float speed = 50.0f;
    private Rigidbody2D rb;
    private float lifeTimer = 0.0f;
    private float maxLife = 2.0f;
    private CollectableSpawner spawner;

    public CollectableSpawner Spawn
    {
        get { return spawner; }
        set { spawner = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        maxLife = Random.Range(0.7f, 4.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (rb)
        {
            rb.gravityScale = Mathf.PingPong(Time.time / 6, 0.1f) - 0.05f;
            rb.AddForce(-transform.right * speed * Time.deltaTime);
        }

        if (lifeTimer >= maxLife && !GetComponent<Renderer>().isVisible)
        {
            //Add to score
            spawner.CurrentCollectables--;
            Destroy(gameObject);
        }

        lifeTimer += Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if (player)
            {
                player.Repair.CurrentCogs++;
            }

            spawner.CurrentCollectables--;
            Destroy(gameObject);
        }
    }
}
