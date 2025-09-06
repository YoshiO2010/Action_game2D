using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_con : MonoBehaviour
{
    [SerializeField]
    float run_speed;
    [SerializeField]
    public float Jump_power = 5;
    [SerializeField]
    bool run;
    Player_status P_status;
    Ability_con a_com;
    [SerializeField]
    Ability_sounds A_SE;
    

    
    [SerializeField]
    Animator animator;
    public enum DIRECTION_TYPE
    {
        STOP,
        LEFT,
        RIGHT,
        RUN_LFET,
        RUN_RIGHT,
    }
    DIRECTION_TYPE direction = DIRECTION_TYPE.STOP;
    Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
          rigidbody2D= GetComponent<Rigidbody2D>();
          animator = GetComponent<Animator>();
        P_status = GetComponent<Player_status>();
        a_com = GetComponent<Ability_con>();
        A_SE = GetComponent<Ability_sounds>();
    }

    // Update is called once per frame
    void Update()
    {
        if (P_status.Goal_flag == false)
        {
            float x = Input.GetAxis("Horizontal");
            animator.SetFloat("speed", Mathf.Abs(x));
            if (x == 0)
            {
                direction = DIRECTION_TYPE.STOP;
            }
            if (x > 0)
            {
                direction = DIRECTION_TYPE.RIGHT;
            }
            if (x < 0)
            {
                direction = DIRECTION_TYPE.LEFT;
            }
            if (x > 0 && run)
            {
                direction = DIRECTION_TYPE.RUN_RIGHT;
            }
            if (x < 0 && run)
            {
                direction = DIRECTION_TYPE.RUN_LFET;
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (a_com.Abilities["Tackle"].Isusable(this.gameObject))
                {
                    animator.SetTrigger("tackle");
                    a_com.Abilities["Tackle"].Activate(this.gameObject);
                    
                } 
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (a_com.Abilities["Blink"].Isusable(this.gameObject))
                {
                    a_com.Abilities["Blink"].Activate(this.gameObject);
                }
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (P_status.can_jump())
                {
                    Jump();
                    A_SE.Play_SE(A_SE.Jump_SE);
                }
                else if (a_com.Abilities["Double_jump"].Isusable(this.gameObject))
                {
                    a_com.Abilities["Double_jump"].Activate(this.gameObject);
                    A_SE.Play_SE(A_SE.Double_Jump_SE);
                }
            }
            if (Input.GetMouseButtonDown(0))
            {
                if (GetComponent<Hook_Chain>().Is_Group == true)
                {
                    GetComponent<Hook_Chain>().Cut_Chain();
                }
                else
                {
                    if (a_com.Abilities["Hook"].Isusable(this.gameObject))
                    {
                        a_com.Abilities["Hook"].Activate(this.gameObject);

                    }
                }
               
                
                
                
            }
           
            if (Input.GetKey(KeyCode.LeftShift))
            {
                run = true;
            }
            else
            {
                run = false;
            }
            if (Input.GetKey(KeyCode.Space))
            {
                if (a_com.Abilities["Gliding"].Isusable(this.gameObject))
                {
                    a_com.Abilities["Gliding"].Activate(this.gameObject);
                }
            }
            else
            {
                (a_com.Abilities["Gliding"] as A_Gliding).Finish_Gliding();
            }
           
        }
        else
        {
            direction = DIRECTION_TYPE.STOP;
            animator.SetFloat("speed", 0);
        }
        
    }
   void FixedUpdate()
    {
        switch (direction)
        {
            case DIRECTION_TYPE.STOP:
                run_speed = 0;
                break;
            case DIRECTION_TYPE.LEFT:
                run_speed = -3;
                transform.localScale =new Vector3(-1, 1, 1);
                break;
            case DIRECTION_TYPE.RIGHT:
                run_speed = 3;
                transform.localScale = new Vector3(1, 1, 1);
                break;
            case DIRECTION_TYPE.RUN_LFET:
                run_speed = -5;
                transform.localScale = new Vector3(-1, 1, 1);
                break;
            case DIRECTION_TYPE.RUN_RIGHT:
                run_speed = 5;
                transform.localScale = new Vector3(1, 1, 1);
                break;


        }
        if (P_status.Is_Blink)
        {
            return;
        }
        rigidbody2D.velocity = new Vector2(run_speed, rigidbody2D.velocity.y);

    }
    void Jump()
    {
        rigidbody2D.AddForce(Vector2.up * Jump_power);
        P_status.add_jump();
    }
}
