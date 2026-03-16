using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cannonball : MonoBehaviour
{
    [Header("Settings")]
    public int damage = 20;      
    public float lifeTime = 5f;   
                                  

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Mermi {other.gameObject.name} objesine çarptý ve patladý!");
        Destroy(gameObject);
    }
}