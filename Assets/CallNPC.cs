using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallNPC : MonoBehaviour
{
    public IdleMovement npc;
    public bool onTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Call"))
        {
            Debug.Log("Trigger worked");
            onTrigger = true;
            StartCoroutine(npc.StopMovement());
            StartCoroutine(npc.TurnToPlayer());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Call"))
        {
            StartCoroutine(npc.StartMovement());
            onTrigger = false;
        }
    }
}
