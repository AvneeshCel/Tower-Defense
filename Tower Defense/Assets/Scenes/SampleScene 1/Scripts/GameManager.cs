using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public static bool GameisOver;
    //public GameObject turretChoiceMenu;
    public RectTransform turretChoiceMenu;
    public float timer;
    public bool finished = false;
    public Shop shop;
    public GameObject cross;

    public RectTransform heartBackground; 
    public RectTransform coinBackground; 
    public Image coinBackgroundImage; 


    private void Start()
    {
        GameisOver = false;    
    }

    // Update is called once per frame
    void Update()
    {
        if (GameisOver) return;

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }

    }
    void EndGame()
    {
        GameisOver = true;
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void BringTurretChoices()
    {
        if (turretChoiceMenu.anchoredPosition.y == -57f)
        {
            InvokeRepeating("OpenAnimationShop", 0f, Time.deltaTime / 6f);
        }
        
        if (turretChoiceMenu.anchoredPosition.y == 53f)
        {
            InvokeRepeating("CloseAnimationShop", 0f, Time.deltaTime / 6f);
        }


        finished = false;
    }
    

    void OpenAnimationShop()
    {
        if (!finished)
        {
            // turretChoiceMenu.transform.position = new Vector3(0f, Mathf.Lerp(-57f, 53f, timer), 0f);
            turretChoiceMenu.anchoredPosition = new Vector3(0f, Mathf.Lerp(-57f, 53f, timer), 0f);

            timer += Time.deltaTime;
        }

        if (turretChoiceMenu.anchoredPosition.y == 53f)
        {
            CancelInvoke("OpenAnimationShop");
            timer = 0f;
            finished = true;
            cross.SetActive(true);
        }

    }
    
    void CloseAnimationShop()
    {
        if (!finished)
        {
            // turretChoiceMenu.transform.position = new Vector3(0f, Mathf.Lerp(-57f, 53f, timer), 0f);
            turretChoiceMenu.anchoredPosition = new Vector3(0f, Mathf.Lerp(53f, -57f, timer), 0f);

            timer += Time.deltaTime;
        }

        if (turretChoiceMenu.anchoredPosition.y == -57f)
        {
            CancelInvoke("CloseAnimationShop");
            timer = 0f;
            finished = true;
            cross.SetActive(false);
        }

    }

    public void SetToNull()
    {
        shop.buildManager.SetToNull();
    }

    public void HeartAnim()
    {
        heartBackground.localScale = new Vector3(1.125f, 1.125f, 1f);
        Invoke("HeartAnimNormal", 0.1f);
    }

    public void HeartAnimNormal()
    {
        heartBackground.localScale = Vector3.one;
    }
    
    public void CoinAnimBuy()
    {
        coinBackground.localScale = new Vector3(1.125f, 1.125f, 1f);
        coinBackgroundImage.color = Color.red;
        Invoke("CoinAnimNormal", 0.1f);
    }
    
    public void CoinAnimSell()
    {
        coinBackground.localScale = new Vector3(1.125f, 1.125f, 1f);
        coinBackgroundImage.color = Color.green;
        Invoke("CoinAnimNormal", 0.1f);
    }

    public void CoinAnimNormal()
    {
        coinBackground.localScale = Vector3.one;
        coinBackgroundImage.color = Color.white;
    }
}
