using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class GemiHareket : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 5f;
    public float RotationSpeed = .2f;

    float vertical;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        vertical = Input.GetKey(KeyCode.D) ? +1 : Input.GetKey(KeyCode.A) ? -1 : 0;
    }

    [System.Obsolete]
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W)) //W Basýlýyorsa
        { 
            Vector3 localVelocity = new Vector3(0, 0,speed); // Z = forward (local)
            rb.velocity = transform.TransformDirection(localVelocity);
            transform.Rotate(0,vertical * RotationSpeed, 0);
        }
    }

}
