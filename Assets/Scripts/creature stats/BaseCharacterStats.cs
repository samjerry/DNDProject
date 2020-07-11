using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum DamageTypes
{
    Slashing,
    Piercing,
    Bludgeoning,
    Poison,
    Acid,
    Fire,
    Cold,
    Radiant,
    Necrotic,
    Lightning,
    Thunder,
    Force,
    Psychic
}

public abstract class BaseCharacterStats : MonoBehaviour
{
    public string entityName = "Unknown";
    public int damageAmount = 10;    // just a default value
    public int hitPoints = 100;        // just a default value

    public bool turn = false;

    public Animator anim;

    protected void Start()
    {
        // anim = GetComponent<Animator>();
        // play spawn animation
    }

    protected void Attack(GameObject _target, int _damage)
    {
        //------------------------------------------------------------
        CharacterStats _targetStats = _target.GetComponent<CharacterStats>();

        DebugAttack(_targetStats, _damage, false);
        // play attack animation
        _targetStats.hitPoints -= _damage;
        DebugAttack(_targetStats, _damage, true);

        //------------------------------------------------------------


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
        Debug.Log(name + " Health: " + hitPoints);
        Debug.Log(name + " Damage: " + damageAmount);
    }

    protected void DebugAttack(CharacterStats _targetStats, int _damage, bool _hasAttacked)
    {
        if (!_hasAttacked)
        {
            Debug.Log("The target is " + _targetStats.name);
            Debug.Log(_targetStats.name + " has " + _targetStats.hitPoints + " hit points");
        }
        else
        {
            Debug.Log(entityName + " attacks " + _targetStats.name);
            Debug.Log(_targetStats.name + " takes " + _damage + " damage from " + entityName);
            Debug.Log(_targetStats.name + " has " + _targetStats.hitPoints + " hit points left");
        }
    }
}