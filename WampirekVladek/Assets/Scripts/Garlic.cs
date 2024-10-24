using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Garlic : MonoBehaviour
{
    public float lostTime;
    void Update()
    {
        if(transform.position.y < -1.5f)
        {
            Destroy(gameObject);
        }
        if (!MiniGameManager.Instance.isMiniGameOn)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AudioManager.Instance.PlaySound("hit");
            MiniGameManager.Instance.miniGameCurrentTime -= lostTime;
            if(MiniGameManager.Instance.miniGameCurrentTime < 0) MiniGameManager.Instance.miniGameCurrentTime = 0;
            Destroy(gameObject);
        }
    }
}
