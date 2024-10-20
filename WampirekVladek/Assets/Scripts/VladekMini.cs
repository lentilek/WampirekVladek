using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VladekMini : MonoBehaviour
{
    public static VladekMini Instance;

    public float moveSpeed;
    private Rigidbody2D rb;
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
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(!Input.GetMouseButton(0))
        {
            rb.velocity = Vector2.zero;
        }
    }

    public void MoveLeft()
    {
        rb.AddForce(Vector2.left * moveSpeed);
    }

    public void MoveRight()
    {
        rb.AddForce(Vector2.right * moveSpeed);
    }
}
