using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTarget : MonoBehaviour
{
    public List<Node> _path;

    private float _creatureSpd;
    private float _speed = 1f;

    private void Start()
    {
        _path = new List<Node>();   
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1)) 
        {
            //MoveToTarget();
        }
    }

    
    
    //WERKT NOG NIET!!

    //private void MoveToTarget() {
    //    for (int i = 0; i < _path.Count; i++) {
    //        if (transform.position != _path[i].vPosition) {
    //            transform.position = Vector3.Lerp(transform.position, _path[i].vPosition, (_speed * Time.deltaTime));
    //        }
    //    }
    //}
}
