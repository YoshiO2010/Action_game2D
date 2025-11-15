using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SS_skill_Ui : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    [SerializeField]
    GameObject SS_icon;
    [SerializeField]
    Image[] skill_icon_list;
    [SerializeField]
    List<Ability_deta> set_skill = new List<Ability_deta>();
    // Start is called before the first frame update
    void Start()
    {
        SS_icon.SetActive(false);
        set_skill = Abillty_loadout.instans.Select_skill;
        for (int i = 0; i < skill_icon_list.Length; i++)
        {
            skill_icon_list[i].sprite = set_skill[i].icon;
        }
    }

    // Update is called once per frame
    public void OnPointerEnter(PointerEventData eventdata)
    {
        SS_icon.SetActive(true);
    }
    public void OnPointerExit(PointerEventData eventdata)
    {
        SS_icon.SetActive(false);
    }
}
