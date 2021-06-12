using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float distanceFromTetherEnd = 0.3f;
    [SerializeField]
    private float movementSpeed = 900.0f;
    private Rigidbody2D rb;

    public Rigidbody2D RigidBody
    {
        get { return rb; }
        set { rb = value; }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = Mathf.PingPong(Time.time / 10, 0.2f) - 0.1f;

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector2.up * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector2.up * -movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector2.right * -movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector2.right * movementSpeed * Time.deltaTime);
        }
    }

    public void ConnectTether(Rigidbody2D tetherEnd)
    {
        HingeJoint2D joint = gameObject.AddComponent<HingeJoint2D>();
        joint.autoConfigureConnectedAnchor = false;
        joint.connectedBody = tetherEnd;
        joint.anchor = Vector2.zero;
        joint.connectedAnchor = new Vector2(0.0f, distanceFromTetherEnd);
    }
}
