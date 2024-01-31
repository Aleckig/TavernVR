using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatingDrinking : MonoBehaviour
{
    // Define the eating and drinking sounds
    public AudioClip eatingSound;
    public AudioClip drinkingSound;

    // Define the eating and drinking visual effects
    public GameObject eatingFX;
    public GameObject drinkingFX;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object is a food object
        if (other.CompareTag("Food"))
        {
            // Play the eating sound
            PlaySound(eatingSound);
            // Play the eating visual effect
            PlayFX(eatingFX);
            // Destroy the food object
            Destroy(other.gameObject);
        }
        // Check if the collided object is a drink object
        else if (other.CompareTag("Drink"))
        {
            // Play the drinking sound
            PlaySound(drinkingSound);
            // Play the drinking visual effect
            PlayFX(drinkingFX);
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

    private void PlayFX(GameObject fx)
    {
        // Play the specified visual effect
        if (fx != null)
        {
            Instantiate(fx, transform.position, Quaternion.identity);
            // Destroy the visual effect after a certain time (e.g., 2 seconds)
            Destroy(fx, 2f);
        }
    }
}
