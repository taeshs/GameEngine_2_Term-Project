
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
                if (hitsObject.CompareTag("play"))
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

        float timeAlert = 5.0f * Time.deltaTime;
        _player.AddAlert(timeAlert);

        

        //print(_player.Alert);

        // if( alert >= maxalert) _agent.SetDestination(_player.transform.position);   else

        
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
        _agent.isStopped = true;

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
            _state = EnemyState.Idle;
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

    /*public void Damage(float damageAmount)
    {
        status.Hp = Mathf.Clamp(status.currentHp - damageAmount, 0, status.MaxHp);
        if (status.currentHp <= 0)
        {
            _state = EnemyState.Dead;
        }
    }*/

}





/*
    using System.Collections;
    using KPU.Manager;
    //using UI;
    using UnityEngine;
    using UnityEngine.AI;

public class Enemy : MonoBehaviour, IDamagable
{
    private NavMeshAgent _agent;
    private Player _player;
    private Coroutine _lifeRoutine;
    private EnemyState _state;
    private float _timer;
    private Vector3 _targetPosition;

    [SerializeField] private Stat stat;
    [SerializeField] private float sightAngle = 0.2f;
    [SerializeField] private float sightLength = 2f;
    [SerializeField] private LayerMask layerToCast;
    [SerializeField] private float hitPlayerDistanceOffset = 1;

    public float Hp => stat.Hp;
    public float MaxHp => stat.MaxHp;


    #region Unity Life Cycle

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = FindObjectOfType<Player>();
    }

    private void OnEnable()
    {
        _state = EnemyState.Idle;
        stat.AddHp(stat.MaxHp);
        _lifeRoutine = StartCoroutine(LifeRoutine());

        /*if (_healthBar == null)
        {
            _healthBar = ObjectPoolManager.Instance.Spawn("healthbar").GetComponent<HealthBarUi>();
            _healthBar.Initialize(this, transform);
            _healthBar.transform.parent = FindObjectOfType<Canvas>().transform;
        }
        else _healthBar.gameObject.SetActive(true);*//*


    }

    private void OnDisable()
    {
        if (_lifeRoutine != null) StopCoroutine(_lifeRoutine);
        //if (_healthBar != null) _healthBar.gameObject.SetActive(false);

        _lifeRoutine = null;
    }

    #endregion

    #region FSM

    private IEnumerator LifeRoutine()
    {
        while (_state != EnemyState.Dead)
        {
            if (_state == EnemyState.Idle) Idle();
            else if (_state == EnemyState.Finding) Find();
            else if (_state == EnemyState.Chasing) Chasing();
            else if (_state == EnemyState.Attacking) Attack();
            yield return null;
        }

        Death();
    }

    private void Death()
    {
        // effect.
        var deathEffectGameObject = ObjectPoolManager.Instance.Spawn("effect_enemy_death");
        deathEffectGameObject.transform.position = transform.position;
        deathEffectGameObject.SetActive(true);

        // money raise
        //GameStateManager.Instance.money += 1;
        EventManager.Emit("exp_added", 1f);

        gameObject.SetActive(false);
    }

    private void Attack()
    {
        if ((_player.transform.position - transform.position).magnitude <= hitPlayerDistanceOffset &&
            _timer >= stat.AttackRate)
        {
            _player.Damage(stat.AttackPower);

            var effectGameObject = ObjectPoolManager.Instance.Spawn("effect_hit");
            effectGameObject.SetActive(true);
            effectGameObject.transform.position = transform.position;

            _timer = 0f;
        }
        else
        {
            _timer += Time.deltaTime;
        }
    }

    private void Chasing()
    {
        _agent.isStopped = false;

        if ((_player.transform.position - transform.position).magnitude < attackRange)
        {
            _state = EnemyState.Attacking;
        }
        else
        {
            _agent.SetDestination(_player.transform.position);
        }
    }

    private void Find()
    {
        print("finding");
        _agent.isStopped = false;

        print($"Distance: {Vector3.Distance(transform.position, _targetPosition)}, TargetPosition: {_targetPosition}");

        if (_targetPosition == Vector3.zero || Vector3.Distance(transform.position, _targetPosition) < _agent.stoppingDistance)
        {
            NavMesh.SamplePosition(new Vector3(transform.position.x + Random.Range(-2, 2), transform.position.y,
                transform.position.z + Random.Range(-2, 2)), out var hit, 2f, 0);
            if (hit.hit)
                _targetPosition = hit.position;

            _agent.SetDestination(_targetPosition);
        }

        var angle = Vector3.Dot((_player.transform.position - transform.position).normalized,
            transform.forward);

        if (angle > sightAngle && Physics.Raycast(transform.position,
            (_player.transform.position - transform.position).normalized, out var racastHit,
            sightLength, layerToCast) && racastHit.collider.CompareTag("Player"))
            _state = EnemyState.Chasing;
    }

    private void Idle()
    {
        _agent.isStopped = true;
        _state = EnemyState.Finding;
    }

    #endregion

    #region API

    public void Damage(float damageAmount)
    {
        stat.AddHp(-damageAmount);
        if (stat.Hp <= 0)
        {
            _state = EnemyState.Dead;
        }
    }

    #endregion
}

*/