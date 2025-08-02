using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Gliding : Base_ability
{
    private bool Gliding_Flag = false;
    // Start is called before the first frame update
    public override string id => "Gliding";
    protected override void Execute()
    {
        Rigidbody2D RB = Player.GetComponent<Rigidbody2D>();
        Player_status P_status = Player.GetComponent<Player_status>();
        RB.gravityScale = 0.5f;
        Gliding_Flag = true;
    }
    public override bool Isusable(GameObject Player)
    {
        Player_status P_status = Player.GetComponent<Player_status>();

        return P_status.jump_count != 0 && !Gliding_Flag;
    }
    public void Finish_Gliding()
    {
        Rigidbody2D RB = Player.GetComponent<Rigidbody2D>();
        RB.gravityScale = 1;
        Gliding_Flag = false;
    }
}
