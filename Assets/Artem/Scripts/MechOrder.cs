using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechOrder : MonoBehaviour
{
    [SerializeField] private GameObject PlaceForMoney;
    private int orederedPrice = 0;
    public List<Collider> orderObjects = new();

    private void Start()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        switch(other.tag)
        {
            case "Food":
                orederedPrice += 100;
                orderObjects.Add(other);
                break;
            case "Drink":
                orederedPrice += 50;
                orderObjects.Add(other);
                break;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        orderObjects.Remove(other);
        if (orderObjects.Count <= 0)
            PlaceForMoney.GetComponent<MechPayMoney>().StartPaying(orederedPrice);
    }
    private void StartOrdering()
    {
    }
    private void ContinueOrdering()
    {

    }
    private void EndOrdering()
    {

    }
}
