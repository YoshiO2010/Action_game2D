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
    [SerializeField]
    GameObject Main_cam;
    [SerializeField]
    GameObject Map_cam;
    // Start is called before the first frame update
    void Awake()
    {
        Player = this.gameObject;
        Abilities["Double_jump"] = new A_Doublejump();
        Abilities["Tackle"] = new A_Tackle();
        Abilities["Gliding"] = new A_Gliding();
        Abilities["Blink"] = new A_Blink();
        Abilities["Hook"] = new A_Hook();
        var a_Map = new A_Map();
        a_Map.Inject(Main_cam, Map_cam);
        Abilities["Map"] = a_Map;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
