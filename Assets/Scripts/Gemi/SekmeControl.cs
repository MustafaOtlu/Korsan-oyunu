using System.Collections;
using UnityEngine;

public class SekmeControl : MonoBehaviour
{
    [Header("Sekme Ayarlarý")]
    // Force kullandýðýmýz için deðeri geminin kütlesine göre (örneðin 500-1000 arasý) ayarlayabilirsin
    public float sekmeGucu = 500f;
    public float sekmeSuresi = 1f; // Ne kadar süre itileceði

    private Rigidbody rb;
    private bool isBouncing = false; // Ayný anda birden fazla itme olmasýný engeller

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Terrain") && !isBouncing)
        {
            Vector3 sekmeYonu = collision.contacts[0].normal;


            sekmeYonu.y = 0;
            sekmeYonu.Normalize();

            StartCoroutine(Tepme(sekmeYonu));
        }
    }

    IEnumerator Tepme(Vector3 sekmeYonu)
    {
        isBouncing = true; // Ýtme baþladý, baþka itme kabul etme
        float gecenSure = 0f;

        while (gecenSure < sekmeSuresi)
        {
            if (rb != null)
            {
                rb.AddForce(sekmeYonu * sekmeGucu*2000, ForceMode.Force);
            }
            gecenSure += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        isBouncing = false;
    }
}