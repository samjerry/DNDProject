using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour 
{
    [SerializeField]
    private float _rotationSpeed = 15f;

    private bool _isModelPreview;
    private bool _isPlayerPreview;

    private void Start() 
    {
        if (_isModelPreview) 
        {
            StartCoroutine(RotateModel());
        }
    }

    IEnumerator RotateModel()  
    {
        transform.Rotate(Vector3.up * Time.deltaTime * _rotationSpeed);
        yield return null;
    }
}
