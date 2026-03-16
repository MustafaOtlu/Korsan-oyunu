using UnityEngine;

public class ShipCombat : MonoBehaviour
{
    [Header("Combat Settings")]
    public float fireForce = 50f;       // Ýleri doðru fýrlama hýzý
    public float upwardForce = 5f;      // Havaya doðru kavis verme gücü (YENÝ)
    public float fireRate = 2f;

    [Header("Ammunition (Mühimmat)")]
    public GameObject[] cannonballPrefabs;
    private int currentAmmoIndex = 0;

    [Header("Cannons (Toplar)")]
    public GameObject[] leftCannons;
    public GameObject[] rightCannons;

    private float _nextLeftFireTime = 0f;
    private float _nextRightFireTime = 0f;

    void Update()
    {
        SwitchAmmo();

        // 1 Tuþu -> Ýskele (Sol) Ateþ
        if (Input.GetKeyDown(KeyCode.Alpha1) && Time.time >= _nextLeftFireTime)
        {
            FireCannons(leftCannons);
            _nextLeftFireTime = Time.time + fireRate;
        }

        // 4 Tuþu -> Sancak (Sað) Ateþ
        if (Input.GetKeyDown(KeyCode.Alpha4) && Time.time >= _nextRightFireTime)
        {
            FireCannons(rightCannons);
            _nextRightFireTime = Time.time + fireRate;
        }
    }

    private void SwitchAmmo()
    {
        if (cannonballPrefabs.Length == 0) return;

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentAmmoIndex++;
            if (currentAmmoIndex >= cannonballPrefabs.Length) currentAmmoIndex = 0;
            Debug.Log("Seçili Mermi: " + cannonballPrefabs[currentAmmoIndex].name);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentAmmoIndex--;
            if (currentAmmoIndex < 0) currentAmmoIndex = cannonballPrefabs.Length - 1;
            Debug.Log("Seçili Mermi: " + cannonballPrefabs[currentAmmoIndex].name);
        }
    }

    private void FireCannons(GameObject[] cannons)
    {
        if (cannonballPrefabs.Length == 0) return;

        GameObject selectedBullet = cannonballPrefabs[currentAmmoIndex];

        foreach (GameObject cannon in cannons)
        {
            if (cannon != null && cannon.activeInHierarchy)
            {
                if (cannon.transform.childCount > 0)
                {
                    Transform spawnPoint = cannon.transform.GetChild(0);

                    GameObject ball = Instantiate(selectedBullet, spawnPoint.position, spawnPoint.rotation);
                    Rigidbody rb = ball.GetComponent<Rigidbody>();

                    if (rb != null)
                    {
                        // YENÝ: Hem ileri (forward) hem de yukarý (up) güç uyguluyoruz
                        Vector3 fireDirection = (spawnPoint.forward * fireForce) + (Vector3.up * upwardForce);
                        rb.AddForce(fireDirection, ForceMode.Impulse);
                    }
                }
                else
                {
                    Debug.LogWarning($"{cannon.name} objesinin altýnda 'Bullet Spawn pos' bulunamadý!");
                }
            }
        }
    }
}