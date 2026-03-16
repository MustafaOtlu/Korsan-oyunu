using UnityEngine;
using Unity.Cinemachine;

public class FreeLookCamController : MonoBehaviour
{
    CinemachineOrbitalFollow Orbital;
    CinemachineInputAxisController input;
    public Transform GemiPos;

    [Header("Smooth Geçiþ Ayarlarý")]
    public float donusHizi = 5f;

    private void Start()
    {
        Orbital = GetComponent<CinemachineOrbitalFollow>();
        input = GetComponent<CinemachineInputAxisController>();
    }

    private void Update()
    {
        input.enabled = Input.GetMouseButton(1);

        if (!Input.GetMouseButton(1))
        {

            Orbital.VerticalAxis.Value = Mathf.Lerp(
                Orbital.VerticalAxis.Value,
                45f,
                Time.deltaTime * donusHizi
            );

            Orbital.HorizontalAxis.Value = Mathf.LerpAngle(
                Orbital.HorizontalAxis.Value,
                GemiPos.eulerAngles.y,
                Time.deltaTime * donusHizi
            );
        }
    }
}