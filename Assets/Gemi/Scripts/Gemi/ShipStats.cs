using UnityEngine;

public class ShipStats : MonoBehaviour
{
    [Header("Ship Values")]
    [SerializeField] private string shipName = "Black Pearl";
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private float maxSpeed = 50f;
    [SerializeField] private float acceleration = 15f;
    [SerializeField] private float deceleration = 20f;
    [SerializeField] private float rotationSpeed = 15f;

    [Header("Progress")]
    [SerializeField] private int silver = 100;
    [SerializeField] private int reputation = 0;

    // Geminin o anki caný
    private int _currentHealth;

    private void Awake()
    {
        _currentHealth = maxHealth;
    }

    // Parayý artýrmak/azaltmak için güvenli bir metot
    public void AddSilver(int amount)
    {
        silver += amount;
        if (silver < 0) silver = 0;
        // Ýstersen buraya "Para güncellendi" event'i tetikleyebilirsin (UI için)
    }

    // Gemi hasar aldýðýnda çaðrýlacak metot
    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log($"{shipName} battý!");
    }
}