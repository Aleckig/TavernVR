using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class CustomScript : MonoBehaviour
{
    [SerializeField] private GameObject moveContoller;
    [SerializeField] private TeleportationAnchor tpAnchor;
    [SerializeField] private GameObject rightHand;
    private bool toggle = false;
    string tagName = "";

    public void DisableMove()
    {
        CastRay();
        if (tagName == "Chair" && toggle == false)
        {
            StartCoroutine(ToggleMovement(toggle));
            toggle = true;
        }
    }
    public void EnableMove()
    {
        CastRay();
        if (tagName != "Chair")
        {
            StartCoroutine(ToggleMovement(true));
            toggle = false;
        }
    }

    private IEnumerator ToggleMovement(bool status)
    {
        yield return new WaitForSeconds(.1f);
        moveContoller.SetActive(status);
        if (status)
            tpAnchor.enabled = true;
        else tpAnchor.enabled = false;
        yield break;
    }
    public void CastRay()
    {
        RaycastHit hit;
        if (Physics.Raycast(rightHand.transform.position, rightHand.transform.TransformDirection(Vector3.forward), out hit))
        {
            Debug.Log(hit.collider.tag);
            tagName = hit.collider.tag;
        }
    }
}
