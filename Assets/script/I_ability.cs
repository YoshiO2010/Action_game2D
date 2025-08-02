using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface I_ability
{
   string id
    {
        get;
    }
    void Activate(GameObject Player);
    bool Isusable(GameObject Player);
}