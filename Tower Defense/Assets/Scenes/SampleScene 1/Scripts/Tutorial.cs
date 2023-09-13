using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject Obj1;
    public GameObject Obj2;
    public GameObject Obj3;
    public GameObject spaceToContinue;
    int tutorialfinished;

    private void Awake()
    {
        tutorialfinished = PlayerPrefs.GetInt("Tutorial");

        if (tutorialfinished == 1)
        {
            Obj1.SetActive(true);
            Obj2.SetActive(false);
            Obj3.SetActive(false);
        }

        else Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyUp(KeyCode.Space))
        {

            bool can = true;
            can = true;

            if (Obj1.activeInHierarchy && can)
            {
                Obj2.SetActive(true);
                Obj1.SetActive(false);
                Obj3.SetActive(false);
                can = false;
                Time.timeScale = 0f;
            }


            if (Obj2.activeInHierarchy && can)
            {
                Obj1.SetActive(false);
                Obj2.SetActive(false);
                Obj3.SetActive(true);
                spaceToContinue.SetActive(true);
                can = false;
                Time.timeScale = 0f;
            }
            
            if (Obj3.activeInHierarchy && can)
            {
                spaceToContinue.SetActive(false);
                PlayerPrefs.SetInt("Tutorial", 1);
                Time.timeScale = 1f;
                Destroy(gameObject);
            }

        }
    }
}
