using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Hook : Base_ability
{
    public override string id => "Hook";
    [SerializeField]
    Vector2 Dir = new Vector2(1, 1);
    [SerializeField]
    int Hook_mask=LayerMask.GetMask("Ground");
   
    // Start is called before the first frame update
    protected override void Execute()
    {
        Rigidbody2D RB = Player.GetComponent<Rigidbody2D>();
        Ability_con A_con = Player.GetComponent<Ability_con>();
        RaycastHit2D hit = Physics2D.Raycast(RB.position, Dir, 100f,Hook_mask);
        if (hit.collider != null)
        {
            GameObject hook = GameObject.Instantiate(A_con.Hook_UI, Player.transform.position+new Vector3(0.6f,0.6f,0),Quaternion.identity);
            hook.GetComponent<Hook_Shot>().hook_Shot(hit.point,Player);
        }
    }
}
