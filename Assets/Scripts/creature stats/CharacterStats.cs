using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterStats : BaseCharacterStats
{
    void Start()
    {
        base.Start();    // calls the Start() method in the parent class!
        DebugStats();

        // the DM will get a prompt and must enter all values into the required fields.
        // all these values will be used in SetCharacterStarts()
    }

    void Update()
    {
        //do things an enemy child would
        if (Input.GetKeyDown(KeyCode.Space) && turn)
        {
            Attack(GameObject.Find("Player"), damageAmount);
        }
    }
}