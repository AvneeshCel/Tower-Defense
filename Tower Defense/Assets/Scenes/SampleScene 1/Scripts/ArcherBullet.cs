using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherBullet : MonoBehaviour
{
    [SerializeField] private Bullet bullet;
    [SerializeField] private float damage;
    [SerializeField] private float critChance;
    [SerializeField] private float critDamage;
    [SerializeField] private float bleedDuration;
    [SerializeField] private float bleedDamage;

    bool bleedApplied = false;

    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Bullet>();
        bleedApplied = false;

        Attack();

    }

    // Update is called once per frame
    void Update()
    {
        if (bullet.hit && !bleedApplied)
        {
            bleedApplied = true;
            Bleed();
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

    void Bleed()
    {

        if (bleedDuration > 0f)
        {
            bullet.target.gameObject.AddComponent<DamageOverTime>().damage = bleedDamage;
            bullet.target.gameObject.GetComponent<DamageOverTime>().duration = bleedDuration;
            bullet.target.gameObject.GetComponent<DamageOverTime>().isBleed = true;


        }


    }
}
