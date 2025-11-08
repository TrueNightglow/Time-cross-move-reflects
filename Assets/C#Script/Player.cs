using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    #region anim
    private Animator anim;
    private bool ismoving;
    private float moveSpeed;
    #endregion
    private EntityMove entityMove;
    CameraCentralRole cameraCentralRole;
    private Vector3 initPos = new Vector3(0, 0, 0);

    private void Awake()
    {
        Instance = this;

        anim = transform.GetComponent<Animator>();
        cameraCentralRole = GameObject.Find("Camera").GetComponent<CameraCentralRole>();
        entityMove = GetComponent<EntityMove>();
    }
    void Start()
    {
        //cameraCentralRole.InitCamera(transform);
        transform.position = initPos;

        anim.SetBool("Move", ismoving);
        anim.SetFloat("Speed", moveSpeed);
    }
    void Update()
    {
        CheckInput();
    }

    public void CheckInput()
    {
        Quaternion rot = Quaternion.Euler(0, cameraCentralRole.yaw, 0);

        Vector3 input = rot * Vector3.forward * Input.GetAxisRaw("Vertical")
                                + Vector3.up * Input.GetAxis("Jump")
                                + rot * Vector3.right * Input.GetAxisRaw("Horizontal");
        //相对摄像机方向移动
        entityMove.SetMoveInput(input);
    }
}
