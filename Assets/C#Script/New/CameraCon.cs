using UnityEngine;

public class CameraCon : MonoBehaviour
{
    Transform tf;
    float yaw;
    [SerializeField]float mouseSpeed;

    private void Awake()
    {
        tf = GameObject.Find("Player").transform;
    }
    void Update()
    {
        transform.position = tf.position;
        yaw += Input.GetAxis("Mouse X") * mouseSpeed;
        transform.rotation = Quaternion.Euler(0, yaw, 0);
    }
}
