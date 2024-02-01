using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MechPayMoney : MonoBehaviour
{
    [Header("Debug")]
    public int startedVal = 0;
    [Header("Coins Setup")]
    [SerializeField] private int valueOfBronze = 10;
    [SerializeField] private int valueOfSilver = 50;
    [SerializeField] private int valueOfGold = 200;
    [SerializeField] private GameObject CoinPrefabBronze;
    [SerializeField] private GameObject CoinPrefabSilver;
    [SerializeField] private GameObject CoinPrefabGold;

    [Header("Links to TMP")]
    [SerializeField] private TMP_Text priceText;
    [SerializeField] private TMP_Text currentAmountText;
    private bool activated = false;
    private int price = 0;
    private int currentAmount = 0;
    public List<Collider> coinObjects = new();

    private void Start()
    {
        //StartPaying(startedVal);
    }

    public void StartPaying(int priceValue)
    {
        activated = true;
        price = priceValue;
        currentAmountText.color = Color.white;
        UpdateUIDisplay();
    }
    public void ResetProcess()
    {
        activated = false;

        foreach (Collider coin in coinObjects)
        {
            Destroy(coin.gameObject.transform.parent);
        }
        coinObjects.Clear();

        priceText.text = "Price:";
        currentAmountText.text = "Payed";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!activated) return;

        ChangeCurrentAmount(true, other.tag);
        UpdateUIDisplay();

        switch (other.tag)
        {
            case "Bronze":
            case "Silver":
            case "Gold":
                coinObjects.Add(other);
                break;
        }

        if (currentAmount >= price)
            ResetProcess();
    }
    private void OnTriggerExit(Collider other)
    {
        if (!activated) return;

        ChangeCurrentAmount(false, other.tag);
        UpdateUIDisplay();

        coinObjects.Remove(other);
    }

    private void ChangeCurrentAmount(bool operetionPlus, string tagName)
    {
        int valueForChange = 0;

        switch (tagName)
        {
            case "Bronze":
                valueForChange += valueOfBronze;
                break;
            case "Silver":
                valueForChange += valueOfSilver;
                break;
            case "Gold":
                valueForChange += valueOfGold;
                break;
        }

        currentAmount += operetionPlus ? valueForChange : valueForChange * -1;
    }

    private void UpdateUIDisplay()
    {
        int tempPrice = price;

        int numberOfGoldCoin = tempPrice / valueOfGold;
        tempPrice -= numberOfGoldCoin * valueOfGold;
        int numberOfSilverCoin = tempPrice / valueOfSilver;
        tempPrice -= numberOfSilverCoin * valueOfSilver;
        int numberOfBronzeCoin = tempPrice / valueOfBronze;

        string goldStr = numberOfGoldCoin > 0 ? numberOfGoldCoin + " Gold" : "";
        string silverStr = numberOfSilverCoin > 0 ? numberOfSilverCoin + " Silver" : "";
        string bronzeStr = numberOfBronzeCoin > 0 ? numberOfBronzeCoin + " Bronze" : "";

        priceText.text = $"Price: {goldStr} {silverStr} {bronzeStr}";

        if (currentAmount >= price)
            currentAmountText.color = Color.green;
        else currentAmountText.color = Color.red;
    }

    private void ReturnRest() { }
}
