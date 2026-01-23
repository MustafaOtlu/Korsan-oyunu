using System.Collections;
using UnityEngine;

public class MouseClick3D : MonoBehaviour
{
    [Header("Points")]
    public GameObject[] points;   // 0: Market, 1: Tamirci, 2: Kiþi

    [Header("UI")]
    public GameObject[] Panels;

    [Header("Player")]
    public GameObject Gemi;

    [Header("Settings")]
    public float AlgilamaUzakligi = 5f;

    bool isProcessingClick = false;

    void Update()
    {
        if (!Input.GetMouseButtonDown(0))
            return;

        if (isProcessingClick)
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, out RaycastHit hit))
            return;

        if (!hit.collider.CompareTag("Terrain"))
            return;

        int enYakinIndex = EnYakiniBul();
        if (enYakinIndex == -1)
            return;

        if (!TiklanabilirMi(enYakinIndex))
            return;

        StartCoroutine(HandleClick(enYakinIndex));
    }

    IEnumerator HandleClick(int index)
    {
        isProcessingClick = true;

        yield return null; // UI Job System çakýþmasýný önler

        PanelleriKapat();

        if (index >= 0 && index < Panels.Length)
        {
            Panels[index].SetActive(true);
        }

        isProcessingClick = false;
    }

    int EnYakiniBul()
    {
        if (points == null || points.Length == 0 || Gemi == null)
            return -1;

        float enYakinMesafe = float.MaxValue;
        int enYakinIndex = -1;

        Vector3 gemiPos = Gemi.transform.position;

        for (int i = 0; i < points.Length; i++)
        {
            if (points[i] == null) continue;

            float mesafe = (gemiPos - points[i].transform.position).sqrMagnitude;

            if (mesafe < enYakinMesafe)
            {
                enYakinMesafe = mesafe;
                enYakinIndex = i;
            }
        }

        return enYakinIndex;
    }

    bool TiklanabilirMi(int index)
    {
        if (index < 0 || index >= points.Length)
            return false;

        float mesafe = Vector3.Distance(
            Gemi.transform.position,
            points[index].transform.position
        );

        return mesafe < AlgilamaUzakligi;
    }

    void PanelleriKapat()
    {
        if (Panels == null) return;

        for (int i = 0; i < Panels.Length; i++)
        {
            if (Panels[i] != null)
                Panels[i].SetActive(false);
        }
    }
}
