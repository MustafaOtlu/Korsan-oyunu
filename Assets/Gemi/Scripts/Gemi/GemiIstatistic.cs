using UnityEngine;

public class GemiIstatistic : MonoBehaviour
{
    [Header("Gemi Ýstatistikleri")]
    static public int maksimumCan = 100;
    static public int mevcutCan;
    static public int skor = 0;

    // Oyun veya sahne baþladýðýnda otomatik olarak çalýþýr
    private void Start()
    {
        IstatistikleriYukle();
    }

    /// <summary>
    /// Geminin mevcut istatistiklerini PlayerPrefs'e kaydeder.
    /// Can veya skor her deðiþtiðinde bu fonksiyonu çaðýrabilirsin.
    /// </summary>
    public static void IstatistikleriKaydet()
    {
        PlayerPrefs.SetInt("GemiMevcutCan", mevcutCan);
        PlayerPrefs.SetInt("GemiSkor", skor);
        
        PlayerPrefs.Save(); 
        
        Debug.Log("Kayýt Baþarýlý -> Can: " + mevcutCan + " | Skor: " + skor);
    }

    /// <summary>
    /// Kayýtlý istatistikleri çeker. Kayýt yoksa varsayýlan deðerleri atar.
    /// </summary>
    public static void IstatistikleriYukle()
    {
        // "GemiMevcutCan" anahtarý yoksa (oyun ilk defa açýlýyorsa), maksimumCan deðerini kullanýr.
        mevcutCan = PlayerPrefs.GetInt("GemiMevcutCan", maksimumCan);
        
        // "GemiSkor" anahtarý yoksa, 0 deðerini kullanýr.
        skor = PlayerPrefs.GetInt("GemiSkor", 0);
        
        Debug.Log("Yükleme Baþarýlý -> Can: " + mevcutCan + " | Skor: " + skor);
    }


    public static void HasarAl(int hasarMiktari)
    {
        mevcutCan -= hasarMiktari;
        
        // Canýn sýfýrýn altýna düþmesini engelliyoruz
        if (mevcutCan < 0) 
        {
            mevcutCan = 0;
            //patlama efecti
            //game over paneli vs.

        }
        IstatistikleriKaydet();
    }

    public static void skorAl(int skorMiktari)
    {
        skor += skorMiktari;
        IstatistikleriKaydet();
    }
}