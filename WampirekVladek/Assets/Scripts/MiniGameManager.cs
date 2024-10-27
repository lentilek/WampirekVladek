using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.ShaderKeywordFilter;

public class MiniGameManager : MonoBehaviour
{
    public static MiniGameManager Instance;

    public bool isMiniGameOn;
    [SerializeField] private GameObject miniGame;
    [SerializeField] private GameObject miniGameUI;
    [SerializeField] private GameObject mainGame;
    [SerializeField] private GameObject mainGameUI;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private float miniGameBaseTime;
    public float miniGameCurrentTime;
    [SerializeField] private TextMeshProUGUI timerTxt;
    public int currentMoney;
    [SerializeField] private TextMeshProUGUI currentMoneyTXT;

    [SerializeField] private float maxX;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject garlic;
    [SerializeField] private float spawnRateGarlic;
    [SerializeField] private GameObject coin;
    [SerializeField] private float coinSpawnRate;
    [SerializeField] private GameObject bloodDrop;
    [SerializeField] private float bloodDropRate;
    [SerializeField] private int bloodDropNumber;
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
                Time.timeScale = 0f;
                gameOver.SetActive(true);
                currentMoneyTXT.text = $"Collected coins: {Mathf.RoundToInt(currentMoney)}";
                isMiniGameOn = false;
                //MainGame();
            }
        }
    }
    public void MainGame()
    {
        //AudioManager.Instance.PlaySound("button");
        Time.timeScale = 1f;
        isMiniGameOn = false;
        mainGame.SetActive(true);
        mainGameUI.SetActive(true);
        miniGame.SetActive(false);
        miniGameUI.SetActive(false);
        ShopAndMoney.Instance.MoneyUpdate();
        MusicManager.Instance.PlayMusic("musicMain");
    }

    public void MiniGame()
    {
        currentMoney = 0;
        mainGame.SetActive(false);
        mainGameUI.SetActive(false);
        miniGame.SetActive(true);
        miniGameUI.SetActive(true);
        gameOver.SetActive(false);
        currentBloodDropNumber = 0;
        ShopAndMoney.Instance.MoneyUpdate();
        miniGameCurrentTime = miniGameBaseTime;        
        isMiniGameOn = true;
        VladekNeeds.Instance.StartLosingSleep();
        MusicManager.Instance.PlayMusic("musicMinigame");
        VladekMini.Instance.OutfitSwap();
        VladekMini.Instance.gameObject.transform.position = new Vector3(-0.02f, -1.23f, 0);
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
