
    using System;
    using UnityEngine;

[Serializable]
public struct Stat
{
    [SerializeField] private float _maxHp;
    [SerializeField] private float _maxMp;
    [SerializeField] private float _shootSpeed;
    [SerializeField] private float _attackRate;
    [SerializeField] private float _attackPower;
    [SerializeField] private float _expToLevelup;
    [SerializeField] private float _maxalert;


    private float _hp;
    private float _mp;
    private float _exp;
    private float _level;
    private float _alert;
    //private float _maxalert;

    public Stat(float maxHp = 10, float maxMp = 10, float shootSpeed = 40f, float attackRate = 0.1f,
        float attackPower = 0.1f, float expToLevelup = 10f, float exp = 0f, float level = 1, float alert = 0, float maxalert = 100)
    {
        _maxHp = maxHp;
        _hp = maxHp;
        _maxMp = maxMp;
        _mp = maxMp;
        _shootSpeed = shootSpeed;
        _attackRate = attackRate;
        _attackPower = attackPower;
        _expToLevelup = expToLevelup;
        _exp = exp;
        _level = level;
        _alert = alert;
        _maxalert = maxalert;
    }

    public float MaxHp => _maxHp;

    public float Hp => _hp;

    public float MaxMp => _maxMp;

    public float Mp => _mp;

    public float ShootSpeed => _shootSpeed;

    public float AttackRate => _attackRate;

    public float AttackPower => _attackPower;

    public float Alert => _alert;

    public float MaxAlert => _maxalert;


    public float Exp
    {
        get => _exp;
        set
        {
            _exp = value;

            if (!(_exp / _expToLevelup >= 1f)) return;
            _exp = 0;
            Level++;
        }
    }

    public float Level
    {
        get
        {
            if (_level <= 0) _level = 1;
            return _level;
        }
        set
        {
            _level = value;
        }
    }

    public float ExpToLevelup => _expToLevelup;

    public void AddHp(float hpAmount)
    {
        _hp = Mathf.Clamp(_hp + hpAmount, 0, _maxHp);
    }

    public void AddAlert(float AlertAmount)
    {
        _alert = Mathf.Clamp(_alert + AlertAmount, 0, _maxalert);
    }
    public void SetAlert(float AlertAmount)
    {
        _alert = AlertAmount;
    }
}
