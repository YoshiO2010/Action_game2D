using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Map : Base_ability
{
   
    GameObject Map_camera;
    GameObject Main_camera;
    bool booled_Map;

    public override string id => "Map";
    // Start is called before the first frame update
    public void Inject(GameObject main,GameObject Map)
    {

        Main_camera = main;
        Map_camera = Map;
    }

    // Update is called once per frame
    protected override void Execute()
    {
       
        booled_Map = !Map_camera.activeSelf;
        Apply(booled_Map);
       
    }
    void Apply(bool on)
    {
        if (on==true)
        {
            Map_camera.SetActive(true);
            Main_camera.SetActive(false);
        }
        else
        {
            Map_camera.SetActive(false);
            Main_camera.SetActive(true);
        }
    }
}
