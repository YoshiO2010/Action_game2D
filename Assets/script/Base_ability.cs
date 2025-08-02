using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Base_ability :I_ability
{
    public abstract string id
    {
        get;
    }
    protected GameObject Player;
    // Start is called before the first frame update
   public virtual void Activate(GameObject Player)
    {
        this.Player = Player;
        Execute();
    }
    protected abstract void Execute();
    public virtual bool Isusable(GameObject Payer)
    {
        this.Player = Player;
        return true;
    }
}
