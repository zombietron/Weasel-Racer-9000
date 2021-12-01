using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    public override void DealDamage()
    {
        Player.Health -= 2;
    }


}
