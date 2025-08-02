using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Tackle : Base_ability
{
    public override string id => "Tackle";


    // Start is called before the first frame update
    protected override void Execute()
    {
        Rigidbody2D RB = Player.GetComponent<Rigidbody2D>();
        Player_status P_status = Player.GetComponent<Player_status>();
        RB.velocity = new Vector2(RB.velocity.x, 0f);
        Debug.Log("Tackle");
        int direction = (int)Player.transform.localScale.x;
        RB.AddForce(new Vector2(direction,0) * 3000f);
    }
    public override bool Isusable(GameObject Player)
    {
        Player_status P_status = Player.GetComponent<Player_status>();
        return P_status.jump_count == 0;
    }
}
