using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceSpawner : MonoBehaviour
{
    private GameObject _targetDice;

    [SerializeField]
    private Button _buttonSpawn;

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

    void Update()
    {

        SpawnDice(_targetDice);
    }

    private void SpawnDice(GameObject _spawnedDice)
    {
        foreach (GameObject _dice in _diceList)
        {
            Instantiate(_dice);
        }
    }

    private void DeleteDice()
    {

    }
}
