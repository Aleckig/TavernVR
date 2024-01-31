using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallNPC : MonoBehaviour
{
    public IdleMovement npc;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Call"))
        {
        Debug.Log("Trigger worked");
        StartCoroutine(npc.StopMovement());
        }
    }
}
