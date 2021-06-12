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
        if (Time.realtimeSinceStartup >= 90.0f && previousTime < 90.0f)
        {
            maxFireballs++;
        }
        else if (Time.realtimeSinceStartup >= 60.0f && previousTime < 60.0f)
        {
            maxFireballs++;
        }
        else if (Time.realtimeSinceStartup >= 40.0f && previousTime < 40.0f)
        {
            maxFireballs++;
        }
        else if (Time.realtimeSinceStartup >= 25.0f && previousTime < 25.0f)
        {
            maxFireballs++;
        }

        if (currentFireballs < maxFireballs)
        {
            int random = Random.Range(0, spawners.Count - 1);
            spawners[random].Spawn(this);
        }

        previousTime = Time.realtimeSinceStartup;
    }
}
