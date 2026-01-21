using UnityEngine;

public class GalgaConrtoller : MonoBehaviour
{
    public float speed = 2f;
    public float speed_rot = 2f;
    public float amplitude = 1f;
    public float rotasyon = 1f;

    Vector3 startEuler;

    void Start()
    {
        startEuler = transform.localEulerAngles;
    }


    void Update()
    {
        float offset = Mathf.Sin(Time.time * speed) * amplitude;
        float r = Mathf.PingPong(Time.time * speed_rot, 15f) - 7.5f;

        transform.localPosition = new Vector3(0f, offset, 0f);
        transform.localRotation = Quaternion.Euler(
            startEuler.x,
            startEuler.y,
            startEuler.z + r
        );
    }


}
