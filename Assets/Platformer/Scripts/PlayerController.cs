using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public float MovementSpeed;
    public float JumpForce;
    Rigidbody2D rb;
    private bool isJumping;
    WaitForSeconds delay = new WaitForSeconds(1);

    public Animator AnimationTransition;

    Animator anim;
    SpriteRenderer sr;

    private void Start()
    {
        isJumping = false;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        anim.SetFloat("HoriM", Mathf.Abs(rb.velocity.x));
        anim.SetFloat("VertM", rb.velocity.y);
        RigidBodyMovement();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

    }

    public void RigidBodyMovement()
    {
        float MovDir = Input.GetAxisRaw("Horizontal");
        float MovVir = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(MovDir * MovementSpeed, rb.velocity.y);
        if (!isJumping && MovVir > 0.1f)
        {
            rb.velocity = new Vector2(rb.velocity.x,JumpForce);
            isJumping = true;
        }

        if(MovVir < 0)
        {
            anim.SetBool("IsCrouching", true);
        }
        else
        {
            anim.SetBool("IsCrouching", false);
        }


        if (isJumping == true)
        {
            anim.SetBool("IsJumping", true);
        }
        else if (rb.velocity.y < 0)
        {
            anim.SetBool("IsJumping", false);
        }

        if (rb.velocity.x < 0)
        {
            sr.flipX = true;
        }
        else if (rb.velocity.x > 0)
        {
            sr.flipX = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            isJumping = false; 
        }

        if (collision.gameObject.tag == "Coins")
        {
            GetComponent<PlayerStats>().EditScore(collision.gameObject.GetComponent<Coins>().CoinValue);
            Destroy(collision.gameObject);

        }

        if (collision.gameObject.tag == "Restart")
        {
            StartCoroutine(RestartScene());
            Destroy(collision.gameObject);
            
        }

        if (collision.gameObject.tag == "EnemyHead")
        {
            collision.gameObject.transform.parent.gameObject.SetActive(false);
            rb.velocity = new Vector2(rb.velocity.x, JumpForce / 2);
        }

        if (collision.gameObject.tag == "End")
        {
            StartCoroutine(EndScene());
        }

        
    }

    IEnumerator RestartScene()
    {
        AnimationTransition.Play("FadeOut");
        yield return delay;
        SceneManager.LoadScene("Platformer");
    }

    IEnumerator EndScene()
    {
        PlayerPrefs.SetInt("PlayerCoins", gameObject.GetComponent<PlayerStats>().Score);
        AnimationTransition.Play("FadeOut");
        yield return delay;
        SceneManager.LoadScene("EndScreen");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isJumping = true;
        }
    }
}
