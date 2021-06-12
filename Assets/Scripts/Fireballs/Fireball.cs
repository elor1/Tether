using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField]
    private float speed = 900.0f;
    private Rigidbody2D rb;
    private float lifeTimer = 0.0f;
    private Spawner spawner;

    public Spawner Spawn
    {
        get { return spawner; }
        set { spawner = value; }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.right * speed * Time.deltaTime);

        if (lifeTimer >= 2.0f && !GetComponent<Renderer>().isVisible)
        {
            //Add to score
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
            Debug.Log("Hit player");
        }

        if (other.gameObject.tag == "Tether")
        {
            Tether tether = other.GetComponent<Tether>();
            tether.OnHit();
        }
    }
}
