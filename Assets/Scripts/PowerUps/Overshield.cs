using Kitbashery.Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overshield : PowerUp
{
    public override void ActivatePowerUp(Entity statAffected)
    {
        statAffected.EntityHealth.SetMaxHitpoints(200);
    }
}
