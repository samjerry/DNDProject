using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTarget : MonoBehaviour
{
    public List<Node> _path;

    private int _creatureBaseSpd = 40;
    private int _creatureSpd;
    private int _remainingSteps;
    private float _speed = 3f;
    private int _stepCost = 5;

    private void Start()
    {
        _creatureSpd = _creatureBaseSpd;
        _remainingSteps = _creatureSpd;
        _path = new List<Node>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1)) 
        {
            StartCoroutine("MoveToTarget");
            //MoveToTarget();
        }
    }

  

    //WERKT NOG NIET 100%!!
    //MOET SMOOTHER GAAN!!

    private IEnumerator MoveToTarget()
    {
        for (int x = 0; x < _path.Count; x++)
        {
            transform.position = Vector3.Lerp(transform.position, _path[x].vPosition, _speed);

            if (transform.position == _path[x].vPosition)
            {
                _remainingSteps -= _stepCost;
                yield return new WaitForSeconds(_speed * Time.deltaTime);
            }

            if (_remainingSteps == 0)
            {
                break;
            }

            if (x == _path.Count)
            {
                break;
            }

        }
        //    for (int i = 0; i < _path.Count; i++) {
        //        if (transform.position != _path[i].vPosition) {
        //            transform.position = Vector3.Lerp(transform.position, _path[i].vPosition, (_speed * Time.deltaTime));
        //        }
        //    }
        StopCoroutine("MoveToTarget");
    }

    public void ResetStepCount()
    {
        _remainingSteps = _creatureSpd;
    }

    public void ResetSpeed()
    {
        _creatureSpd = _creatureBaseSpd;
    }

    public void IncreaseSpeed(int _amount)
    {
        _creatureSpd += _amount;
    }

    public void ReduceSpeed(int _amount)
    {
        _creatureSpd -= _amount;
    }
}
