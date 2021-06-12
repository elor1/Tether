using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private Player player;
    private SpawnManager spawnManager;
    [SerializeField]
    private float rotationOffset = 45.0f;
    
    public SpawnManager Manager
    {
        get { return spawnManager; }
        set { spawnManager = value; }
    }

    public void Spawn(SpawnManager manager)
    {
        spawnManager = manager;
        GameObject newObject = Instantiate(prefab, transform);
        Fireball fireball = newObject.GetComponent<Fireball>();
        fireball.Spawn = this;
        newObject.transform.right = player.transform.position - transform.position;
        newObject.transform.Rotate(0.0f, 0.0f, Random.Range(-rotationOffset, rotationOffset));
        spawnManager.CurrentFireballs++;
    }
}
