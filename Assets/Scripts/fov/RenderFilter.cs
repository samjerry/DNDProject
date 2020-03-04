using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderFilter : MonoBehaviour
{
	public int _filterRange = 5;

    [SerializeField] private float _filterRefreshRate = 0.3f;
    [SerializeField] private float _viewAngle = 120;

    private float dstToTarget;

    [SerializeField] private LayerMask _targetMask;
    [SerializeField] private LayerMask[] _obstacleMask;

    [SerializeField] private Material _mSilhouette;
    [SerializeField] private Material _mVisible;


    private List<Transform> visibleTargets;
    private GameObject _target;

    void Start()
    {
        visibleTargets = new List<Transform>();
        StartCoroutine("FindTargetsWithDelay", _filterRefreshRate);
    }

    IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }

    void FindVisibleTargets()
    {
        SetRenderer(visibleTargets, false);
        visibleTargets.Clear();
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, _filterRange, _targetMask);

        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, dirToTarget) < _viewAngle / 2)
            {
                dstToTarget = Vector3.Distance(transform.position, target.position);

                for (int j = 0; j < _obstacleMask.Length; j++)
                {
                    if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, _obstacleMask[j]) && target != transform.root)
                    {
                        visibleTargets.Add(target);
                    }
                }
            }
        }

        SetRenderer(visibleTargets, true);
    }

    void SetRenderer(List<Transform> _targets, bool _visible)
    {
        if (_visible)
        {
            foreach (var target in _targets)
            {
                var _rend = target.gameObject.GetComponentInChildren<Renderer>();

                // if (the target is inside of the viewing range)
                if (visibleTargets.Contains(target))
                {
                    _rend.enabled = true;
                    _rend.material = _mVisible;

                    if (dstToTarget > _filterRange / 2)
                    {
                        _rend.material = _mSilhouette;
                    }
                }

                if (!visibleTargets.Contains(target))
                {
                    _rend.enabled = false;
                }

                
            }
        }

        else
        {
            foreach (var target in _targets)
            {
                var _rend = target.gameObject.GetComponentInChildren<Renderer>();

                // if (the target is outside of range and the creature does not have darkvision)
                _rend.enabled = false;
            }
        }
    }
}
