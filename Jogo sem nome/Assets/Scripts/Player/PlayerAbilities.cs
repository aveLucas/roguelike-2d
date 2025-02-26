using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    [Header("-References-")]
    public BulletType rangedAttack;
    public HealingArea healSpell;
    public HollowPurple hollow;

    
    void Update()
    {
        CastHeal();
        CastHollow();
    }
    void CastHeal()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            healSpell.Cast();
        }
    }
    void CastHollow()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            hollow.Fire();
        }
    }
}
