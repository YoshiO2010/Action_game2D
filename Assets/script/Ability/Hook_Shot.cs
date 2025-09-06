using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook_Shot : MonoBehaviour
{
    [SerializeField]
    GameObject Hook;
    Rigidbody2D RB;
    Vector2 Angle;
    [SerializeField]
    float speed;
    GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        Vector2 To_Target=Angle-pos;
        float step= Time.deltaTime* speed;
       
        
        if(To_Target.sqrMagnitude<= step)
        {
            Player.GetComponent<Hook_Chain>().Connect_Chain(RB);
            RB.isKinematic = true;
            enabled = false;
            return;
        }
        transform.position = pos + To_Target.normalized * Time.deltaTime * speed;
    }
    public void hook_Shot(Vector2 angle,GameObject Player)
    {
        transform.rotation = Quaternion.Euler(0, 0, -45f);
      this.Angle = angle;
        this.Player = Player;
    }
}
