using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SlowEffect : MonoBehaviour
{
    float timeElapsed = 0.0f;
    public Enemy enemy;
    public float timeToDestroy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponentInParent<Enemy>();

        if (!enemy.slowApplied)
        {
                enemy.slowApplied = true; ParticleSystem bleedParticle = Instantiate(enemy.slowSystem, transform.position, transform.rotation).GetComponent<ParticleSystem>();
                bleedParticle.gameObject.transform.parent = transform;
                StartCoroutine(Slow(bleedParticle));
        }
        else Destroy(this);


        

    }

    // Update is called once per frame
    void Update()
    {
           timeElapsed += Time.deltaTime;

    }

    IEnumerator Slow(ParticleSystem system)
    {
        yield return new WaitForSeconds(1f);

        system.Play();
        if (timeElapsed >= timeToDestroy)
        {
            enemy.slowApplied = false;
            Destroy(this);
            Destroy(system.gameObject);
        }
        else
        {
           // StartCoroutine(Slow(system));
        }
    }
}