using Unity.Cinemachine;
using UnityEngine;

public class MainCamController : MonoBehaviour
{
    private CinemachineInputAxisController inputController;

    void Start()
    {
        inputController = GetComponent<CinemachineInputAxisController>();

        
        if (inputController != null)
        {
            inputController.enabled = false;
        }
    }

    void Update()
    {
        if (inputController != null)
        {
            inputController.enabled = Input.GetMouseButton(1);
        }
    }
}
