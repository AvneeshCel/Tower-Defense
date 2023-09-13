using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallistaBullet : MonoBehaviour
{
    [SerializeField] private Bullet bullet;
    [SerializeField] private float damage;
    [SerializeField] private float critChance;
    [SerializeField] private float critDamage;
    [SerializeField] private float slowDuration;
    [SerializeField] private float slowAmount;


    bool slowApplied = false;

    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Bullet>();
        slowApplied = false;

        Attack();

    }

    // Update is called once per frame
    void Update()
    {
        if (bullet.hit && !slowApplied)
        {
            Slow();
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

    void Slow()
    {
        if (slowDuration > 0f)
        {
            bullet.target.parent.gameObject.GetComponent<Enemy>().Slow(slowAmount/100f, slowDuration);
            bullet.target.gameObject.AddComponent<SlowEffect>().timeToDestroy = slowDuration;
        }

        slowApplied = true;
        

    }
}
