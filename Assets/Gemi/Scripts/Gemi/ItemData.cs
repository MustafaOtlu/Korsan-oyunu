using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Seals of the Sea/Item")]
public class ItemData : ScriptableObject
{
    [Header("Item Info")]
    [SerializeField] private string itemName;
    [SerializeField] private ItemRarity rarity;
    [SerializeField] private int pricing;

    [Header("Visuals")]
    [SerializeField] private Sprite icon; // Envanterde göstermek için
    [SerializeField] private GameObject prefab; // Yere atmak/gemiye koymak için

    // Kapsülleme: Diðer kodlar veriyi okuyabilir ama deðiþtiremez (Sadece Get)
    public string ItemName => itemName;
    public ItemRarity Rarity => rarity;
    public int Pricing => pricing;
    public Sprite Icon => icon;
    public GameObject Prefab => prefab;
}

public enum ItemRarity
{
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary
}

