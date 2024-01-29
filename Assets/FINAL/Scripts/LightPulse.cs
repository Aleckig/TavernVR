using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class LightPulse : MonoBehaviour
{
    public float minPulseSpeed = 1f;
    public float maxPulseSpeed = 5f;

    public float minIntensity = 0.5f;
    public float maxIntensity = 2f;

    public float minDuration = 2f;
    public float maxDuration = 5f;

    public Color startColor = Color.yellow;
    public Color endColor = Color.red
    ;

    private Light lightComponent;
    private float originalIntensity;
    private float pulseSpeed;
    private float durationTimer;

    void Start()
    {
        // Get the Light component attached to the GameObject
        lightComponent = GetComponent<Light>();

        // Store the original intensity for later use
        originalIntensity = lightComponent.intensity;

        // Initialize the duration timer with a random value
        durationTimer = Random.Range(minDuration, maxDuration);

        // Generate random values for pulse speed and color
        GenerateRandomValues();
    }

    void Update()
    {
        // Update the timer
        durationTimer -= Time.deltaTime;

        // Check if the duration has elapsed
        if (durationTimer <= 0f)
        {
            // Generate new random values for pulse speed, color, and duration
            GenerateRandomValues();

            // Reset the duration timer
            durationTimer = Random.Range(minDuration, maxDuration);
        }

        // Calculate the pulse effect using a sine wave
        float pulseValue = Mathf.Sin(Time.time * pulseSpeed);

        // Map the sine wave value to the intensity range
        float newIntensity = Mathf.Lerp(minIntensity, maxIntensity, (pulseValue + 1f) / 2f);

        // Apply the new intensity to the light component
        lightComponent.intensity = originalIntensity * newIntensity;

        // Change the color between startColor and endColor
        lightComponent.color = Color.Lerp(startColor, endColor, (pulseValue + 1f) / 2f);
    }

    void GenerateRandomValues()
    {
        // Generate random pulse speed within the specified range
        pulseSpeed = Random.Range(minPulseSpeed, maxPulseSpeed);
    }
}

