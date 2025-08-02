using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Blink : Base_ability
{
    public override string id => "Blink";


    // Start is called before the first frame update
    protected override void Execute()
    {
        Rigidbody2D RB = Player.GetComponent<Rigidbody2D>();
        Player_status P_status = Player.GetComponent<Player_status>();
        RB.velocity = new Vector2(0f, RB.velocity.y);
        Debug.Log("Blink");
        int direction = (int)Player.transform.localScale.x;
        RB.gravityScale = 0;
        RB.AddForce(new Vector2(direction,0) * 10000f,ForceMode2D.Impulse);
        Player.GetComponent<MonoBehaviour>().StartCoroutine(Finish_Blink(RB));
        RB.gravityScale = 1;
    }
    public override bool Isusable(GameObject Player)
    {
        Player_status P_status = Player.GetComponent<Player_status>();
        return true;
    }
    IEnumerator Finish_Blink(Rigidbody2D RB)
    {
        yield return new WaitForSeconds(1);
    }
}
