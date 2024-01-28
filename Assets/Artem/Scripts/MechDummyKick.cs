using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechDummyKick : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefabGold;
    [SerializeField] private float chanceForGold = .1f;
    [SerializeField] private GameObject coinPrefabSilver;
    [SerializeField] private float chanceForSilver = .25f;
    [SerializeField] private GameObject coinPrefabBronze;
    [SerializeField] private float chanceForBronze = .65f;
    [SerializeField] private float delayInGeneration = 1f;
    [SerializeField] private string collisionTag = "Weapon";
    // [SerializeField] private float rotationAnimAngle = 30f;

    bool inProgress = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered");
        // Don't generate if cooldown not ended
        if (inProgress) return;

        if (other.CompareTag(collisionTag))
        {
            StartCoroutine(GenerateCoin());
        }
    }
    private IEnumerator GenerateCoin()
    {
        inProgress = true;
        float randNum = Random.Range(0f, 1f);
        GameObject selectedPrefab = null;
        Debug.Log(randNum);
        switch (randNum)
        {
            case float i when i <= chanceForGold:
                selectedPrefab = coinPrefabGold;
                break;
            case float i when i <= (chanceForSilver + chanceForGold):
                selectedPrefab = coinPrefabSilver;
                break;
            case <= 1f:
                selectedPrefab = coinPrefabBronze;
                break;
        }


        Instantiate(selectedPrefab, transform);
        yield return new WaitForSeconds(delayInGeneration);
        inProgress = false;
        yield break;
    }
}
