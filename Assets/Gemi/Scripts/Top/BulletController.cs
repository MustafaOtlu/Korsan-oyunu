using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawnPos;

    [SerializeField] float mermiHizi = 5f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MermiAtesle();
        }
    }

    void MermiAtesle()
    {
        GameObject mermi = Instantiate(
            bulletPrefab,
            bulletSpawnPos.position,
            bulletSpawnPos.rotation
        );

        Rigidbody rb = mermi.GetComponent<Rigidbody>();

        if (rb != null)
        {
            // local +Y yönü ? spawn noktasýnýn yukarýsý
            Vector3 yon = bulletSpawnPos.up;

            rb.AddForce(yon * mermiHizi, ForceMode.Impulse);
        }
    }
}
