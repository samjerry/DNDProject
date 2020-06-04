using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSpawner : MonoBehaviour
{
    private GameObject _targetDice;

    [SerializeField]
    private GameObject _diceFourSided,
                       _diceSixSided,
                       _diceEightSided,
                       _diceTenSided,
                       _diceTwelveSided,
                       _diceTwentySided,
                       _dicePercentile;

    private List<GameObject> _diceList;

    void Start()
    {
        _diceList = new List<GameObject>();
    }

    public void SetTargetDice(GameObject _dice)
    {
        _targetDice = _dice;
    }

    public void AddToDiceList(GameObject _dice, int _value)
    {
        for (int i = 0; i < _value; i++)
        {
            _diceList.Add(_dice);
        }
    }

    public void SpawnDice(GameObject _spawnedDice)
    {
        foreach (GameObject _dice in _diceList)
        {
            Instantiate(_dice);
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
