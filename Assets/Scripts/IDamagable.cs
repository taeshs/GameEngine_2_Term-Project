

public interface IDamagable
{
    float Hp { get; }
    float MaxHp { get; }
    void Damage(float damageAmount);
}
