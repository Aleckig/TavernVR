using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CustomScript : MonoBehaviour
{
    [SerializeField] private GameObject moveContoller;
    [SerializeField] private TeleportationAnchor tpAnchor;

    private bool toggle = false;


    public void DisableMove()
    {
        moveContoller.SetActive(toggle);
        if (toggle)
            tpAnchor.enabled = true;
        else tpAnchor.enabled = false;
        toggle = !toggle;
    }
}
