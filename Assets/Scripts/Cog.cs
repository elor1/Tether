using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cog : MonoBehaviour
{
    private CollectableSpawner spawner;

    public CollectableSpawner Spawn
    {
        get { return spawner; }
        set { spawner = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Add point
            Debug.Log("Point");
            spawner.CurrentCollectables--;
            Destroy(gameObject);
        }
    }
}
