using UnityEngine;

public class MouseClick3D : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Sol týk
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Týklanan Obje: " + hit.collider.gameObject.name);
            }
        }
    }
}
