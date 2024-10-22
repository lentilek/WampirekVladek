using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopAndMoney : MonoBehaviour
{
    public static ShopAndMoney Instance;

    public int moneyAmount;
    public TextMeshProUGUI moneyTXT;
    public TextMeshProUGUI moneyMiniGameTXT;
    public GameObject shop;
    public Toggle shopToggle;
    private bool isShopOn;

    public int food1Amount;
    public int food1Price;
    public TextMeshProUGUI food1AmountTXT;
    public int food2Amount;
    public int food2Price;
    public TextMeshProUGUI food2AmountTXT;
    public int food3Amount;
    public int food3Price;
    public TextMeshProUGUI food3AmountTXT;
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
        shop.SetActive(false);
        isShopOn = false;
        shopToggle.isOn = isShopOn;
        moneyAmount = 0;
        MoneyUpdate();
        food1Amount = 0;
        food2Amount = 0;
        food3Amount = 0;
    }
    public void MoneyUpdate()
    {
        moneyTXT.text = $"$ {moneyAmount}";
        moneyMiniGameTXT.text = $"$ {moneyAmount}";
    }
    public void TextUpdate(TextMeshProUGUI txt, int amount)
    {
        txt.text = amount.ToString();
    }
    public void ShopOnOff()
    {
        if(isShopOn)
        {
            shop.SetActive(false);
            isShopOn = false;
            shopToggle.isOn = isShopOn;
        }
        else
        {
            shop.SetActive(true);
            isShopOn = true;
            shopToggle.isOn = isShopOn;
        }
    }

    public void Food1Buy()
    {
        if(moneyAmount >= food1Price)
        {
            moneyAmount -= food1Price;
            food1Amount++;
            MoneyUpdate();
            TextUpdate(food1AmountTXT, food1Amount);
        }
    }
    public void Food2Buy()
    {
        if (moneyAmount >= food2Price)
        {
            moneyAmount -= food2Price;
            food2Amount++;
            MoneyUpdate();
            TextUpdate(food2AmountTXT, food2Amount);
        }
    }
    public void Food3Buy()
    {
        if (moneyAmount >= food3Price)
        {
            moneyAmount -= food3Price;
            food3Amount++;
            MoneyUpdate();
            TextUpdate(food3AmountTXT, food3Amount);
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
