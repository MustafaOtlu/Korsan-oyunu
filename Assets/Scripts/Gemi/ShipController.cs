using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ShipController : MonoBehaviour
{
    [Header("Ship Engine Settings")]
    public float acceleration = 15f; // Ývmelenme gücü
    public float maxSpeed = 20f;     // Maksimum hýz
    public float turnSpeed = 40f;    // Dönüþ hýzý

    private Rigidbody rb;
    private float moveInput;
    private float turnInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.interpolation = RigidbodyInterpolation.Interpolate;

        rb.constraints = RigidbodyConstraints.FreezeRotationX |
                         RigidbodyConstraints.FreezeRotationZ |
                         RigidbodyConstraints.FreezePositionY; 

        rb.linearDamping = 1f;
        rb.angularDamping = 2f;
    }

    void Update()
    {
        // Girdileri Update içinde alýyoruz (W, A, S, D)
        moveInput = Input.GetAxis("Vertical");   // W ve S
        turnInput = 0f;
        if (Input.GetKey(KeyCode.D)) turnInput = 1f;
        if (Input.GetKey(KeyCode.A)) turnInput = -1f;
    }

    void FixedUpdate()
    {
        MoveShip();
        SteerShip();
    }

    private void MoveShip()
    {
        // Ýleri/Geri kuvvet uygula
        if (moveInput > 0.1f)
        {
            Vector3 force = transform.forward * moveInput * acceleration;
            rb.AddForce(force, ForceMode.Acceleration);
        }

        // Maksimum hýzý sýnýrla
        Vector3 flatVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        if (flatVelocity.magnitude > maxSpeed)
        {
            Vector3 limitedVelocity = flatVelocity.normalized * maxSpeed;
            rb.linearVelocity = new Vector3(limitedVelocity.x, rb.linearVelocity.y, limitedVelocity.z);
        }
    }

    private void SteerShip()
    {
       
        if (rb.linearVelocity.magnitude > 1f && Mathf.Abs(turnInput) > 0.1f)
        {
            float direction = Vector3.Dot(rb.linearVelocity, transform.forward) > 0 ? 1f : -1f;

            float turn = turnInput * turnSpeed * direction * Time.fixedDeltaTime;
            Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
            rb.MoveRotation(rb.rotation * turnRotation);
        }
    }
}