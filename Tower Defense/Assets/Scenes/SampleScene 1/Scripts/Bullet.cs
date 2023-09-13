using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform target;
    public float speed = 70f;
    public GameObject impactEffect;
    public float explosionRadius = 0f;
    public float aoeDamage = 0f;
    public float damage = 50;
    public bool hit = false;
    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    void HitTarget()
    {
        aoeDamage = damage * (aoeDamage / 100f);

        if (!hit)
        {
            GameObject effectIns = Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(effectIns, 1f);
        }


        if (explosionRadius > 0f)
        {
            if (!hit) Explode();

        } else

        {
            if (!hit) Damage(target);
        }
        hit = true;

        Destroy(gameObject, 0.1f);
    }

    void Explode()
    {
        Damage(target);

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy" && collider.gameObject != target.gameObject)
            {
                Debug.Log("calledddd");
                AOEDamage(collider.transform);
            }
        }
    }

    void Damage(Transform enemy)
    {
        //Enemy e = enemy.GetComponent<Enemy>();
        Enemy e = enemy.GetComponentInParent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(damage);
        }
    }


    public void Damage(float damageAmount)
    {
        Enemy e = target.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(damageAmount);
        }
    }

    void AOEDamage(Transform enemy)
    {
        Enemy e = enemy.GetComponentInParent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(aoeDamage);
        }
    }



    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
