using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Skillselect : MonoBehaviour
{
    [SerializeField]
    Ability_deta[] skill_list;
    [SerializeField]
    Image[] skill_icon_list;
    [SerializeField]
    List<Ability_deta> set_skill = new List<Ability_deta>();
    // Start is called before the first frame update
    void Start()
    {
        set_skill = Abillty_loadout.instans.Select_skill;
        for(int i = 0; i < skill_icon_list.Length; i++)
        {
            skill_icon_list[i].sprite = set_skill[i].icon;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Skill_slect_bottn(int Index)
    {
        Ability_deta skill = skill_list[Index];
        set_skill.Add(skill);
        int skill_slot = set_skill.Count - 1;
        skill_icon_list[skill_slot].sprite = skill.icon;
    }
    public void Reset_skill()
    {
        for (int i = 0; i < skill_icon_list.Length; i++)
        {
            skill_icon_list[i].sprite = null;
        }
        set_skill.Clear();
    }
    public void Slected_bottn()
    {
        Abillty_loadout.instans.Set_skill(set_skill);
        SceneManager.LoadScene("STAGE slect");
    }
}
