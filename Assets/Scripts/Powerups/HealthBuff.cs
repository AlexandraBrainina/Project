using UnityEngine;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Powerups/HealthBuff")]
public class HealthBuff : PowerupEffect
{
    public int amount;

    public override void Apply(GameObject target)
    {
        target.GetComponent<Player>().currentHealth += amount;
    }
}