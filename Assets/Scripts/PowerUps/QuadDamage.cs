using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadDamage : PowerUp
{
    public override void ActivatePowerUp(Entity statAffected)
    {
        statAffected.Stats.DamageMultiplier = 1;
    }
}
