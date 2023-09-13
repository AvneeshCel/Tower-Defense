using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shock : MonoBehaviour
{
    public float damage;
    public float duration;
    float timeElapsed = 0.0f;
    public Enemy enemy; 

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponentInParent<Enemy>();

        if (!enemy.shockApplied)
        {

            enemy.shockApplied = true; ParticleSystem shockParticle = Instantiate(enemy.shockSystem, transform.position, transform.rotation).GetComponent<ParticleSystem>();
            shockParticle.gameObject.transform.parent = transform;
            StartCoroutine(IShock(shockParticle));
        }
        else Destroy(this);
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
    }

    IEnumerator IShock(ParticleSystem system)
    {
        enemy.defense -= damage;
        enemy.TakeDamage(damage);
        yield return new WaitForSeconds(1f);

        if (timeElapsed >= duration)
        {
            enemy.shockApplied = false;
            Destroy(this);
            Destroy(system);
        }
        else
        {
            StartCoroutine(IShock(system));
        }
    }
}
