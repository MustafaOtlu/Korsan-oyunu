using UnityEngine;

public class ConnonController : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject grayBullet;
    public GameObject greenBullet;
    public GameObject redBullet;

    [Header("Side")]
    [SerializeField] bool SagKonum = true;

    [Header("Rotation")]
    [SerializeField] float rotasyon_speed = 60f;

    float dikeyAci;
    GameObject SelectedBullet;

    Quaternion baslangicRotasyonu;


    void Start()
    {
        // Sað / sol farkýný burada sabitliyoruz
        baslangicRotasyonu = transform.localRotation;
    }

    

    void Update()
    {
        RotasyonuBelirle();
    }

    void RotasyonuBelirle()
    {
        float input = 0f;

        if (Input.GetKey(KeyCode.E)) input = -1f;
        if (Input.GetKey(KeyCode.Q)) input = 1f;

        dikeyAci += input * rotasyon_speed * Time.deltaTime;

        if (SagKonum)
        {
            // Sað top aþaðý doðru bakar
            dikeyAci = Mathf.Clamp(dikeyAci, -50f, 0f);
        }
        else
        {
            // Sol top yukarý doðru bakar
            dikeyAci = Mathf.Clamp(dikeyAci, 0f, 50f);
        }

        Quaternion dikeyRotasyon = Quaternion.AngleAxis(dikeyAci, Vector3.right);

        transform.localRotation = baslangicRotasyonu * dikeyRotasyon;
    }

    void Attack(GameObject bullet)
    {
        
    }

    void BulletSelector()
    {
        SelectedBullet = Input.GetKeyDown(KeyCode.Alpha1)
            ? grayBullet
            : Input.GetKeyDown(KeyCode.Alpha2)
                ? greenBullet
                : Input.GetKeyDown(KeyCode.Alpha3)
                ? redBullet : grayBullet;
        Debug.Log(SelectedBullet.name);
    }

}
