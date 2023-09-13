using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    public float countdown = 10f;
    private int waveIndex = 0;
    public float waveCooldownIncrement = 0.5f;

    public TextMeshProUGUI waveCountdownText;
    public TextMeshProUGUI money;
    public TextMeshProUGUI lives;
    public Image waveCooldown;

    private void Start()
    {
        countdown = 15f; timeBetweenWaves = 15f;
    }

    private void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            timeBetweenWaves += waveCooldownIncrement; 
        }

        countdown -= Time.deltaTime;
        
        waveCountdownText.text = countdown.ToString("0.0");
        money.text = PlayerStats.Money.ToString();
        lives.text = PlayerStats.Lives.ToString();
        waveCooldown.fillAmount = countdown/timeBetweenWaves;
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;
        PlayerStats.Rounds++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }        
    }


    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
