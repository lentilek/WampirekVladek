using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MiniGameManager : MonoBehaviour
{
    public static MiniGameManager Instance;

    public bool isMiniGameOn;
    public GameObject miniGame;
    public GameObject miniGameUI;
    public GameObject mainGame;
    public GameObject mainGameUI;
    public float miniGameBaseTime;
    public float miniGameCurrentTime;
    public TextMeshProUGUI timerTxt;

    public float maxX;
    public Transform spawnPoint;
    public GameObject garlic;
    public float spawnRateGarlic;
    public GameObject coin;
    public float coinSpawnRate;
    public GameObject bloodDrop;
    public float bloodDropRate;
    public int bloodDropNumber;
    private int currentBloodDropNumber;

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
        MainGame();
        //MiniGame();
    }
    private void Update()
    {
        if(isMiniGameOn)
        {
            miniGameCurrentTime -= Time.deltaTime;
            Display();
            if(miniGameCurrentTime < 0)
            {
                StopAllCoroutines();
                MainGame();
            }
        }
    }
    public void MainGame()
    {
        isMiniGameOn = false;
        mainGame.SetActive(true);
        mainGameUI.SetActive(true);
        miniGame.SetActive(false);
        miniGameUI.SetActive(false);
        ShopAndMoney.Instance.MoneyUpdate();
        MusicManager.Instance.PlayMusic("musicMinigame");
    }

    public void MiniGame()
    {
        mainGame.SetActive(false);
        mainGameUI.SetActive(false);
        miniGame.SetActive(true);
        miniGameUI.SetActive(true);
        currentBloodDropNumber = 0;
        ShopAndMoney.Instance.MoneyUpdate();
        miniGameCurrentTime = miniGameBaseTime;        
        isMiniGameOn = true;
        VladekNeeds.Instance.StartLosingSleep();
        MusicManager.Instance.PlayMusic("musicMain");
        StartCoroutine(SpawnGarlic());
        StartCoroutine(SpawnCoin());
        StartCoroutine(SpawnBloodDrop());
    }
    IEnumerator SpawnGarlic()
    {
        yield return new WaitForSeconds(spawnRateGarlic);
        Vector3 spawnPos = spawnPoint.position;
        spawnPos.x = Random.Range(-maxX, maxX);
        Instantiate(garlic, spawnPos, Quaternion.identity);
        StartCoroutine(SpawnGarlic());
    }
    IEnumerator SpawnCoin()
    {
        yield return new WaitForSeconds(coinSpawnRate);
        Vector3 spawnPos = spawnPoint.position;
        spawnPos.x = Random.Range(-maxX, maxX);
        Instantiate(coin, spawnPos, Quaternion.identity);
        StartCoroutine(SpawnCoin());
    }
    IEnumerator SpawnBloodDrop()
    {
        yield return new WaitForSeconds(bloodDropRate);
        Vector3 spawnPos = spawnPoint.position;
        spawnPos.x = Random.Range(-maxX, maxX);
        Instantiate(bloodDrop, spawnPos, Quaternion.identity);
        currentBloodDropNumber++;
        if(currentBloodDropNumber < bloodDropNumber)
        {
            StartCoroutine(SpawnBloodDrop());
        }
    }
    private void Display()
    {
        timerTxt.text = $"{Mathf.RoundToInt(miniGameCurrentTime)}";
    }
}
