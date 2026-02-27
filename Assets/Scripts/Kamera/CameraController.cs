using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject sanalKameraMain;    // Etrafýnda döndüðün FreeLook kameran
    public GameObject sanalKameraUpgrade; // Geliþtirme ekraný için üstten bakan kameran

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            CamChange();
        }
    }

    public void CamChange()
    {
        
        if (sanalKameraMain.activeSelf)
        {
            sanalKameraMain.SetActive(false);
            sanalKameraUpgrade.SetActive(true);
        }
      
        else if (sanalKameraUpgrade.activeSelf)
        {
            sanalKameraUpgrade.SetActive(false);
            sanalKameraMain.SetActive(true);
        }
    }
}