using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abillty_Cheack : MonoBehaviour
{
    [SerializeField]
    List<Ability_deta> set_skill = new List<Ability_deta>();
    [SerializeField]
    public bool Hook;
    [SerializeField]
    public bool Blink;
    [SerializeField]
    public bool Double_jump;
    [SerializeField]
    public bool Map;
    [SerializeField]
    public bool Gliding;
    [SerializeField]
    public bool Tackle;
    // Start is called before the first frame update
    void Start()
    {
        Hook = false;
        Blink = false;
        Double_jump = false;
        Map = false;
        Gliding = false;
        Tackle = false;
        set_skill= Abillty_loadout.instans.Select_skill;
        for (int i = 0; i < set_skill.Count; i++)
        {
            string Ability_name=set_skill[i].name;
            switch (Ability_name)
            {
                case "Hook":
                    Hook = true;
                    break;
                case "Blink":
                    Blink = true;
                    break;
                case "Double_jump":
                    Double_jump = true;
                    break;
                case "MAP":
                    Map = true;
                    break;
                case "Gliding":
                    Gliding = true;
                    break;
                case "Tackle":
                    Tackle = true;
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
