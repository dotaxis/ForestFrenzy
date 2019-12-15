using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public float playerSpeed;
    public float rollDelay;
    public float playerJumpHeight;
    public bool isDead;
    public bool isOnGround = true;
    public bool isRolling = false;
    public bool isJumping = false;
    public bool isRunning = false;
    public Rigidbody2D rb;
    public GameObject player;
    public BoxCollider2D playerBox;
    public TouchHandler touchHandle = new TouchHandler();
    public Animator animator;
    public AudioHandler SFX;


    // Start is called before the first frame update
    void Start()
    {
        Input.simulateMouseWithTouches = false;

        SFX = GameObject.Find("Music").GetComponent<AudioHandler>();
        animator = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody2D>();
        playerBox = this.GetComponent<BoxCollider2D>();
        isDead = false;
    }

    void Die()
    {
        //isRunning = false;
        isDead = true;
        rb.velocity = Vector2.zero;
        GameControl.instance.GameOver();
    }

    void Jump()
    {
        //isRunning = false;
        SFX.PlayJumpSound();
        rb.velocity = new Vector2(rb.velocity.x, playerJumpHeight);
    }
    
    IEnumerator Roll()
    {
        isRolling = true;
        SFX.PlayRollSound();
        playerBox.size = new Vector2(playerBox.size.x, playerBox.size.y * 0.5f);
        playerBox.offset = new Vector2(playerBox.offset.x, playerBox.offset.y * 0.5f);
        float elapsedTime = 0f;
        while (elapsedTime < rollDelay * Time.fixedDeltaTime)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        playerBox.size = new Vector2(playerBox.size.x, playerBox.size.y * 2f);
        playerBox.offset = new Vector2(playerBox.offset.x, playerBox.offset.y * 2f);
        isRolling = false;
    }


    void ControlPlayer()
    {
        if (isOnGround && !isRolling)
        {
            if (touchHandle.IsLeftClick())
                Jump();
            else if (touchHandle.IsRightClick())
                StartCoroutine(Roll());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider is BoxCollider2D && collision.collider.CompareTag("deathBlock"))
        {
            Die();
        }
    }

    void Update()
    {
        isOnGround = playerBox.IsTouching(GameObject.Find("floor1").GetComponent<BoxCollider2D>())
            || playerBox.IsTouching(GameObject.Find("floor2").GetComponent<BoxCollider2D>());

        /*if (isOnGround && !isDead && !isRolling && !isRunning)
        {
            isRunning = true;
            //SFX.playRunSound();
        }*/

        if (!isDead)
        {
            ControlPlayer();
        }


        animator.SetBool("dead", isDead);
        animator.SetBool("rolling", isRolling);
        animator.SetBool("onground", isOnGround);
        animator.SetFloat("velocity.y", rb.velocity.y);
    }
}
