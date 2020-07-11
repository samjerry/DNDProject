using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterStats : BaseCharacterStats
{
    void Start()
    {
        base.Start();    // calls the Start() method in the parent class!
        SetCharacterStats(10, 3);

        // the DM will get a prompt and must enter all values into the required fields.
        // all these values will be used in SetCharacterStarts()

        // in here all the stats for the current instance spawn will be assigned e.g. health and damage.
    }

    void Update()
    {
        //do things an enemy child would
    }

    public void SetCharacterStats(int _health, int _damage)
    {
        hitPoints = _health;
        damageAmount = _damage;
        base.DebugStats();
    }
}