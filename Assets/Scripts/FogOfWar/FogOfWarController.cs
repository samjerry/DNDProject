using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum fowTypes
{
    Circular,
    Room,
    Minimap,
    None
}

namespace FOW.Controller {
    public class FogOfWarController : MonoBehaviour
    {
        [SerializeField] private fowTypes _fowType;

        [SerializeField] private List<MonoBehaviour> _fowTypes;

        [SerializeField] private Color _hiddenColor;
        [SerializeField] private Color _visitedColor;
        [SerializeField] private Color _revealedColor;

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
                case fowTypes.Circular:
                    _fowTypes[(int)fowTypes.Circular].enabled = true;
                    break;

                case fowTypes.Room:
                    _fowTypes[(int)fowTypes.Room].enabled = true;
                    break;

                case fowTypes.Minimap:
                    _fowTypes[(int)fowTypes.Minimap].enabled = true;
                    break;

                default:
                    break;
            }

            SetFowColor();
        }

        private void SetFowColor()
        {
            
        }
    }
}