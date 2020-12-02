using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolB : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    private void Awake()
    {
        transform.position = _enemy.transform.position + _enemy.PatrolRadius;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            _enemy.patrol = true;
        }
    }
}
