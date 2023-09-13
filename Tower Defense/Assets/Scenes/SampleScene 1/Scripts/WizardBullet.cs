using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardBullet : MonoBehaviour
{
    [SerializeField] private Bullet bullet;
    [SerializeField] private float damage;
    [SerializeField] private float critChance;
    [SerializeField] private float critDamage;
    [SerializeField] private float shockDuration;
    [SerializeField] private float shockDamage;

    bool shockApplied = false;

    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Bullet>();
        shockApplied = false;

        Attack();

    }

    // Update is called once per frame
    void Update()
    {
        if (bullet.hit && !shockApplied)
        {
            Shock();
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

    void Shock()
    {
        if (shockDuration > 0f)
        {
            bullet.target.gameObject.AddComponent<Shock>().damage = shockDamage;
            bullet.target.gameObject.GetComponent<Shock>().duration = shockDuration;

        }

        shockApplied = true;

    }
}
