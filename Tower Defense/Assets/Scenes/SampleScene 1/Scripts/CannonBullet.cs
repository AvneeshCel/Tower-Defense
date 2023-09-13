using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBullet : MonoBehaviour
{
    [SerializeField] private Bullet bullet;
    [SerializeField] private float damage;
    [SerializeField] private float critChance;
    [SerializeField] private float critDamage;


    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Bullet>();


        Attack();

    }

    // Update is called once per frame
    void Update()
    {

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

}
