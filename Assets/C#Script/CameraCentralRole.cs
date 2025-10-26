using UnityEngine;

public class CameraCentralRole : MonoBehaviour
{
    private Transform target;
    #region ThirdPerson
    public float pitch { get; private set; }
    public float yaw { get; private set; }
    public float mouseSensitivity = 0;
    #endregion

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        UpdateCameraPosition();
        if (!Cursor.visible)
        {
            UpdateRotation();
        }
        MouseControl();
    }

    public void InitCamera(Transform _target)
    {
        target = _target;
        transform.position = _target.position;
        transform.rotation = new Quaternion(0, 0, 0, 0);
    }
    //更新摄像机位置
    private void UpdateCameraPosition()
    {
        transform.position = target.position;
    }
    private static void MouseControl()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
        if (Input.GetKeyUp(KeyCode.LeftAlt))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    //更新摄像头旋转方向
    private void UpdateRotation()
    {
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch += Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, -75, 75);

        transform.rotation = Quaternion.Euler(-pitch, yaw, 0);
    }
}
