using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;
//using UnityEditor.UIElements;
using Unity.VisualScripting.Antlr3.Runtime.Misc;

public class PauseMenu : MonoBehaviour
{
    public GameObject ui;
    public GameObject icons;

    public TextMeshProUGUI criticalRate;
    public TextMeshProUGUI criticalDamage;
    public TextMeshProUGUI range;
    public TextMeshProUGUI damage;
    public TextMeshProUGUI fireRate;
    public TextMeshProUGUI uniqueTitle1;
    public TextMeshProUGUI uniqueTitle2;
    public TextMeshProUGUI uniqueValue1;
    public TextMeshProUGUI uniqueValue2;
    public TextMeshProUGUI descriptionText;

    public GameObject SettingsPanel;
    public GameObject PausePanel;
    public GameObject UpgradePanel;
    public int selectedLevel = 0;
    public enum TurretType { Archer, Poison, Ballista, Cannon, Wizard };
    public TurretType turretType;
    public Button[] turretTypeButtons;
    public Image[] turretTypeImage;
    public Button[] turretLevelButtons;
    public Image[] turretLevelImage;


    private void Start()
    {
        turretTypeImage[0] = turretTypeButtons[0].gameObject.GetComponent<Image>();
        turretTypeImage[1] = turretTypeButtons[1].gameObject.GetComponent<Image>();
        turretTypeImage[2] = turretTypeButtons[2].gameObject.GetComponent<Image>();
        turretTypeImage[3] = turretTypeButtons[3].gameObject.GetComponent<Image>();
        turretTypeImage[4] = turretTypeButtons[4].gameObject.GetComponent<Image>();

        turretLevelImage[0] = turretLevelButtons[0].gameObject.GetComponent<Image>();
        turretLevelImage[1] = turretLevelButtons[1].gameObject.GetComponent<Image>();
        turretLevelImage[2] = turretLevelButtons[2].gameObject.GetComponent<Image>();
        turretLevelImage[3] = turretLevelButtons[3].gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);
        icons.SetActive(!icons.activeSelf);

        if (ui.activeSelf)
        {
            Time.timeScale = 0f;
        } else
        {
            Time.timeScale = 1f;
        }
    }

    public void Retry()
    {
        Toggle();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void ShowSettings()
    {
        SettingsPanel.SetActive(true);
        PausePanel.SetActive(false);
        icons.SetActive(false);
    }
    
    public void HideSettings()
    {
        PausePanel.SetActive(true);
        SettingsPanel.SetActive(false);
    }

    public void ShowUpgradePanel()
    {
        UpgradePanel.SetActive(true);
        ui.SetActive(false);
        icons.SetActive(false);

        SelectTurretLevel(0);
        SelectTurretType(0);

        Time.timeScale = 0f;
    }

    public void HideUpgradePanel()
    {
        UpgradePanel.SetActive(false);
        icons.SetActive(true);
        ui.SetActive(false);

        Time.timeScale = 1f;
    }


    public void SelectTurretType(int type)
    {
        switch (type)
        {
            case 1:
                turretType = TurretType.Poison;

            break;
            
            case 2:
                turretType = TurretType.Ballista;

            break;
            
            case 3:
                turretType = TurretType.Cannon;

            break;
            
            case 4:
                turretType = TurretType.Wizard;

            break;

            default:

                turretType = TurretType.Archer;

            break;
        }

        switch (turretType) 
        {
            case TurretType.Archer:
                turretTypeImage[0].color = Color.white;
                turretTypeImage[1].color = Color.gray;
                turretTypeImage[2].color = Color.gray;
                turretTypeImage[3].color = Color.gray;
                turretTypeImage[4].color = Color.gray;

            break;
            
            case TurretType.Poison:
                turretTypeImage[0].color = Color.gray;
                turretTypeImage[1].color = Color.white;
                turretTypeImage[2].color = Color.gray;
                turretTypeImage[3].color = Color.gray;
                turretTypeImage[4].color = Color.gray;

                break;
            
            case TurretType.Ballista:
                turretTypeImage[0].color = Color.gray;
                turretTypeImage[1].color = Color.gray;
                turretTypeImage[2].color = Color.white;
                turretTypeImage[3].color = Color.gray;
                turretTypeImage[4].color = Color.gray;

                break;
            
            case TurretType.Cannon:
                turretTypeImage[0].color = Color.gray;
                turretTypeImage[1].color = Color.gray;
                turretTypeImage[2].color = Color.gray;
                turretTypeImage[3].color = Color.white;
                turretTypeImage[4].color = Color.gray;

                break;
            
            case TurretType.Wizard:
                turretTypeImage[0].color = Color.gray;
                turretTypeImage[1].color = Color.gray;
                turretTypeImage[2].color = Color.gray;
                turretTypeImage[3].color = Color.gray;
                turretTypeImage[4].color = Color.white;

                break;
        
        }

        if (selectedLevel != 0) SelectTurretLevel(selectedLevel-1);
    }
    
    public void SelectTurretLevel(int level)
    {
        switch (level)
        {
            case 0:
                turretLevelImage[0].color = Color.white;
                turretLevelImage[1].color = Color.gray;
                turretLevelImage[2].color = Color.gray;
                turretLevelImage[3].color = Color.gray;
                selectedLevel = 1;

                if (turretType == TurretType.Archer)
                {
                    criticalRate.text = "0" + "%"; criticalDamage.text = "0" + "%";
                    range.text = "15"; damage.text = "5"; fireRate.text = "1";
                    uniqueTitle1.text = "Bleed Damage"; uniqueValue1.text = "0";
                    uniqueTitle2.text = "Bleed Duration"; uniqueValue2.text = "0";
                    descriptionText.text = ""; 

                } else if (turretType == TurretType.Poison) {

                    criticalRate.text = "10" + "%"; criticalDamage.text = "110" + "%";
                    range.text = "11"; damage.text = "5"; fireRate.text = "0.35";
                    uniqueTitle1.text = "Poison Damage"; uniqueValue1.text = "1";
                    uniqueTitle2.text = "Poison Duration"; uniqueValue2.text = "2";
                    descriptionText.text = "Shots can now be critical and apply Poison on the target."; 

                } else if (turretType == TurretType.Ballista) {

                    criticalRate.text = "0" + "%"; criticalDamage.text = "0" + "%";
                    range.text = "13"; damage.text = "10"; fireRate.text = "0.5";
                    uniqueTitle1.text = "Slow Amount"; uniqueValue1.text = "0";
                    uniqueTitle2.text = "Slow Duration"; uniqueValue2.text = "0";
                    descriptionText.text = "";

                } else if (turretType == TurretType.Cannon) {

                    criticalRate.text = "0" + "%"; criticalDamage.text = "0" + "%";
                    range.text = "12"; damage.text = "12"; fireRate.text = "0.35";
                    uniqueTitle1.text = "AOE Damage"; uniqueValue1.text = "5" + "%";
                    uniqueTitle2.text = "AOE Range"; uniqueValue2.text = "2";
                    descriptionText.text = "Shots now deal aditional damage as AOE (Area of Effect).";

                } else {

                    criticalRate.text = "15" + "%"; criticalDamage.text = "120" + "%";
                    range.text = "12"; damage.text = "9"; fireRate.text = "0.4";
                    uniqueTitle1.text = "Shock Amount"; uniqueValue1.text = "1";
                    uniqueTitle2.text = "Shock Duration"; uniqueValue2.text = "2";
                    descriptionText.text = "Shots shock the target and can be critical.\n\n"+ "Shock decreases the target's defense by " + "<color=green>" + uniqueValue1.text + "% " + "</color>" + "every " + "<color=green>" + uniqueValue2.text + "</color>" + " seconds.";
                }
                
                break;

            case 1:
                turretLevelImage[0].color = Color.gray;
                turretLevelImage[1].color = Color.white;
                turretLevelImage[2].color = Color.gray;
                turretLevelImage[3].color = Color.gray;
                selectedLevel = 2;

                if (turretType == TurretType.Archer)
                {
                    criticalRate.text = "50" + "%"; criticalDamage.text = "150" + "%";
                    range.text = "17"; damage.text = "8"; fireRate.text = "1.3";
                    uniqueTitle1.text = "Bleed Damage"; uniqueValue1.text = "0";
                    uniqueTitle2.text = "Bleed Duration"; uniqueValue2.text = "0";
                    descriptionText.text = "Shots can now be critical.";

                }
                else if (turretType == TurretType.Poison)
                {

                    criticalRate.text = "15" + "%"; criticalDamage.text = "120" + "%";
                    range.text = "12"; damage.text = "6"; fireRate.text = "0.65";
                    uniqueTitle1.text = "Poison Damage"; uniqueValue1.text = "2";
                    uniqueTitle2.text = "Poison Duration"; uniqueValue2.text = "3";
                    descriptionText.text = "Poison upgraded. Critical rate and critical damage increased.";

                }
                else if (turretType == TurretType.Ballista)
                {

                    criticalRate.text = "50" + "%"; criticalDamage.text = "150" + "%";
                    range.text = "14"; damage.text = "14"; fireRate.text = "0.85";
                    uniqueTitle1.text = "Slow Amount"; uniqueValue1.text = "0" + "%";
                    uniqueTitle2.text = "Slow Duration"; uniqueValue2.text = "0";
                    descriptionText.text = "Shots can now be critical.";

                }
                else if (turretType == TurretType.Cannon)
                {

                    criticalRate.text = "0" + "%"; criticalDamage.text = "0" + "%";
                    range.text = "13"; damage.text = "14"; fireRate.text = "0.65";
                    uniqueTitle1.text = "AOE Damage"; uniqueValue1.text = "8" + "%";
                    uniqueTitle2.text = "AOE Range"; uniqueValue2.text = "3";
                    descriptionText.text = "AOE range and damage increased.";

                }
                else
                {

                    criticalRate.text = "20" + "%"; criticalDamage.text = "130" + "%";
                    range.text = "13"; damage.text = "12"; fireRate.text = "0.7";
                    uniqueTitle1.text = "Shock Amount"; uniqueValue1.text = "2";
                    uniqueTitle2.text = "Shock Duration"; uniqueValue2.text = "3";
                    descriptionText.text = "Shots shock the target.\n\n" + "Critical rate and critical damage increased.\n\n" +"Shock decreases the target's defense by " + "<color=green>" + uniqueValue1.text + "% " + "</color>" + "every " + "<color=green>" + uniqueValue2.text + "</color>" + " seconds";
                }
                break;

            case 2:
                turretLevelImage[0].color = Color.gray;
                turretLevelImage[1].color = Color.gray;
                turretLevelImage[2].color = Color.white;
                turretLevelImage[3].color = Color.gray;
                selectedLevel = 3;

                if (turretType == TurretType.Archer)
                {
                    criticalRate.text = "75" + "%"; criticalDamage.text = "175" + "%";
                    range.text = "18"; damage.text = "12"; fireRate.text = "1.7";
                    uniqueTitle1.text = "Bleed Damage"; uniqueValue1.text = "1";
                    uniqueTitle2.text = "Bleed Duration"; uniqueValue2.text = "3";
                    descriptionText.text = "Shots now apply bleed effect. Critical rate and critical damage increased.";

                }
                else if (turretType == TurretType.Poison)
                {

                    criticalRate.text = "20" + "%"; criticalDamage.text = "130" + "%";
                    range.text = "14"; damage.text = "8"; fireRate.text = "0.85";
                    uniqueTitle1.text = "Poison Damage"; uniqueValue1.text = "3";
                    uniqueTitle2.text = "Poison Duration"; uniqueValue2.text = "4";
                        descriptionText.text = "Poison upgraded. Critical rate and critical damage increased."; ;

                }
                else if (turretType == TurretType.Ballista)
                {

                    criticalRate.text = "75" + "%"; criticalDamage.text = "175" + "%";
                    range.text = "15"; damage.text = "15"; fireRate.text = "1";
                    uniqueTitle1.text = "Slow Amount"; uniqueValue1.text = "45" + "%";
                    uniqueTitle2.text = "Slow Duration"; uniqueValue2.text = "1.5";
                    descriptionText.text = "Shots now slow the target. Critical rate and critical damage increased.";

                }
                else if (turretType == TurretType.Cannon)
                {

                    criticalRate.text = "0" + "%"; criticalDamage.text = "0" + "%";
                    range.text = "14"; damage.text = "15"; fireRate.text = "0.85";
                    uniqueTitle1.text = "AOE Damage"; uniqueValue1.text = "12" + "%";
                    uniqueTitle2.text = "AOE Range"; uniqueValue2.text = "4";
                    descriptionText.text = "AOE range and damage increased.";

                }
                else
                {

                    criticalRate.text = "30" + "%"; criticalDamage.text = "140" + "%";
                    range.text = "14"; damage.text = "14"; fireRate.text = "1";
                    uniqueTitle1.text = "Shock Amount"; uniqueValue1.text = "3";
                    uniqueTitle2.text = "Shock Duration"; uniqueValue2.text = "4";
                    descriptionText.text = "Shots shock the target.\n\n" + "Shock decreases the target's defense by " + "<color=green>" + uniqueValue1.text + "% " + "</color>" + "every " + "<color=green>" + uniqueValue2.text + "</color>" + " seconds";

                }
                break;

            case 3:
                turretLevelImage[0].color = Color.gray;
                turretLevelImage[1].color = Color.gray;
                turretLevelImage[2].color = Color.gray;
                turretLevelImage[3].color = Color.white;
                selectedLevel = 4;

                if (turretType == TurretType.Archer)
                {
                    criticalRate.text = "100" + "%"; criticalDamage.text = "200" + "%";
                    range.text = "20"; damage.text = "15"; fireRate.text = "2";
                    uniqueTitle1.text = "Bleed Damage"; uniqueValue1.text = "2.5";
                    uniqueTitle2.text = "Bleed Duration"; uniqueValue2.text = "5";
                    descriptionText.text = "Slow effect upgraded. Critical rate and  critical damage increased.";

                }
                else if (turretType == TurretType.Poison)
                {

                    criticalRate.text = "25" + "%"; criticalDamage.text = "150" + "%";
                    range.text = "15"; damage.text = "10"; fireRate.text = "1";
                    uniqueTitle1.text = "Poison Damage"; uniqueValue1.text = "4";
                    uniqueTitle2.text = "Poison Duration"; uniqueValue2.text = "8";
                    descriptionText.text = "Poison upgraded. Critical rate and critical damage increased.";

                }
                else if (turretType == TurretType.Ballista)
                {

                    criticalRate.text = "100" + "%"; criticalDamage.text = "200" + "%";
                    range.text = "17"; damage.text = "20"; fireRate.text = "1.5";
                    uniqueTitle1.text = "Slow Amount"; uniqueValue1.text = "65" + "%";
                    uniqueTitle2.text = "Slow Duration"; uniqueValue2.text = "3";
                    descriptionText.text = "Slow amount and duration increased. Critical rate and critical damage increased.";

                }
                else if (turretType == TurretType.Cannon)
                {

                    criticalRate.text = "25" + "%"; criticalDamage.text = "125" + "%";
                    range.text = "16"; damage.text = "22"; fireRate.text = "1";
                    uniqueTitle1.text = "AOE Damage"; uniqueValue1.text = "20" + "%";
                    uniqueTitle2.text = "AOE Range"; uniqueValue2.text = "8";
                    descriptionText.text = "AOE range and damage increased. Shots can now be critical.";

                }
                else
                {

                    criticalRate.text = "35" + "%"; criticalDamage.text = "170" + "%";
                    range.text = "15"; damage.text = "17"; fireRate.text = "1.5";
                    uniqueTitle1.text = "Shock Amount"; uniqueValue1.text = "4";
                    uniqueTitle2.text = "Shock Duration"; uniqueValue2.text = "8";
                    descriptionText.text = "Shots shock the target.\n\n" + "Critical rate and critical damage increased.\n\n" + "Shock decreases the target's defense by " + "<color=green>"+uniqueValue1.text + "% " + "</color>" + "every " + "<color=green>"+uniqueValue2.text + "</color>" + " seconds";
                    
                }
                break;

        }
    }
}
