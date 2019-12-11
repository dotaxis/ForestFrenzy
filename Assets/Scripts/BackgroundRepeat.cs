using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeat : MonoBehaviour
{
    private float groundLength;

    // Start is called before the first frame update
    void Start()
    {
        groundLength = GetComponent<SpriteRenderer>().size.x;
    }

    void Reposition()
    {
        transform.position = new Vector2(transform.position.x + (groundLength * 2f), transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -groundLength)
        {
            Reposition();
        }
    }
}
