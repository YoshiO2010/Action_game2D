using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Doublejump : Base_ability
{
    public override string id => "Double_jump";
    // Start is called before the first frame update
    protected override void Execute()
    {
        Player_con P_con = Player.GetComponent<Player_con>();
        Rigidbody2D RB = Player.GetComponent<Rigidbody2D>();
        Player_status P_status = Player.GetComponent<Player_status>();
        RB.velocity = new Vector2(RB.velocity.x, 0f);
        RB.AddForce(Vector2.up * P_con.Jump_power);
        P_status.add_jump();
    }
    public override bool Isusable(GameObject Player)
    {
        Player_status P_status = Player.GetComponent<Player_status>();
        return P_status.jump_count == 1;
    }
}
