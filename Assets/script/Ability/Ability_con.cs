using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability_con : MonoBehaviour
{
    [SerializeField]
     public Dictionary<string, I_ability> Abilities = new();
    GameObject Player;
    [SerializeField]
    public GameObject Hook_UI;
    [SerializeField]
    public GameObject Chain;
    // Start is called before the first frame update
    void Start()
    {
        Player = this.gameObject;
        Abilities["Double_jump"] = new A_Doublejump();
        Abilities["Tackle"] = new A_Tackle();
        Abilities["Gliding"] = new A_Gliding();
        Abilities["Blink"] = new A_Blink();
        Abilities["Hook"] = new A_Hook();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
