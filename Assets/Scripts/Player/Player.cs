using System.Runtime.CompilerServices;
using System.Data;

    using System;
    using System.Collections;
    using System.Linq;
    using KPU;
    using KPU.Manager;
    using UnityEngine;
    using UnityEngine.AI;

public class Player : MonoBehaviour, IDamagable
{
    [SerializeField] private float speed;
    [SerializeField] private Camera cam;
    [SerializeField] private Stat stat;
    [SerializeField] private float noDamageTime = 0.5f;

    float timer =0.0f;

    private NavMeshAgent _agent;
    private PlayerState _state;
    private Coroutine _damageRoutine;
    private bool _isdamagable;
    private MeshRenderer _renderer;

    public PlayerState State => _state;
    public float Hp => stat.Hp;
    public float MaxHp => stat.MaxHp;

    public float Mp => stat.MaxHp;
    public float MaxMp => stat.MaxMp;

    public float Alert => stat.Alert;

    public Stat Stat => stat;

    public float Speed => speed;

    public Camera Cam => cam;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _renderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        EventManager.On("game_started", OnGameStart);
        EventManager.On("game_ended", OnGameEnd);
        EventManager.On("exp_added", ExpAdd);
        gameObject.SetActive(false); // 게임이 시작되면 감춰진 상태로 놓는다

    }

    private bool Booster = false;

    public void BoosterOn(){
        timer = 0.0f;
        print("ddddddddddddd");
        Booster = true;
    }

    private void OnGameStart(object obj)
    {
        print("start");

            gameObject.SetActive(true);

            //_throwRoutine = StartCoroutine(ShootRoutine());
    }

    private void OnGameEnd(object obj)
    {
            //StopCoroutine(_throwRoutine);
            gameObject.SetActive(false);
    }


    private void OnEnable()
    {
        _isdamagable = true;
        stat.AddHp(stat.MaxHp);
        stat.SetAlert(0);
    }

    private void OnDisable()
    {
        if (_damageRoutine != null) StopCoroutine(_damageRoutine);
    }

    private void Update()
    {
        if(Hp <=0)
        {
        EventManager.Emit("game_ended", null);
        }

        if (Booster)
        {
            print(timer);
            if(timer <5.0f)
            {
                timer += Time.deltaTime;
                speed = 30;
            }
            else
            {
                Booster = false;
                speed = 10;
            }
  
        }
        
        //var camTowardVector = (transform.position - cam.transform.position).normalized;
        //var finalVector = (camTowardVector * Input.GetAxis("Vertical") +
        //                   cam.transform.right * Input.GetAxis("Horizontal")) * (speed * Time.deltaTime);
        //var yRemovedVector = new Vector3(finalVector.x, 0, finalVector.z);
        //_agent.Move(yRemovedVector);

        //if (finalVector.magnitude >= Mathf.Epsilon)
         //   transform.rotation = Quaternion.LookRotation(yRemovedVector);
    }

    private void ExpAdd(object obj)
    {
        stat.Exp += (float)obj;
    }

    public void Damage(float damageAmount)
    {
        if (!_isdamagable) return;
        _damageRoutine = StartCoroutine(DamageRoutine(damageAmount));
    }

    public void AddAlert(float Amount)
    {
        stat.AddAlert(Amount);
        //print(stat.Alert);
    }

    private IEnumerator DamageRoutine(float damageAmount)
    {
        stat.AddHp(-damageAmount);
        var material = _renderer.material;
        var defaultColor = material.color;

        material.color = new Color(1, 1, 1, 0.5f);
        _isdamagable = false;

        yield return new WaitForSeconds(noDamageTime);

        material.color = defaultColor;
        _isdamagable = true;

    
    }
}
