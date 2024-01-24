using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour
{ public GameObject bubblePrefab;
    public float minSpawnInterval = 1.0f;
    public float maxSpawnInterval = 3.0f;
    public float bubbleSpeed = 1.0f;
    public float bubbleLifetime = 2.0f;
    public float spawnOffsetRange = 0.08f;

    void Start()
    {
        StartCoroutine(SpawnBubbles());
    }

    private IEnumerator SpawnBubbles()
    {
        while (true)
        {
            // Spawn a bubble with a slight random offset at the position of the BubbleController GameObject
            Vector3 spawnPosition = GetRandomSpawnPosition();
            GameObject bubbleInstance = Instantiate(bubblePrefab, spawnPosition, Quaternion.identity);

            // Move the bubble slowly upward
            StartCoroutine(MoveBubbleUpward(bubbleInstance));

            // Destroy the bubble after its lifetime
            Destroy(bubbleInstance, bubbleLifetime);

            // Wait for a random interval before spawning the next bubble
            yield return new WaitForSeconds(Random.Range(minSpawnInterval, maxSpawnInterval));
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        // Get the position of the BubbleController GameObject
        Vector3 basePosition = transform.position;

        // Introduce a slight random offset in x and z directions
        float xOffset = Random.Range(-spawnOffsetRange, spawnOffsetRange);
        float zOffset = Random.Range(-spawnOffsetRange, spawnOffsetRange);

        return basePosition + new Vector3(xOffset, 0, zOffset);
    }

    private IEnumerator MoveBubbleUpward(GameObject bubble)
    {
        while (bubble != null && bubble.transform.position.y < 10.0f) // Adjust the upper limit as needed
        {
            // Move the bubble upward
            bubble.transform.Translate(Vector3.up * bubbleSpeed * Time.deltaTime);

            yield return null;
        }
    }
}
