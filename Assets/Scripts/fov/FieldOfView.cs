using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float _viewRadius;
    [Range(0,360)]
    public float _viewAngle;

    public LayerMask targetMask;
    public LayerMask[] obstacleMask;

    [HideInInspector]
    public List<Transform> visibleTargets = new List<Transform>();

    private void Start() {
        StartCoroutine("FindTargetsWithDelay", .2f);
    }

    IEnumerator FindTargetsWithDelay(float delay) {
        while (true) {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }

    void FindVisibleTargets() {
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, _viewRadius, targetMask);

        for (int i = 0; i < targetsInViewRadius.Length; i++) {
            visibleTargets.Clear();
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position = transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToTarget) < _viewAngle / 2) {
                float dstToTarget = Vector3.Distance(transform.position, target.position);

                for (int j = 0; j < obstacleMask.Length; j++) {
                    if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask[j])) {
                        visibleTargets.Add(target);
                    }
                }
            }
        }
    }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal) {
        if (!angleIsGlobal) {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    } 
}
