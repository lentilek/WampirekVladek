using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodDrop : MonoBehaviour
{
    [SerializeField] private float gainTime;
    void Update()
    {
        if (transform.position.y < -1.5f)
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
            AudioManager.Instance.PlaySound("blood");
            MiniGameManager.Instance.miniGameCurrentTime += gainTime;
            Destroy(gameObject);
        }
    }
}
