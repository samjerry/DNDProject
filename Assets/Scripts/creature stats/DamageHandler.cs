using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    private CharacterUIManager _characterUI;

    private void Start()
    {
        _characterUI = GetComponent<CharacterUIManager>();    
    }

    private int Damage(GameObject _target, int _amount, int _sidedDice, int _baseDamage, string _type)
    {
        int _damage;
        _damage = RollDamage(_amount, _sidedDice, _baseDamage);

        if (IsVulnerable(_target, _type))
        {
            _damage *= 2;
        }

        else if (IsResistant(_target, _type))
        {
            _damage /= 2;
        }

        else if (IsImmune(_target, _type))
        {
            _damage = 0;
        }

        return _damage;
    }

    private int RollDamage(int _amount, int _sidedDice, int _baseDamage)
    {
        int _damage = _amount * _sidedDice + _baseDamage;
        return _damage;
    }

    private bool IsVulnerable(GameObject _target, string _type)
    {
        //check the damage type of the attack
        //check through the vulnerable list of the target
        //if the type is in the list return true
        //if it is not in the list return false
        return false;
    }

    private bool IsResistant(GameObject _target, string _type)
    {
        //check the damage type of the attack
        //check through the resistance list of the target
        //if the type is in the list return true
        //if it is not in the list return false
        return false;
    }

    private bool IsImmune(GameObject _target, string _type)
    {
        //check the damage type of the attack
        //check through the immunity list of the target
        //if the type is in the list return true
        //if it is not in the list return false
        return false;
    }

    private void ApplyDamage(GameObject _target, int _damage)
    {
        _characterUI.SetHealthUI(_target);
    }
}
