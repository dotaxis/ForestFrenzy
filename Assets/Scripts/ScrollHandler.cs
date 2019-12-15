using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollHandler : MonoBehaviour
{
    public float scrollSpeed;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-scrollSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameControl.instance.gameOver)
        {
            rb.velocity = Vector2.zero;
        }
    }
}
