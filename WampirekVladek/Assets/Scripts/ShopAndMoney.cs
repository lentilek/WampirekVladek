using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopAndMoney : MonoBehaviour
{
    public static ShopAndMoney Instance;

    public int moneyAmount;
    public TextMeshProUGUI moneyTXT;
    public TextMeshProUGUI moneyMiniGameTXT;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(Instance.gameObject);
            Instance = this;
        }
    }
    private void Start()
    {
        moneyAmount = 0;
        MoneyUpdate();
    }
    public void MoneyUpdate()
    {
        moneyTXT.text = $"$ {moneyAmount}";
        moneyMiniGameTXT.text = $"$ {moneyAmount}";
    }
}
