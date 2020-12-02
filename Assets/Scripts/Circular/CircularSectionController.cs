using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularSectionController : MonoBehaviour
{
    [SerializeField] Enemy _enemy;
    [SerializeField] CircularSectorMeshRenderer _cs;

    private void Update()
    {
        _cs.radius = _enemy.SightLength;// * 2;
        _cs.degree = (1 - _enemy.SightLevel) * 180;
        _cs.beginOffsetDegree = 90 - (_cs.degree / 2);
    }
}
