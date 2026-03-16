using System.Collections.Generic;
using UnityEngine;

// Serileþtirilebilir sýnýf ki JSON ile kolayca kaydedebilesin
[System.Serializable]
public class InventorySlot
{
    public ItemData item;
    public int amount;

    public InventorySlot(ItemData item, int amount)
    {
        this.item = item;
        this.amount = amount;
    }
}

public class ShipInventory : MonoBehaviour
{
    // Envanterdeki eþyalarýn listesi
    [SerializeField] private List<InventorySlot> slots = new List<InventorySlot>();

    // Maksimum taþýma kapasitesi
    [SerializeField] private int maxSlots = 20;

    public void AddItem(ItemData itemToAdd, int amount)
    {
        // 1. Eþya zaten envanterde var mý kontrol et (Stackleme)
        foreach (InventorySlot slot in slots)
        {
            if (slot.item == itemToAdd)
            {
                slot.amount += amount;
                Debug.Log($"{itemToAdd.ItemName} eklendi. Yeni miktar: {slot.amount}");
                return;
            }
        }

        // 2. Eþya yoksa ve yerimiz varsa yeni slot oluþtur
        if (slots.Count < maxSlots)
        {
            slots.Add(new InventorySlot(itemToAdd, amount));
            Debug.Log($"{itemToAdd.ItemName} envantere yeni bir bölmeye eklendi.");
        }
        else
        {
            Debug.LogWarning("Envanter dolu!");
        }
    }
}