using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatingDrinking : MonoBehaviour
{
    // Define the eating and drinking sounds
    public AudioClip eatingSound;
    public AudioClip drinkingSound;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object is a food object
        if (other.CompareTag("Food"))
        {
            // Play the eating sound
            PlaySound(eatingSound);
            // Destroy the food object
            Destroy(other.gameObject);
        }
        // Check if the collided object is a drink object
        else if (other.CompareTag("Drink"))
        {
            // Play the drinking sound
            PlaySound(drinkingSound);
            // Destroy the drink object
            Destroy(other.gameObject);
        }
    }

    private void PlaySound(AudioClip sound)
    {
        // Play the specified sound
        if (sound != null)
        {
            AudioSource.PlayClipAtPoint(sound, transform.position);
        }
    }
}
