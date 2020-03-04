using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum fogOfWarTypes
{
    Circular,
    Room,
    Minimap,
    None
}

public class FogOfWarController : MonoBehaviour
{
    [SerializeField] private fogOfWarTypes _fowType;

    [SerializeField] private List<MonoBehaviour> _fowTypes;

    private MonoBehaviour _currentFOWType;

    public Color _hiddenColor;
    public Color _visitedColor;
    public Color _revealedColor;

    private void Start()
    {
        _fowTypes = new List<MonoBehaviour>();

        for (int i = 0; i < _fowTypes.Count; i++)
        {
            _fowTypes[i].enabled = false;
        }

        GetFowType();
    }

    private void GetFowType()
    {
        switch (_fowType)
        {
            case fogOfWarTypes.Circular:
                _fowTypes[(int)fogOfWarTypes.Circular].enabled = true;
                _currentFOWType = _fowTypes[0];
                break;

            case fogOfWarTypes.Room:
                _fowTypes[(int)fogOfWarTypes.Room].enabled = true;
                _currentFOWType = _fowTypes[1];
                break;

            case fogOfWarTypes.Minimap:
                _fowTypes[(int)fogOfWarTypes.Minimap].enabled = true;
                _currentFOWType = _fowTypes[2];
                break;

            default:
                break;
        }
    }

    public void SetFowColor()
    {

    }
}
