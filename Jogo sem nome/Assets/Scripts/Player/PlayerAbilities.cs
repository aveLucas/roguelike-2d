using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    [Header("-References-")]
    public BulletType rangedAttack;
    public HealingArea healSpell;

    
    void Update()
    {
        CastHeal();
    }
    void CastHeal()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            healSpell.Cast();
        }
    }
}
