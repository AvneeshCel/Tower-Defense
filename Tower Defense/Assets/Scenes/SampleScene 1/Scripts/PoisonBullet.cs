using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonBullet : MonoBehaviour
{
    [SerializeField] private Bullet bullet;
    [SerializeField] private float damage;
    [SerializeField] private float critChance;
    [SerializeField] private float critDamage;
    [SerializeField] private float poisonDuration;
    [SerializeField] private float poisonDamage;

    bool poisonApplied = false;

    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Bullet>();
        poisonApplied = false;

        Attack();

    }

    // Update is called once per frame
    void Update()
    {
        if (bullet.hit && !poisonApplied)
        {
            Poison();
        }
    }

    void Attack()
    {
        float randValue = Random.value;

        if (randValue < critChance)
        {
            //Do crit attack
            bullet.damage = damage * (critDamage / 100f);
        }
        else
        {
            //Do normal attach
            bullet.damage = damage;
        }
    }

    void Poison()
    {
        if (poisonDuration > 0f)
        {
            bullet.target.gameObject.AddComponent<DamageOverTime>().damage = poisonDamage;
            bullet.target.gameObject.GetComponent<DamageOverTime>().duration = poisonDuration;
            bullet.target.gameObject.GetComponent<DamageOverTime>().isPoison = true;

        }

        poisonApplied = true;

    }
}
