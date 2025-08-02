using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Player_status : MonoBehaviour
{
    public int jump_count = 0;
    public int Max_jump_count = 1;
    public bool Goal_flag;
    [SerializeField]
    Game_mane mane;
    // Start is called before the first frame update
    void Start()
    {
       
        mane = GameObject.FindWithTag("manager").GetComponent<Game_mane>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts.Any(c => c.normal.y > 0.5f)) 
        {
            jump_count = 0;
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "GOAL")
        {
            Goal_flag = true;
            mane.Game_clear();
        }
    }
    public bool can_jump()
    {
        return jump_count < Max_jump_count;

    }
    public void add_jump()
    {
        jump_count++;
    }
}
