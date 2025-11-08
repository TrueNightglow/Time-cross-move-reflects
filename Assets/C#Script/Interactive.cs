using UnityEngine;

public class Interactive : MonoBehaviour
{
    GameObject interactUI;
    private void Awake()
    {
        interactUI = GameObject.Find("InteractiveCanvas");
        interactUI.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        interactUI.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        interactUI.SetActive(false);
    }
}