using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCharacterStats : MonoBehaviour
{

    public int damageAmount = 10;    // just a default value
    public int hitPoints = 100;        // just a default value

    public Animator anim;

    //temp variables until we make a combat manager feature
    GameObject _target;

    protected void Start()
    {
        // anim = GetComponent<Animator>();
        // play spawn animation
    }

    protected void Attack()
    {
        //push damageAmount to the Damage handler script
        //check if the attacking creature hits.
        //<name attacking creature> used <Attack> on <Target creature>
        //then it should calculate damage incl. modifiers
        //?d? + ? damage
        //if restistant to damage type -> damage / 2
        //if immune to damage type -> damage = 0
        //if vulnerable to damage type -> damage * 2
        //<name attacking creature> hit <Target creature> for <damage>
        //<Target creature> has <healthAmount> hitpoints left.
    }

    protected void DebugStats()
    {
        Debug.Log("Health: " + hitPoints);
        Debug.Log("damage: " + damageAmount);
    }

    protected void DebugAttack()
    {
        Debug.Log("target = " + _target.name);
    }
}