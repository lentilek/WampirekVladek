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

    public GameObject clothes1;
    public GameObject clothes1Buy;
    public int clothes1Price;
    public GameObject clothes1Toggle;
    private bool isClothes1On;

    public GameObject clothes2;
    public GameObject clothes2Buy;
    public int clothes2Price;
    public GameObject clothes2Toggle;
    private bool isClothes2On;

    public GameObject clothes3;
    public GameObject clothes3Buy;
    public int clothes3Price;
    public GameObject clothes3Toggle;
    private bool isClothes3On;
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
        ClothesOff();
        isShopOn = false;
        shopToggle.isOn = isShopOn;
        moneyAmount = 0;
        MoneyUpdate();
        food1Amount = 0;
        food2Amount = 0;
        food3Amount = 0;

        clothes1Buy.SetActive(true);
        clothes1Toggle.SetActive(false);
        clothes2Buy.SetActive(true);
        clothes2Toggle.SetActive(false);
        clothes3Buy.SetActive(true);
        clothes3Toggle.SetActive(false);
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
            AudioManager.Instance.PlaySound("button");
            shop.SetActive(false);
            isShopOn = false;
            shopToggle.isOn = isShopOn;
        }
        else
        {
            AudioManager.Instance.PlaySound("button");
            shop.SetActive(true);
            isShopOn = true;
            shopToggle.isOn = isShopOn;
        }
    }

    public void Food1Buy()
    {
        if(moneyAmount >= food1Price)
        {
            AudioManager.Instance.PlaySound("buy");
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
            AudioManager.Instance.PlaySound("buy");
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
            AudioManager.Instance.PlaySound("buy");
            moneyAmount -= food3Price;
            food3Amount++;
            MoneyUpdate();
            TextUpdate(food3AmountTXT, food3Amount);
        }
    }
    public void Clothes1Buy()
    {
        if (moneyAmount >= clothes1Price)
        {
            AudioManager.Instance.PlaySound("buy");
            moneyAmount -= clothes1Price;
            MoneyUpdate();
            clothes1Buy.SetActive(false);
            clothes1Toggle.SetActive(true);
        }
    }
    public void Clothes1Wear()
    {
        AudioManager.Instance.PlaySound("clothes");
        if (!isClothes1On)
        {
            ClothesOff();
            clothes1.SetActive(true);
            isClothes1On = true;
            //clothes1Toggle.GetComponent<Toggle>().isOn = isClothes1On;
        }
        else
        {
            ClothesOff();
        }
    }
    public void Clothes2Buy()
    {
        if (moneyAmount >= clothes2Price)
        {
            AudioManager.Instance.PlaySound("buy");
            moneyAmount -= clothes2Price;
            MoneyUpdate();
            clothes2Buy.SetActive(false);
            clothes2Toggle.SetActive(true);
        }
    }
    public void Clothes2Wear()
    {
        AudioManager.Instance.PlaySound("clothes");
        if (!isClothes2On)
        {
            ClothesOff();
            clothes2.SetActive(true);
            isClothes2On = true;
            //clothes2Toggle.GetComponent<Toggle>().isOn = isClothes2On;
        }
        else
        {
            ClothesOff();
        }
    }
    public void Clothes3Buy()
    {
        if (moneyAmount >= clothes3Price)
        {
            AudioManager.Instance.PlaySound("buy");
            moneyAmount -= clothes3Price;
            MoneyUpdate();
            clothes3Buy.SetActive(false);
            clothes3Toggle.SetActive(true);
        }
    }
    public void Clothes3Wear()
    {
        AudioManager.Instance.PlaySound("clothes");
        if (!isClothes3On)
        {
            ClothesOff();
            clothes3.SetActive(true);
            isClothes3On = true;
            //clothes3Toggle.GetComponent<Toggle>().isOn = isClothes3On;
        }
        else
        {
            ClothesOff();
        }
    }
    public void ClothesOff()
    {
        clothes1.SetActive(false);
        clothes2.SetActive(false);
        clothes3.SetActive(false);
        isClothes1On = false;
        //clothes1Toggle.GetComponent<Toggle>().isOn = isClothes1On;
        isClothes2On = false;
        //clothes2Toggle.GetComponent<Toggle>().isOn = isClothes2On;
        isClothes3On = false;
        //clothes3Toggle.GetComponent<Toggle>().isOn = isClothes3On;
    }
    public void MainMenu()
    {
        AudioManager.Instance.PlaySound("button");
        SceneManager.LoadScene(0);
    }
}
