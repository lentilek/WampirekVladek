using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VladekNeeds : MonoBehaviour
{
    public static VladekNeeds Instance;

    public float sleepNeed;
    public float sleepLostPerSecond;
    public float sleepRise;
    public Image sleepFill;
    public bool isSleeeping;
    public Toggle sleepButton;

    public float hungerNeed;
    public float hungerLostPerSecond;
    public GameObject hungerMenu;
    public bool isHungerMenuOn;
    public float hungerFood1Rise;
    public float hungerFood2Rise;
    public float hungerFood3Rise;
    public float sleepFood3Rise;
    public Image hungerFill;

    public float funNeed;
    public float funLostPerSecond;
    public float funRise;
    public Image funFill;
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
    void Start()
    {
        sleepNeed = 1;
        GetFill(sleepNeed, sleepFill);
        //StartCoroutine(SleepLost());
        isSleeeping = false;
        sleepButton.isOn = isSleeeping;

        hungerNeed = 1f;
        isHungerMenuOn = false;
        hungerMenu.SetActive(false);
        GetFill(hungerNeed, hungerFill);
        StartCoroutine(HungerLost());

        funNeed = 1f;
        GetFill(funNeed, funFill);
        StartCoroutine(FunLost());
    }
    public void StartLosingSleep()
    {
        StartCoroutine(SleepLost());
    }
    IEnumerator SleepLost()
    {
        if (sleepNeed > 1f)
        {
            sleepNeed = 1f;
        }
        yield return new WaitForSeconds(1);
        sleepNeed -= sleepLostPerSecond;
        sleepNeed = Mathf.Round(sleepNeed * 1000.0f) * 0.001f;
        GetFill(sleepNeed, sleepFill);
        if(MiniGameManager.Instance.isMiniGameOn)
        {
            StartCoroutine(SleepLost());
        }
    }
    IEnumerator HungerLost()
    {
        if (hungerNeed > 1f)
        {
            hungerNeed = 1f;
        }
        yield return new WaitForSeconds(1);
        hungerNeed -= hungerLostPerSecond;
        hungerNeed = Mathf.Round(hungerNeed * 1000.0f) * 0.001f;
        GetFill(hungerNeed, hungerFill);
        StartCoroutine(HungerLost());
    }
    IEnumerator FunLost()
    {
        if (funNeed > 1f)
        {
            funNeed = 1f;
        }
        yield return new WaitForSeconds(1);
        funNeed -= funLostPerSecond;
        funNeed = Mathf.Round(funNeed * 1000.0f) * 0.001f;
        GetFill(funNeed, funFill);
        StartCoroutine(FunLost());
    }
    IEnumerator Sleeping()
    {
        if (sleepNeed > 1f)
        {
            sleepNeed = 1f;
        }
        yield return new WaitForSeconds(1);
        sleepNeed += sleepRise;
        sleepNeed = Mathf.Round(sleepNeed * 1000.0f) * 0.001f;
        GetFill(sleepNeed, sleepFill);
        if(isSleeeping)
        {
            StartCoroutine(Sleeping());
        }
    }
    IEnumerator HavingFun()
    {
        if (funNeed > 1f)
        {
            funNeed = 1f;
        }
        yield return new WaitForSeconds(1);
        funNeed += funRise;
        funNeed = Mathf.Round(funNeed * 1000.0f) * 0.001f;
        GetFill(funNeed, funFill);
        if (MiniGameManager.Instance.isMiniGameOn)
        {
            StartCoroutine(HavingFun());
        }
    }
    private void GetFill(float currentAmount, Image imageToFill)
    {
        float fill = currentAmount / 1f;
        fill = Mathf.Round(fill * 1000.0f) * 0.001f;
        imageToFill.fillAmount = fill;
    }
    public void Sleep()
    {
        isSleeeping = sleepButton.isOn;
        if(isSleeeping)
        {
            StartCoroutine(Sleeping());
        }
    }
    public void HungerFeed()
    {
        if(!isSleeeping)
        {
            if(isHungerMenuOn)
            {
                hungerMenu.SetActive(false);
                isHungerMenuOn = false;
            }
            else
            {
                hungerMenu.SetActive(true);
                isHungerMenuOn = true;
            }
            //hungerNeed += hungerRise;
            //hungerNeed = Mathf.Round(hungerNeed * 1000.0f) * 0.001f;
            //GetFill(hungerNeed, hungerFill);
        }
    }
    public void Food1()
    {
        hungerNeed += hungerFood1Rise;
        hungerNeed = Mathf.Round(hungerNeed * 1000.0f) * 0.001f;
        GetFill(hungerNeed, hungerFill);
        ShopAndMoney.Instance.food1Amount--;
        ShopAndMoney.Instance.TextUpdate(ShopAndMoney.Instance.food1AmountTXT, ShopAndMoney.Instance.food1Amount);
    }
    public void Food2()
    {
        hungerNeed += hungerFood2Rise;
        hungerNeed = Mathf.Round(hungerNeed * 1000.0f) * 0.001f;
        GetFill(hungerNeed, hungerFill);
        ShopAndMoney.Instance.food2Amount--;
        ShopAndMoney.Instance.TextUpdate(ShopAndMoney.Instance.food2AmountTXT, ShopAndMoney.Instance.food2Amount);
    }
    public void Food3()
    {
        hungerNeed += hungerFood3Rise;
        hungerNeed = Mathf.Round(hungerNeed * 1000.0f) * 0.001f;
        GetFill(hungerNeed, hungerFill);
        sleepNeed += sleepFood3Rise;
        sleepNeed = Mathf.Round(sleepNeed * 1000.0f) * 0.001f;
        GetFill(sleepNeed, sleepFill);
        ShopAndMoney.Instance.food3Amount--;
        ShopAndMoney.Instance.TextUpdate(ShopAndMoney.Instance.food3AmountTXT, ShopAndMoney.Instance.food3Amount);
    }
    public void FunPlay()
    {
        if((!isSleeeping) && (sleepNeed > 0.2f) && (hungerNeed > 0.2f))
        {
            MiniGameManager.Instance.MiniGame();
            StartCoroutine(HavingFun());
        }
    }
}
