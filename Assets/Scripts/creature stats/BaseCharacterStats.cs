using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCharacterStats : MonoBehaviour
{
    private DamageHandler damageHandler;
    public string entityName = "Unknown";
    public int hitPoints = 100;        // just a default value

    public int damageAmount = 0;
    public int diceAmount = 2;    // just a default value
    public int diceType = 6;
    public DamageTypes.DamageType damageType;

    public DamageTypes.DamageType[] vulnerability;
    public DamageTypes.DamageType[] resistance;
    public DamageTypes.DamageType[] immunity;

    public bool turn = false;

    public Animator anim;

    protected void Start()
    {
        damageHandler = GameObject.Find("Combat Manager").GetComponent<DamageHandler>();
        // anim = GetComponent<Animator>();
        // play spawn animation
    }

    protected void Attack(GameObject _target, int _damage)
    {
        //------------------------------------------------------------
        CharacterStats _targetStats = _target.GetComponent<CharacterStats>();
        DebugAttack(_targetStats, _damage, false);
        // play attack animation
        damageHandler.ApplyDamage(_target, damageHandler.Damage(_target, diceAmount, diceType, damageAmount, damageType));
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
        Debug.Log(entityName + " Health: " + hitPoints);
        Debug.Log(entityName + " Damage: " + diceAmount + "d" + diceType);
    }

    protected void DebugAttack(CharacterStats _targetStats, int _damage, bool _hasAttacked)
    {
        if (!_hasAttacked)
        {
            Debug.Log("The target is " + _targetStats.entityName);
            Debug.Log(_targetStats.entityName + " has " + _targetStats.hitPoints + " hit points");
        }
        else
        {
            Debug.Log(entityName + " attacks " + _targetStats.entityName);
            Debug.Log(_targetStats.entityName + " has " + _targetStats.hitPoints + " hit points left");
        }
    }
}