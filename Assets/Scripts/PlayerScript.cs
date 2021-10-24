using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rd2d;

    public float speed;

    public float jumpForce;

    public Text score;

    public Text Lives;

    private int scoreValue = 0;

    private int LivesValue = 3;

    public Text WinText;

    public Text LoseText;

    public AudioClip musicClipOne;

    public AudioClip musicClipTwo;

    public AudioSource musicSource;

    private bool isOnGround;
    public Transform groundcheck;
    public float checkRadius;
    public LayerMask allGround;

    private bool isJumping;

    Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        score.text = scoreValue.ToString();
        Lives.text = "Lives: " + LivesValue.ToString();

        WinText.text = "";
        LoseText.text = "";

        musicSource.clip = musicClipTwo;
        musicSource.Play();

        anim = GetComponent<Animator>();


        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));

        Lives.text = "Lives: " + LivesValue.ToString();



        isOnGround = Physics2D.OverlapCircle(groundcheck.position, checkRadius, allGround);


    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground" && isOnGround)
        {
            if (Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

                anim.SetBool("isJumping", true);
            }
            else
            {
                anim.SetBool("isJumping", false);
            }
        


        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            score.text = scoreValue.ToString();
            Destroy(collision.collider.gameObject);


            SetWinText();


            if (scoreValue == 4)
            {
                transform.position = new Vector2(54.0f, 0.0f);
            }

            
            if (scoreValue == 4)
            {
                LivesValue = 3;
                Lives.text = LivesValue.ToString();
            }
        }

        if (collision.collider.tag == "Enemy")
        {
            LivesValue -= 1;
            Lives.text = LivesValue.ToString();
            Destroy(collision.collider.gameObject);

            SetLoseText();


        }


        if (LivesValue == 0)
        {
            Destroy(gameObject);
        }

       

    }

   

    void SetWinText()
    {
        if (scoreValue >= 8)
        {
            WinText.text = "You win! Game created by Jesus Casas ";

            musicSource.clip = musicClipOne;
            musicSource.Play();

            
        }
    }


    void SetLoseText()
    {
        if (LivesValue <= 0)
        {
            LoseText.text = "You Lose!";
        }


       
    }


}
