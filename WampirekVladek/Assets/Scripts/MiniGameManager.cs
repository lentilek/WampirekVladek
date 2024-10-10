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

    public GameObject garlic;
    public float maxX;
    public Transform spawnPoint;
    public float spawnRate;

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
    }

    public void MiniGame()
    {
        mainGame.SetActive(false);
        mainGameUI.SetActive(false);
        miniGame.SetActive(true);
        miniGameUI.SetActive(true);
        miniGameCurrentTime = miniGameBaseTime;        
        isMiniGameOn = true;
        VladekNeeds.Instance.StartLosingSleep();
        StartCoroutine(SpawnGarlic());
    }
    IEnumerator SpawnGarlic()
    {
        yield return new WaitForSeconds(spawnRate);
        Vector3 spawnPos = spawnPoint.position;
        spawnPos.x = Random.Range(-maxX, maxX);
        Instantiate(garlic, spawnPos, Quaternion.identity);
        StartCoroutine(SpawnGarlic());
    }
    private void Display()
    {
        timerTxt.text = $"{Mathf.RoundToInt(miniGameCurrentTime)}";
    }
}
