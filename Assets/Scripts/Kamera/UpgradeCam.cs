using UnityEngine;

public class UpgradeCam : MonoBehaviour
{
    public Transform Target;
    public float X = 5f;
    public float Y = 5f;
    public float Z = 5f;

    private void LateUpdate()
    {
        if (gameObject!=null)
        {
            gameObject.transform.position = new Vector3(Target.position.x + X, Target.transform.position.y + Y , Target.position.z + Z);
        }
    }
}
