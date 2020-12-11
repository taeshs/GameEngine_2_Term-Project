
using System.Collections;
using KPU;
using KPU.Manager;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IDamagable
{
    [SerializeField] private float sightLevel = 0.4f;
    [SerializeField] private float sightLength = 4f;
    [SerializeField] private float attackRange = 1f;
    [SerializeField] private float attackRate = 0.5f;
    [SerializeField] private float attackPower = 0.1f;
    [SerializeField] private LayerMask layerToCast;
    [SerializeField] private Stat status;
    [SerializeField] private Vector3 spawnPosition;
    [SerializeField] private Vector3 patrolRadius;
    [SerializeField] private GameObject patrolA;
    [SerializeField] private GameObject patrolB;

    private Player _player;
    private NavMeshAgent _agent;
    private EnemyState _state;
    private float _attackTimer = 0f;
    public float SightLevel => sightLevel;
    public float SightLength => sightLength;
    public float Hp => status.Hp;
    public float MaxHp => status.MaxHp;
    public float Alert => status.Alert;
    public float MaxAlert => status.MaxAlert;

    public bool patrol = true;

    public Vector3 SpawnPoint => spawnPosition;
    public Vector3 PatrolRadius => patrolRadius;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = FindObjectOfType<Player>();
    }
    private void OnEnable()
    {
        _state = EnemyState.Idle;

        StartCoroutine(LifeRoutine());
    }

    private IEnumerator LifeRoutine()
    {
        while (_state != EnemyState.Dead)
        {
            if (_state == EnemyState.Idle) _state = EnemyState.Finding;
            else if (_state == EnemyState.Finding) Search();
            else if (_state == EnemyState.Chasing) Chase();
            else if (_state == EnemyState.Attacking) Attack();

            if (GameManager.Instance.State == State.GameEnded)
            {
                _state = EnemyState.Dead;
                break;
            }
            yield return null;
        }

        gameObject.SetActive(false);
    }

    private void Search()
    {

        if (patrol)
        {
            _agent.SetDestination(patrolA.transform.position);
            //print("A");
        }
        if (!patrol)
        {
            _agent.SetDestination(patrolB.transform.position);
            //print("B");
        }

        //시야각 로직

        var dir = ((_player.transform.position - transform.position).normalized);
        var dot = Vector3.Dot(transform.forward, dir);

        if (dot > sightLevel)
        {
            if (Physics.Raycast(transform.position, dir, out var raycastsHit, sightLength, layerToCast))
            {
                var hitsObject = raycastsHit.collider.gameObject;
                //print($"Distancess: {Vector3.Distance(transform.position, _player.transform.position)}, TargetPosition: {_player.transform.position}");
                if (hitsObject.CompareTag("Player"))
                {
                    //print($"Distance: {Vector3.Distance(transform.position, _player.transform.position)}, TargetPosition: {_player.transform.position}");
                    _state = EnemyState.Chasing;
                }
            }
        }
    }
    private void Chase()
    {

        //_agent.isStopped = false;

        var dir = ((_player.transform.position - transform.position).normalized);
        var dot = Vector3.Dot(transform.forward, dir);

        float timeAlert = 15.0f * Time.deltaTime;
        _player.AddAlert(timeAlert);

        //enemystate
        if (_player.Alert >= _player.Stat.MaxAlert)
        {
            //print("chase");
            _agent.SetDestination(_player.transform.position);

            if ((_player.transform.position - transform.position).magnitude < attackRange)
             {
            _state = EnemyState.Attacking;
             }

        } 
        else if (dot <= sightLevel || (_player.transform.position - transform.position).magnitude > sightLength * 2)
        {
            _state = EnemyState.Finding;
        }
        else
        {
            //print($"Distance: {Vector3.Distance(transform.position, _player.transform.position)}, TargetPosition: {_player.transform.position}");
            _agent.SetDestination(_player.transform.position);
        }
    }

    private void Attack()
    {
        //print("공격");
        //_agent.isStopped = true;

        if ((_player.transform.position - transform.position).magnitude < attackRange)
        {
            if (_attackTimer > attackRate)
            {
                _player.Damage(attackPower);
                _attackTimer = 0f;
            }
            else
            {
                _attackTimer += Time.deltaTime;
            }

        }
        else
        {
            print("out of range");
            _state = EnemyState.Chasing;
        }
    }
    public void Damage(float damageAmount)
    {
        status.AddHp(-damageAmount);
        if (status.Hp <= 0)
        {
            _state = EnemyState.Dead;
        }
    }

    private void Update()
    {
        if(_player.Alert >= _player.Stat.MaxAlert)
        {
            _agent.speed = 15;
        }
    }

    /*public void Damage(float damageAmount)
    {
        status.Hp = Mathf.Clamp(status.currentHp - damageAmount, 0, status.MaxHp);
        if (status.currentHp <= 0)
        {
            _state = EnemyState.Dead;
        }
    }*/

}
