using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EntityMove : MonoBehaviour
{
    private Rigidbody rb;
    public Vector3 curInput { get; private set; }
    public float moveSpeed = 0;
    public float jumpSpeed = 0;
    float rotationSpeed = 10f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.velocity = new Vector3(curInput.x * moveSpeed * Time.deltaTime,
                                  curInput.y != 0 ? curInput.y * jumpSpeed * Time.deltaTime : rb.velocity.y,
                                  curInput.z * moveSpeed * Time.deltaTime);

        //��ɫ�����ƶ�����
        transform.rotation =
            Quaternion.Lerp(transform.rotation,
                            curInput.x + curInput.z != 0
                            ? Quaternion.LookRotation(new Vector3(curInput.x, 0, curInput.z)) : transform.rotation,
                            rotationSpeed * Time.deltaTime);
    }

    //�����ƶ�����
    public void SetMoveInput(Vector3 input)
    {
        Vector3.ClampMagnitude(input, 1);
        //���߼���Ƿ��ڵ�����
        if (!Physics.Raycast(rb.position, Vector3.down, .01f))
        {
            input.y = 0;
        }
        curInput = input;
    }
}
