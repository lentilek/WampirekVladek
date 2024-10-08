using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VladekNeeds : MonoBehaviour
{    
    public float sleepNeed;
    public float sleepLostPerSecond;
    public float sleepRise;
    public Image sleepFill;
    public bool isSleeeping;
    public Toggle sleepButton;

    public float hungerNeed;
    public float hungerLostPerSecond;
    public float hungerRise;
    public Image hungerFill;

    public float funNeed;
    public float funLostPerSecond;
    public float funRise;
    public Image funFill;
    void Start()
    {
        sleepNeed = 1;
        GetFill(sleepNeed, sleepFill);
        StartCoroutine(SleepLost());
        isSleeeping = false;
        sleepButton.isOn = isSleeeping;

        hungerNeed = 1f;
        GetFill(hungerNeed, hungerFill);
        StartCoroutine(HungerLost());

        funNeed = 1f;
        GetFill(funNeed, funFill);
        StartCoroutine(FunLost());
    }

    IEnumerator SleepLost()
    {
        if (sleepNeed > 1f)
        {
            sleepNeed = 1f;
        }
        yield return new WaitForSeconds(1);
        sleepNeed -= sleepLostPerSecond;
        sleepNeed = Mathf.Round(sleepNeed * 100.0f) * 0.01f;
        GetFill(sleepNeed, sleepFill);
        StartCoroutine(SleepLost());
    }
    IEnumerator HungerLost()
    {
        if (hungerNeed > 1f)
        {
            hungerNeed = 1f;
        }
        yield return new WaitForSeconds(1);
        hungerNeed -= hungerLostPerSecond;
        hungerNeed = Mathf.Round(hungerNeed * 100.0f) * 0.01f;
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
        funNeed = Mathf.Round(funNeed * 100.0f) * 0.01f;
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
        sleepNeed = Mathf.Round(sleepNeed * 100.0f) * 0.01f;
        GetFill(sleepNeed, sleepFill);
        if(isSleeeping)
        {
            StartCoroutine(Sleeping());
        }
    }
    private void GetFill(float currentAmount, Image imageToFill)
    {
        float fill = currentAmount / 1f;
        fill = Mathf.Round(fill * 100.0f) * 0.01f;
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
            hungerNeed += hungerRise;
            hungerNeed = Mathf.Round(hungerNeed * 100.0f) * 0.01f;
            GetFill(hungerNeed, hungerFill);
        }
    }
    public void FunPlay()
    {
        if(!isSleeeping)
        {
            funNeed += funRise;
            funNeed = Mathf.Round(funNeed * 100.0f) * 0.01f;
            GetFill(funNeed, funFill);
        }
    }
}
