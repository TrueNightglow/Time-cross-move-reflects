using UnityEngine;
using UnityEngine.UI;

public enum SpaceTime { Future, Past, now }

public class PlayerState : MonoBehaviour
{
    public static bool oneone = false;
    public static bool onetwo = false;
    public static bool passFirst = false;
    public static bool twoone = false;
    public static bool twotwo = false;
    public bool winGame = false;
    private GameObject win;

    public static PlayerState Instance;
    GameObject obj;
    Image spaceTime;
    private SpaceTime _space;
    public SpaceTime space
    {
        get => _space;
        set
        {
            switch (value)
            {
                case SpaceTime.now:
                    spaceTime.color = new Color();
                    break;
                case SpaceTime.Future:
                    spaceTime.color = new Color(0.5504183f, 0.8683112f, 0.8773585f, 0.1686275f);
                    break;
                case SpaceTime.Past:
                    spaceTime.color = new Color(0.8773585f, 0.4428177f, 0.6641893f, 0.1686275f);
                    break;
            }
            _space = value;
        }
    }

    private void Awake()
    {
        Instance = this;
        spaceTime = GameObject.Find("Canvas/SpaceTime").GetComponent<Image>();
        win = GameObject.Find("Canvas/WinGame");
        win.SetActive(false);

        space = SpaceTime.now;
    }
    private void Update()
    {
        if (oneone && onetwo)
            passFirst = true;
        if (twoone && twotwo)
            winGame = true;
        if (winGame)
            win.SetActive(true);

        ChangeSpaceTime();
    }

    private void ChangeSpaceTime()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (space == SpaceTime.now)
                space = SpaceTime.Future;
            else if (space == SpaceTime.Future)
                space = SpaceTime.now;
        }
        if (Input.GetButtonDown("Squat"))
        {
            if (space == SpaceTime.now)
                space = SpaceTime.Past;
            else if (space == SpaceTime.Past)
                space = SpaceTime.now;
        }
    }
    public void ChangeObj(GameObject _obj)
    {
        obj = _obj;
    }
}
