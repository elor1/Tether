using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject ship;
    private SpriteRenderer shipRenderer;
    [SerializeField]
    private GameObject prefab;
    private Collider2D collider;
    [SerializeField]
    private int maxCollectables = 1;
    private int currentCollectables = 0;
    private float spawnDelay = 0.0f;
    private float spawnTimer = 0.0f;
    private float previousTime = 0.0f;

    public int CurrentCollectables
    {
        get { return currentCollectables; }
        set { currentCollectables = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        shipRenderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.realtimeSinceStartup - previousTime > 35.0f)
        {
            previousTime = Time.realtimeSinceStartup;
            maxCollectables++;
        }

        if (spawnDelay > 0.0f)
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= spawnDelay)
            {
                Spawn();
            }
        }

        if (currentCollectables < maxCollectables)
        {
            spawnDelay = Random.Range(5.0f, 10.0f);
        }
    }

    void Spawn()
    {
        bool validPosition = false;
        float spawnX = 0.0f;
        float spawnY = 0.0f;
        int tries = 0;

        while (!validPosition)
        {
            validPosition = true;
            spawnX = Random.Range(collider.bounds.min.x, collider.bounds.max.x);
            spawnY = Random.Range(collider.bounds.min.y, collider.bounds.max.y);
            Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(spawnX, spawnY), 5.0f);
            foreach (Collider2D collider in colliders)
            {
                if (collider.gameObject.tag == "Ship" || collider.gameObject.tag == "Collectable")
                {
                    validPosition = false;
                }
            }

            tries++;
            if (tries == 3)
            {
                return;
            }
        }

        GameObject newObject = Instantiate(prefab, new Vector2(spawnX, spawnY), Quaternion.identity);
        HealthPickup health = newObject.GetComponent<HealthPickup>();
        health.Spawn = this;

        currentCollectables++;
        spawnTimer = 0.0f;
        spawnDelay = 0.0f;
    }
}
