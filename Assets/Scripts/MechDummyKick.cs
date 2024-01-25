using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechDummyKick : MonoBehaviour
{
    [SerializeField] private List<GameObject> coinsPrefabsList = new();
    [SerializeField] private float chanceForGold = .1f;
    [SerializeField] private float chanceForSilver = .25f;
    [SerializeField] private float chanceForBronze = .65f;
    [SerializeField] private float delayInGeneration = 1f;
    [SerializeField] private float rotationAnimAngle = 30f;
    [SerializeField] private string collisionTag = "Hand";

    // Start is called before the first frame update
    private void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
