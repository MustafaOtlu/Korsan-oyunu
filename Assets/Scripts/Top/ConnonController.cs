using UnityEngine;

public class ConnonController : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject grayBullet;
    public GameObject greenBullet;
    public GameObject redBullet;
    public Transform SpawnPos;
    public float forceAmount = 15f;
    public float fireRate = 2f;
    float nextFireTime = 0f;

    [Header("Side Settings")]
    [SerializeField] bool SagKonum = true;
    KeyCode fireKey;

    [Header("Rotation")]
    [SerializeField] float rotasyon_speed = 60f;
    // X rotasyonu için mevcut deðer (Inspector'daki X deðeri gibi düþün)
    float mevcutXRotasyonu = 0f;

    GameObject SelectedBullet;

    void Start()
    {
        // Baþlangýçtaki X rotasyonunu alalým
        mevcutXRotasyonu = transform.localEulerAngles.x;
        SelectedBullet = grayBullet;

        // Sað top için 1, Sol top için 4 tuþu ateþleme yapar
        fireKey = SagKonum ? KeyCode.Alpha4 : KeyCode.Alpha1;
    }

    void Update()
    {
        RotasyonuGuncelle();
        BulletSelector();
        Attack();
    }

    void RotasyonuGuncelle()
    {
        float input = 0f;
        // Q ile artar, E ile azalýr demiþtin
        if (Input.GetKey(KeyCode.Q)) input = 1f;
        if (Input.GetKey(KeyCode.E)) input = -1f;

        // X deðerini zamanla deðiþtir
        mevcutXRotasyonu += input * rotasyon_speed * Time.deltaTime;

        // X rotasyonunu -25 ile 5 derece arasýnda sýnýrla
        mevcutXRotasyonu = Mathf.Clamp(mevcutXRotasyonu, -25f, 5f);

        // Yeni rotasyonu objeye uygula (Y ve Z'yi sabit tutuyoruz)
        transform.localEulerAngles = new Vector3(mevcutXRotasyonu, transform.localEulerAngles.y, transform.localEulerAngles.z);
    }

    void Attack()
    {
        // Sadece kendi tarafýnýn tuþu (1 veya 4) ve süresi
        if (Input.GetKeyDown(fireKey) && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;

            GameObject b = Instantiate(SelectedBullet, SpawnPos.position, SpawnPos.rotation);
            Rigidbody b_rb = b.GetComponent<Rigidbody>();

            if (b_rb != null)
            {
                // Mermiyi ileri (veya yukarý, modeline göre) fýrlat
                b_rb.AddForce(SpawnPos.up * forceAmount, ForceMode.Impulse);
            }

            Destroy(b, 10f);
        }
    }

    void BulletSelector()
    {
        // 1 ve 4 ateþleme için ayrýldýðý için mermi seçimini Z, X, C yaptýk
        if (Input.GetKeyDown(KeyCode.Z)) SelectedBullet = grayBullet;
        if (Input.GetKeyDown(KeyCode.X)) SelectedBullet = greenBullet;
        if (Input.GetKeyDown(KeyCode.C)) SelectedBullet = redBullet;
    }
}