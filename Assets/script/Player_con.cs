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
    Hook_Chain chain;
    [SerializeField]
    float swingAccel=100f;
    [SerializeField]
    bool holdUntil_Jumpable;
    [SerializeField]
    Animator animator;
    public bool Move_flag;
    Abillty_Cheack Cheack;

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
    [SerializeField]
    float Max_Swing;
    // Start is called before the first frame update
    void Start()
    {
          rigidbody2D= GetComponent<Rigidbody2D>();
          animator = GetComponent<Animator>();
        P_status = GetComponent<Player_status>();
        a_com = GetComponent<Ability_con>();
        A_SE = GetComponent<Ability_sounds>();
        chain = GetComponent<Hook_Chain>();
        Cheack = GetComponent<Abillty_Cheack>();
    }

    // Update is called once per frame
    void Update()
    {
        if (P_status.Goal_flag == false&&Move_flag==true)
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
            if (Input.GetKeyDown(KeyCode.Q)&&Cheack.Tackle)
            {
                if (a_com.Abilities["Tackle"].Isusable(this.gameObject))
                {
                    animator.SetTrigger("tackle");
                    a_com.Abilities["Tackle"].Activate(this.gameObject);
                    
                } 
            }
            if (Input.GetKeyDown(KeyCode.E)&&Cheack.Blink)
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
                    animator.SetTrigger("jump");
                    animator.SetBool("Land", false);
                    Jump();
                    A_SE.Play_SE(A_SE.Jump_SE);
                }
                else if (a_com.Abilities["Double_jump"].Isusable(this.gameObject)&&Cheack.Double_jump)
                {
                    animator.SetTrigger("jump");

                    a_com.Abilities["Double_jump"].Activate(this.gameObject);
                    A_SE.Play_SE(A_SE.Double_Jump_SE);
                }
            }
            if (Input.GetMouseButtonDown(0)&&Cheack.Hook)
            {
                holdUntil_Jumpable = true;
                if (GetComponent<Hook_Chain>().Is_Group == true)
                {
                    Debug.Log("cut");
                    chain.Cut_Chain();
                }
                else
                {
                    if (a_com.Abilities["Hook"].Isusable(this.gameObject))
                    {
                        a_com.Abilities["Hook"].Activate(this.gameObject);

                    }
                }
                
                
               
                
                
                
            }
            if (Input.GetKeyDown(KeyCode.M)&&Cheack.Map)
            {
                a_com.Abilities["Map"].Activate(this.gameObject);
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                run = true;
            }
            else
            {
                run = false;
            }
            if (Input.GetKey(KeyCode.Space)&&Cheack.Gliding)
            {
                
                if (a_com.Abilities["Gliding"].Isusable(this.gameObject))
                {
                    a_com.Abilities["Gliding"].Activate(this.gameObject);
                }
            }
            else
            {
                //(a_com.Abilities["Gliding"] as A_Gliding).Finish_Gliding();
            }
            if (chain != null && chain.Is_Group)
            {
                Vector2 anchor = chain.GetAnchor_WorldPos();
                Vector2 rDir = (anchor - rigidbody2D.position).normalized;
                Vector2 tan = new Vector2(-rDir.y, rDir.x);
                float H = Input.GetAxisRaw("Horizontal");
                rigidbody2D.AddForce(tan * H * swingAccel, ForceMode2D.Force);
                rigidbody2D.drag = 0.05f;
                float VT=Vector2.Dot(rigidbody2D.velocity,tan);
                VT = Mathf.Clamp(VT, -Max_Swing, Max_Swing);
                rigidbody2D.velocity = tan * VT + rDir * Vector2.Dot(rigidbody2D.velocity,rDir);
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
        if (chain != null && chain.Is_Group)
        {
            return;

        }
        if (holdUntil_Jumpable&&P_status.Blink_used==false)
        {
            if (!P_status.can_jump()) return;
            holdUntil_Jumpable = false;
        }
        rigidbody2D.velocity = new Vector2(run_speed, rigidbody2D.velocity.y);
        
    }
    void Jump()
    {
        rigidbody2D.AddForce(Vector2.up * Jump_power);
        P_status.add_jump();
    }
}
