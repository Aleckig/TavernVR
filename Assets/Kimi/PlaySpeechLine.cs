using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySpeechLine : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    public AudioClip[] audioClips;
    public bool inProgress;
    void Start()
    {
        inProgress = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && inProgress)
        {
            audioClip = audioClips[Random.Range(0, audioClips.Length)];
            audioSource.PlayOneShot(audioClip);
            inProgress = false;
        }
    }
}
