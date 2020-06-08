using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowModel : MonoBehaviour
{
    [SerializeField]
    private ShowModelButton buttonPrefab;

    private void Start() 
    {
        var _models = FindObjectsOfType<ShowModelController>().GetModels();
        foreach (var _model in _models) 
        {
            CreateButtonForModel(_model);
        }
    }

    private void CreateButtonForModel(Transform _model) 
    {

    }
}
