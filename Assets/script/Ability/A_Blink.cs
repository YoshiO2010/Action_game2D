using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Blink : Base_ability
{
    public override string id => "Blink";
    Player_status P_status;
    [SerializeField]
    float Blink_time=0.1f;
    [SerializeField]
    float Blink_power=75f;
    
    
    // Start is called before the first frame update
    protected override void Execute()
    {
        Rigidbody2D RB = Player.GetComponent<Rigidbody2D>();
        P_status = Player.GetComponent<Player_status>();
        Ability_sounds A_SE = Player.GetComponent<Ability_sounds>();
        P_status.Is_Blink = true;

        
        Debug.Log("Blink");
        int direction = (int)Player.transform.localScale.x;
       
        A_SE.Play_SE(A_SE.Blink_SE);
        //RB.MovePosition(new Vector2(direction, 0) * 1f);
        Player.GetComponent<MonoBehaviour>().StartCoroutine(Finish_Blink(RB));
        Hook_Chain hook=Player.GetComponent<Hook_Chain>();
        if (hook != null && hook.Is_Group)
        {
            Vector2 anchor = hook.GetAnchor_WorldPos();
            Vector2 rDir = (anchor - RB.position).normalized;
            Vector2 tan = new Vector2(-rDir.y, rDir.x);
            Vector2 impulse = tan * -direction * Blink_power;
            RB.AddForce(impulse, ForceMode2D.Impulse);
            
        }
        else
        {
            RB.velocity = new Vector2(0f, RB.velocity.y);
            RB.gravityScale = 0;
            RB.AddForce(new Vector2(direction * Blink_power, 0), ForceMode2D.Impulse);
        }
    }
    public override bool Isusable(GameObject Player)
    {
        Player_status P_status = Player.GetComponent<Player_status>();
        return true;
    }
    IEnumerator Finish_Blink(Rigidbody2D RB)
    {
        yield return new WaitForSeconds(Blink_time);
        RB.gravityScale = 1;
        P_status.Is_Blink=false;
    }
}
