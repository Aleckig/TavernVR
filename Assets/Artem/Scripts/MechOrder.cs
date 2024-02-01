using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechOrder : MonoBehaviour
{
    [SerializeField] private GameObject ConvaiInputManager;
    [SerializeField] private GameObject PlaceForMoney;
    private int orederedPrice = 0;

    private void Start()
    {
        ConvaiInputManager.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {

    }
    private void StartOrdering()
    {
        ConvaiInputManager.SetActive(true);
    }
    private void ContinueOrdering()
    {

    }
    private void EndOrdering()
    {

    }
}
