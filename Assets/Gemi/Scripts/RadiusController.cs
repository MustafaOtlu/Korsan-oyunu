using Unity.Cinemachine;
using UnityEngine;

public class RadiusController : MonoBehaviour
{
    public CinemachineOrbitalFollow CameraCinemachine;

    [Range(10f, 55f)]
    public float range;
    public float scroll_speed = 5;
    void Start()
    {
        CameraCinemachine.Radius = range;
    }

    // Update is called once per frame
    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        range -= scroll * scroll_speed;
        range = Mathf.Clamp(range, 10, 55);
        CameraCinemachine.Radius = range;
    }
}
