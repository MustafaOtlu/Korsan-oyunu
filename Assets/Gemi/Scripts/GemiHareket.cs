using UnityEngine;

public class GemiHareket : MonoBehaviour
{
    Rigidbody rb;

    [Range(5f, 50f)]
    public float speed = 20f;

    public float maxSpeed = 15f;
    public float turnSpeed = 3f;

    float horizontal;
    float vertical;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    [System.Obsolete]
    void FixedUpdate()
    {
        // Ýleri / geri hareket (baktýðý yön)
        if (vertical != 0f)
        {
            rb.AddForce(transform.forward * vertical * speed, ForceMode.Force);
        }

        // Dönüþ
        if (horizontal != 0f)
        {
            //rb.AddTorque(Vector3.up * horizontal * turnSpeed, ForceMode.Force);
            transform.Rotate(Vector3.up * horizontal * turnSpeed);
        }

        // Hýz sýnýrý (sadece yatay)
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > maxSpeed)
        {
            Vector3 limited = flatVel.normalized * maxSpeed;
            rb.velocity = new Vector3(limited.x, rb.velocity.y, limited.z);
        }
    }
}
