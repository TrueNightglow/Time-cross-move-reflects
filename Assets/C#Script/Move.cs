using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody obj;
    [SerializeField] float speed = 1.5f;

    private void Awake()
    {
        obj = GameObject.Find("Scene/InteractiveObject").GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (InterEnter.isConn)
        {
            float level = Input.GetAxisRaw("Horizontal");
            float ver = Input.GetAxisRaw("Vertical");

            Vector3 m_MoveVector = level * Vector3.right + ver * Vector3.back;
            m_MoveVector.Normalize();
            float inputSpeed = Mathf.Clamp01(Mathf.Abs(level) + Mathf.Abs(ver));
            Vector3 moveDelta = inputSpeed * m_MoveVector * speed * Time.deltaTime;
            obj.MovePosition(obj.position + moveDelta);
            obj.MovePosition(obj.position + inputSpeed * m_MoveVector * speed * Time.deltaTime);
        }
    }
}
