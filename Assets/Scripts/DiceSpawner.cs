using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceSpawner : MonoBehaviour
{
    [SerializeField]
    private Text _diceAmountText;

    private List<GameObject> _diceList;

    [SerializeField]
    private GameObject _startDice;
    private GameObject _targetDice;

    private int _diceAmount = 0;
    private int _diceInList;
    private int _spawnRadius = 8;


    void Start()
    {
        _diceList = new List<GameObject>();
        _diceAmountText.text = _diceAmount.ToString();
        _targetDice = _startDice;
    }

    public void SetTargetDice(GameObject _dice)
    {
        _targetDice = _dice;
        _diceAmount = 0;
        Debug.Log("Target dice is: " + _targetDice.name);
        SetDiceAmountText();
    }

    private void SetDiceAmountText() 
    {
        _diceInList = 0;

        for (int i = 0; i < _diceList.Count; i++) 
        {
            if (_diceList[i] = _targetDice) 
            {
                _diceInList++;
            }
        }
        _diceAmountText.text = _diceInList.ToString();
    }

    public void ChangeDiceAmount(int _value)
    {
        if (_targetDice != null) 
        {
            if ((_diceAmount + _value) > _diceAmount && (_diceAmount + _value) >= 0) 
            {
                _diceAmount += _value;
                _diceAmountText.text = _diceAmount.ToString();
                AddToDiceList();
            }

            if ((_diceAmount + _value) < _diceAmount && (_diceAmount + _value) >= 0) 
            {
                _diceAmount += _value;
                _diceAmountText.text = _diceAmount.ToString();
                RemoveFromDiceList();
            }
        }
    }

    private void AddToDiceList()
    {
        if (_targetDice != null)
        {
            _diceList.Add(_targetDice);
            Debug.Log("Added: " + _targetDice + " to the dice spawn list");
        }
        Debug.Log("Total dice that will be spawned: " + _diceList.Count);
    }

    public void RemoveFromDiceList() 
    {
        int _diceOfType = 0;
        if (_targetDice != null) 
        {
            for (int i = 0; i < _diceList.Count; i++) 
            {
                if (_diceList[i] == _targetDice) {
                    _diceOfType++;

                    if ((_diceOfType > _diceAmount)) {
                        _diceList.Remove(_diceList[i]);
                        Debug.Log("Removed: " + _targetDice + " from the dice spawn list");
                    }
                }
            }
        }
        Debug.Log("Total dice that will be spawned: " + _diceList.Count);
    }


    public void SpawnDice()
    {
        if (_diceList.Count != 0)
        {
            foreach (GameObject _dice in _diceList)
            {
                Vector3 _randomPos = new Vector3(Random.Range(-_spawnRadius, _spawnRadius),
                                                 transform.position.y,
                                                 Random.Range(-_spawnRadius, _spawnRadius));

                Instantiate(_dice, _randomPos, Random.rotation);
            }
        }
    }

    public void DeleteDice()
    {
        foreach (GameObject _dice in _diceList)
        {
            Destroy(_dice);
        }

        _diceList.Clear();
    }
}
