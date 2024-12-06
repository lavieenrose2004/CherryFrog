using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : SpecialItem
{
    public override void ApplyEffect(Player player)
    {
        player.EnhanceMaxHealthBy(5);
    }
}
