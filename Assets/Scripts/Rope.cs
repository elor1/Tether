﻿using UnityEngine;

public class Rope : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D tetherStart;
    [SerializeField]
    private GameObject tetherPrefab;
    [SerializeField]
    private int links = 7;
    [SerializeField]
    private Player player;

    void Awake()
    {
        GenerateTether();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void GenerateTether()
    {
        Rigidbody2D previousRB = tetherStart;

        for (int i = 0; i < links; i++)
        {
            GameObject link = Instantiate(tetherPrefab, transform);
            HingeJoint2D joint = link.GetComponent<HingeJoint2D>();
            joint.connectedBody = previousRB;

            if (i < links - 1)
            {
                previousRB = link.GetComponent<Rigidbody2D>();
            }
            else
            {
                player.ConnectTether(link.GetComponent<Rigidbody2D>());
            }
        }
    }
}
