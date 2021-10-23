using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{

    Animator anim;

    private bool facingRight = true;

   

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //Flip code
        float hozMovement = Input.GetAxis("Horizontal");
        

        if (facingRight == false && hozMovement > 0)
        {
            Flip();
        }
        else if (facingRight == true && hozMovement < 0)
        {
            Flip();
        }

       


        // idle to Runing animation left
        if (Input.GetKeyDown(KeyCode.D))

        {

            anim.SetInteger("State", 1);

        }

        if (Input.GetKeyUp(KeyCode.D))

        {

            anim.SetInteger("State", 0);

        }

        //idle to Runing animation right
        if (Input.GetKeyDown(KeyCode.A))

        {

            anim.SetInteger("State", 1);

        }

        if (Input.GetKeyUp(KeyCode.A))

        {

            anim.SetInteger("State", 0);

        }
        //idle to jumping aimation

       

        



        void Flip()
        {
            facingRight = !facingRight;
            Vector2 Scaler = transform.localScale;
            Scaler.x = Scaler.x * -1;
            transform.localScale = Scaler;
        }

      




    }

   






}
