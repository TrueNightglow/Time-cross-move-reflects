using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    private EntityMove entityMove;
    CameraCentralRole cameraCentralRole;
    private Vector3 initPos = new Vector3(0, 0, 0);

    private void Awake()
    {
        Instance = this;

        cameraCentralRole = GameObject.Find("Camera").GetComponent<CameraCentralRole>();
        entityMove = GetComponent<EntityMove>();
    }
    void Start()
    {
        cameraCentralRole.InitCamera(transform);
        transform.position = initPos;
    }
    void Update()
    {
        CheckInput();
    }

    public void CheckInput()
    {
        Quaternion rot = Quaternion.Euler(0, cameraCentralRole.yaw, 0);

        Vector3 input = rot * Vector3.forward * Input.GetAxisRaw("Vertical")
                                //��Ծѡ�����Ծ������ѡ��
                                + Vector3.up * Input.GetAxis("Jump")
                                //��Ծѡ�������Ծ������ѡ��
                                //+ new Vector3(0, 0, 0)
                                + rot * Vector3.right * Input.GetAxisRaw("Horizontal");
        //�������������ƶ�
        entityMove.SetMoveInput(input);
    }
}
