using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abillty_loadout : MonoBehaviour
{
    public static Abillty_loadout instans
    {
        get;
        private set;
    }
    [SerializeField]
    public List<Ability_deta> Select_skill
    {
        get;
        private set;
    } = new List<Ability_deta>();
    // Start is called before the first frame update
    private void Awake()
    {
        if (instans != null && instans != this)
        {
            Destroy(gameObject);
            return;
        }
        instans = this;
        DontDestroyOnLoad(gameObject);
    }
    public void Set_skill(List<Ability_deta> skills)
    {
        Select_skill = new List<Ability_deta>(skills);
    }
}
