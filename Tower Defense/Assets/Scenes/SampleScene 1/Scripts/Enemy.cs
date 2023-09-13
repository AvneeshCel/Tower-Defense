using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Animator anim;
    public float startSpeed = 10f;
     public float speed;

    public float health = 10; public float maxHealth;
    public float defense = 0;

    public int goldDrop = 50;
    public GameObject deathEffect;
    public GameManager manager;
    public bool bleedApplied = false;
    public bool poisonApplied = false;
    public bool shockApplied = false;
    public bool slowApplied = false;
    public Transform cameraTransform;
    public Image healthBar;


    public ParticleSystem bleedSystem;
    public ParticleSystem poisonSystem;
    public ParticleSystem shockSystem;
    public ParticleSystem slowSystem;


    private void Start()
    {
        speed = startSpeed;
        health = maxHealth;
        manager = FindObjectOfType<GameManager>();
        anim = GetComponentInChildren<Animator>();
        healthBar.fillAmount = 1f;
        cameraTransform = Camera.main.transform;

    }

    private void Update()
    {
        //healthBar.transform.parent.LookAt(cameraTransform);
        healthBar.transform.parent.parent.LookAt(cameraTransform);
        
    }

    public float DefenseCalc()
    {

        return Mathf.Lerp(0f, 25f, defense);
    }

    public void TakeDamage(float amount)
    {
        anim.SetTrigger("Damage");
        health -= amount * (1-DefenseCalc()/100f);
        Debug.Log(amount * (1-DefenseCalc() / 100f) + "def am");
        Debug.Log(amount + "amount");
        healthBar.fillAmount = health / maxHealth;

        healthBar.color = new Color(Mathf.Lerp(255f,0f,healthBar.fillAmount), Mathf.Lerp(0f,255f,healthBar.fillAmount),0f);
        if (health <= 0)
        {
            anim.SetTrigger("Die");
            Die();
        }
    }

    void Die()
    {
        PlayerStats.Money += goldDrop;
        manager.CoinAnimSell();
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        DefenseCalc();
        Destroy(effect, 4f);
        Destroy(gameObject);
    }

    public void Slow (float amount, float duration)
    {
        speed = startSpeed * (1 - amount);
        StartCoroutine(SpeedToNormal(duration));

    }

    IEnumerator SpeedToNormal(float time)
    {
        yield return new WaitForSeconds(time);        
        speed = startSpeed;

       
    }

}
