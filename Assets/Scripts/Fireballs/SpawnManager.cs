using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private List<Spawner> spawners;
    private int currentFireballs = 0;
    [SerializeField]
    private int maxFireballs = 3;
    private float previousTime = 0.0f;

    public int CurrentFireballs
    {
        get { return currentFireballs; }
        set { currentFireballs = value; }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.realtimeSinceStartup - previousTime > 30.0f)
        {
            previousTime = Time.realtimeSinceStartup;
            maxFireballs++;
        }

        if (currentFireballs < maxFireballs)
        {
            int random = Random.Range(0, spawners.Count - 1);
            spawners[random].Spawn(this);
        }
    }
}
