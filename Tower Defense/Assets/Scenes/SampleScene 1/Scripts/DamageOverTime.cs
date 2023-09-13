using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOverTime : MonoBehaviour
{
    public float damage;
    public float duration;
    float timeElapsed = 0.0f;
    public Enemy enemy;
    public bool isPoison = false;
    public bool isBleed = false;
    public ParticleSystem bleedEffect;
    public GameObject poisonEffect;
    bool bleedCalled, PoisonCalled;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponentInParent<Enemy>();


        if ((isBleed && !enemy.bleedApplied) || (isPoison && !enemy.bleedApplied))
        {
            if (isBleed)
            {
                enemy.bleedApplied = true; ParticleSystem bleedParticle = Instantiate(enemy.bleedSystem, transform.position, transform.rotation).GetComponent<ParticleSystem>();
                bleedParticle.gameObject.transform.parent = transform;
                StartCoroutine(DOTDamage(bleedParticle));
            }

            else if (isPoison)
            {
                enemy.poisonApplied = true; ParticleSystem poisonParticle = Instantiate(enemy.poisonSystem, transform.position, transform.rotation).GetComponent<ParticleSystem>();
                poisonParticle.gameObject.transform.parent = transform;
                StartCoroutine(DOTDamage(poisonParticle));
            }

            else Destroy(this);
        }
    }

        // Update is called once per frame
        void Update()
        {
            timeElapsed += Time.deltaTime;
        }

        IEnumerator DOTDamage(ParticleSystem system)
        {
            enemy.TakeDamage(damage);

            system.Play();
            yield return new WaitForSeconds(1f);

            if (timeElapsed >= duration)
            {
                if (isPoison) { enemy.poisonApplied = false; }
                if (isBleed) { enemy.bleedApplied = false; }
                Destroy(this);
                Destroy(system.gameObject);
            }
            else
            {
                StartCoroutine(DOTDamage(system));
            }
        }
    
}
