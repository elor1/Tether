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
    private int maxCollectables = 3;
    private int currentCollectables = 0;

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
        if (currentCollectables < maxCollectables)
        {
            Spawn();
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
            Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(spawnX, spawnY), 3.0f);
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

        Debug.Log(spawnX + ", " + spawnY);
        GameObject newObject = Instantiate(prefab, new Vector2(spawnX, spawnY), Quaternion.identity);
        Cog cog = newObject.GetComponent<Cog>();
        cog.Spawn = this;

        currentCollectables++;
    }
}
