using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPool : MonoBehaviour
{
    public static int blockPoolSize = 8;
    public GameObject blockPrefab;

    private GameObject[] blocks;
    private Vector2 blockPoolPosition = new Vector2(-10f, -10f); // outside camera bounds
    private float xPosMin = 4.75f;
    private float xPosMax = 5.25f;
    private int currentBlock = 0;

    int CoinFlip()
    {
        return Random.Range(0, 2);
    }

    // Start is called before the first frame update
    void Awake()
    {
        blocks = new GameObject[blockPoolSize];
        for (int i = 0; i < blockPoolSize; i++)
        {
            blocks[i] = (GameObject)Instantiate(blockPrefab, blockPoolPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (!GameObject.Find("Player").GetComponent<PlayerHandler>().isDead && blocks[currentBlock].transform.position.x <= 3.5f)
        {
            currentBlock++;
            if (currentBlock >= blockPoolSize)
                currentBlock = 0;
            
            //timeElapsed = 0f;
            float yPos = (CoinFlip() == 0) ? -1.75f : -1.45f;
            blocks[currentBlock].transform.position = new Vector2(Random.Range(xPosMin, xPosMax), yPos);
            
        }
    }
}
