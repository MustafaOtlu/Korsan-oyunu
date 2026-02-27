using UnityEngine;

public class GemiHareket : MonoBehaviour
{
    Rigidbody rb;

    [Header("Movement")]
    public float maxSpeed = 5f;
    public float acceleration = 3f; // gaz  
    public float deceleration = 4f; //fren
    

    [Header("Rotation")]
    public float rotationSpeed = 60f;

    float currentSpeed;
    float vertical;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.interpolation = RigidbodyInterpolation.Interpolate;
    }

    void Update()
    {
        vertical = Input.GetKey(KeyCode.D) ? 1f :
                   Input.GetKey(KeyCode.A) ? -1f : 0f;
    }

    [System.Obsolete]
    void FixedUpdate()
    {
        // ÝLERÝ HIZ KONTROLÜ
        if (Input.GetKey(KeyCode.W))
        {
            currentSpeed += acceleration * Time.fixedDeltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            currentSpeed -= deceleration * Time.fixedDeltaTime;
        }
        else
        {
            // Tuþ yoksa yavaþça dur
            currentSpeed -= deceleration * 0.5f * Time.fixedDeltaTime;
        }

        // GERÝ GÝTMEYÝ ENGELLE
        currentSpeed = Mathf.Clamp(currentSpeed, 0f, maxSpeed);

        // HAREKET
        Vector3 forwardMove = transform.forward * currentSpeed;
        rb.velocity = new Vector3(forwardMove.x, rb.velocity.y, forwardMove.z);

        // DÖNÜÞ (sadece hareket ederken)
        if (currentSpeed > 0.1f)
        {
            Quaternion turn = Quaternion.Euler(0f, vertical * rotationSpeed * Time.fixedDeltaTime, 0f);
            rb.MoveRotation(rb.rotation * turn);
        }
    }
}
