using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySpeechLine : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    public AudioClip[] audioClips;
    void Start()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioClip = audioClips[Random.Range(0, audioClips.Length)];
            audioSource.PlayOneShot(audioClip);
        }
    }
}
