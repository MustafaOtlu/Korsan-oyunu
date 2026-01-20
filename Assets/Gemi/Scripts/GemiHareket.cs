using Unity.Mathematics;
using UnityEngine;

public class GemiHareket : MonoBehaviour
{
    Rigidbody rb;
    public float moveForce = 10f;
    public float turnSpeed = 50f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        quaternion rt = transform.rotation;
        float rt_x = Mathf.Clamp(rt.value.x, -5, 10);
        float rt_z = Mathf.Clamp(rt.value.x, -25, 25);
        rt.value.x = rt_x;
        rt.value.z = rt_z;
        transform.rotation = rt;

    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
            rb.AddForce(transform.forward * moveForce);

        if (Input.GetKey(KeyCode.S))
            rb.AddForce(-transform.forward * moveForce);

        float turn = 0f;
        if (Input.GetKey(KeyCode.A)) turn = -1f;
        if (Input.GetKey(KeyCode.D)) turn = 1f;

        rb.AddTorque(Vector3.up * turn * turnSpeed);
        
    }

    private void LateUpdate()
    {

    }


}
