using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTarget : MonoBehaviour
{
    [SerializeField] private MonoBehaviour _aStar;

    private List<Vector3> _path;

    private float _creatureSpd;

    private void Start()
    {
        _path = new List<Vector3>();   
    }

    private void Update()
    {
        
    }
}
