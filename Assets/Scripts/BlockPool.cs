using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPool : MonoBehaviour
{
    public static int blockPoolSize = 5;
    public GameObject blockPrefab;

    private GameObject[] blocks;
    private Vector2 blockPoolPosition = new Vector2(-10f, -10f); // outside camera bounds
    private float xPosMin = 4f;
    private float xPosMax = 6f;
    private int currentBlock = 0;

    int CoinFlip()
    {
        return Random.Range(0, 2);
    }

    // Start is called before the first frame update
    void Start()
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

        if (!PlayerHandler.isDead && blocks[currentBlock].transform.position.x <= 2)
        {
            currentBlock++;
            if (currentBlock >= blockPoolSize)
                currentBlock = 0;
            
            //timeElapsed = 0f;
            float yPos = (CoinFlip() == 0) ? -2f : -1.7f;
            blocks[currentBlock].transform.position = new Vector2(Random.Range(xPosMin, xPosMax), yPos);
            
        }
    }
}
