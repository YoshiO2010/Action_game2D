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
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        Vector2 To_Target=Angle-pos;
        transform.position = pos + To_Target.normalized * Time.deltaTime * speed;
        GetComponent<Hook_Chain>().Connect_Chain(RB);
    }
    public void hook_Shot(Vector2 angle,GameObject Player)
    {
        transform.rotation = Quaternion.Euler(0, 0, -45f);
      this.Angle = angle;
        this.Player = Player;
    }
}
