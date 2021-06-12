using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject ship;
    private SpriteRenderer shipRenderer;
    [SerializeField]
    private GameObject prefab;
    private Collider2D collider;
    [SerializeField]
    private int maxCollectables = 2;
    private int currentCollectables = 0;
    private float spawnDelay = 0.0f;
    private float spawnTimer = 0.0f;

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
            spawnDelay = Random.Range(0.7f, 3.5f);
        }
    }

    void Spawn()
    {
        bool validPosition = false;
        float spawnX = 0.0f;
        float spawnY = 0.0f;

        while (!validPosition)
        {
            validPosition = true;
            spawnX = Random.Range(collider.bounds.min.x, collider.bounds.max.x);
            spawnY = Random.Range(collider.bounds.min.y, collider.bounds.max.y);
            Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(spawnX, spawnY), 5.0f);
            foreach (Collider2D collider in colliders)
            {
                if (collider.gameObject.tag == "Ship")
                {
                    validPosition = false;
                }
                if (collider.gameObject.tag == "Collectable")
                {
                    validPosition = false;
                }
            }
        }
        
        GameObject newObject = Instantiate(prefab, new Vector2(spawnX, spawnY), Quaternion.identity);
        Cog cog = newObject.GetComponent<Cog>();
        cog.Spawn = this;

        currentCollectables++;
        spawnTimer = 0.0f;
        spawnDelay = 0.0f;
    }
}
