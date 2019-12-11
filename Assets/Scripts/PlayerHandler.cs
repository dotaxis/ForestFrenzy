using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public float playerSpeed;
    public float rollDelay;
    public float playerJumpHeight;
    public static bool isDead;
    public bool isOnGround = true;
    public bool isRolling = false;
    public bool isJumping = false;
    public Rigidbody2D rb;
    public GameObject player;
    public BoxCollider2D playerBox;
    public TouchHandler touchHandle = new TouchHandler();

    // Start is called before the first frame update
    void Start()
    { 
        rb = this.GetComponent<Rigidbody2D>();
        playerBox = this.GetComponent<BoxCollider2D>();
        isDead = false;
    }

    void Die()
    {
        isDead = true;
        //foreach (GameObject block in GameObject.FindGameObjectsWithTag("deathBlock"))
        //    block.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        rb.velocity = Vector2.zero;
        //ScrollHandler.rb.velocity = Vector2.zero;
        //rb.constraints = RigidbodyConstraints2D.FreezeAll;
        GameControl.instance.GameOver();
        // todo
    }

    void Jump()
    {
        //Debug.Log("shit: " + (playerJumpHeight * Time.deltaTime).ToString());
        rb.velocity = new Vector2(rb.velocity.x, playerJumpHeight);
    }


    void UnRoll()
    {
        //playerBox.size = new Vector2(0.49f, 0.49f);
        isRolling = false;
    }
    
    IEnumerator Roll()
    {
        float elapsedTime = 0f;
        while (elapsedTime < rollDelay * Time.fixedDeltaTime)
        {
            isRolling = true;
            transform.localScale = new Vector3(transform.localScale.x, 0.5f, 1);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.localScale = new Vector3(transform.localScale.x, 1f, 1);
        isRolling = false;
        //playerBox.size = new Vector2(0.49f, 0.46f);
        //Invoke("UnRoll", rollDelay);
    }


    void ControlPlayer()
    {
        isOnGround = playerBox.IsTouching(GameObject.Find("floor").GetComponent<BoxCollider2D>())
            || playerBox.IsTouching(GameObject.Find("floor2").GetComponent<BoxCollider2D>());

        if (isOnGround && !isRolling)
        {
            if (touchHandle.IsLeftClick())
            {
                Jump();
            } else if (touchHandle.IsRightClick())
            {
                StartCoroutine(Roll());
            }
        }

        //rb.velocity = new Vector2(playerSpeed, rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider is BoxCollider2D && collision.collider.CompareTag("deathBlock"))
        {
            Die();
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            ControlPlayer();
        }
    }
}
