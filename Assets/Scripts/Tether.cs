using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tether : MonoBehaviour
{
    private Rope parentRope;
    private int durability = 10;
    private SpriteRenderer renderer;
    [SerializeField]
    private Color startColor;

    public Rope ParentRope
    {
        get { return parentRope; }
        set { parentRope = value; }
    }

    public int Durability
    {
        get { return durability; }
        set { durability = value; }
    }

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb)
        {
            rb.gravityScale = Random.Range(-0.01f, 0.01f);
        }
    }

    public void OnHit()
    {
        durability--;
        if (durability == 8)
        {
            renderer.color = new Color(0.949f, 0.596f, 0.133f);
        }
        else if (durability == 5)
        {
            renderer.color = new Color(0.71f, 0.306f, 0.0f);
        }
        else if (durability == 2)
        {
            renderer.color = new Color(0.522f, 0.082f, 0.027f);
        }
        else if (durability == 0)
        {
            parentRope.BreakRope();
            Destroy(gameObject);
        }
    }

    public void ResetColour()
    {
        if (!parentRope.IsBroken())
        {
            renderer.color = startColor;
        }
    }
}
