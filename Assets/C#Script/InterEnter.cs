using UnityEngine;

public class InterEnter : MonoBehaviour
{
    public new Camera camera;
    Rigidbody obj;
    public static bool isConn = false;

    private void Awake()
    {
        obj = GameObject.Find("Scene/InteractiveObject").GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Interactive"))
        {
            isConn = true;
            Debug.Log("isConn");
        }
    }
    protected virtual void LateUpdate()
    {
        if (camera == null) return;

        Vector3 direction = transform.position - camera.transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = targetRotation;
    }
}
