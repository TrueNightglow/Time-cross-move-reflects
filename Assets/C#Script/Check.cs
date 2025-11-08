using System;
using UnityEngine;

enum CheckIN { oneone, onetwo, twoone, twotwo }

public class Check : MonoBehaviour
{
    [SerializeField] CheckIN check;

    private void OnTriggerEnter(Collider other)
    {
        switch (check)
        {
            case CheckIN.oneone:
                if (other.tag != "Interactive") return;
                PlayerState.oneone = true;
                break;
            case CheckIN.onetwo:
                if (other.tag != "Player") return;
                PlayerState.onetwo = true;
                break;
            case CheckIN.twoone:
                if (other.tag != "Interactive") return;
                if(PlayerState.passFirst) PlayerState.twoone = true;
                break;
            case CheckIN.twotwo:
                if (other.tag != "Player") return;
                if (PlayerState.passFirst) PlayerState.twotwo = true;
                break;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        switch (check)
        {
            case CheckIN.oneone:
                if (other.tag != "Interactive") return;
                PlayerState.oneone = false;
                break;
            case CheckIN.onetwo:
                if (other.tag != "Player") return;
                PlayerState.onetwo = false;
                break;
            case CheckIN.twoone:
                if (other.tag != "Interactive") return;
                PlayerState.twoone = false;
                break;
            case CheckIN.twotwo:
                if (other.tag != "Player") return;
                PlayerState.twotwo = false;
                break;
        }
    }
}
