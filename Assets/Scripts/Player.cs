using UnityEngine;

public class Player : MonoBehaviour
{
    public float distanceFromTetherEnd = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
