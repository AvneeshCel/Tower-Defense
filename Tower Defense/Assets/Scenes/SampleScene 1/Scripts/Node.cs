using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;
    public Color notEnoughMoneyColor;
    
    [HideInInspector]
    public GameObject turret;
    private Color startColor;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;
    public int level = 1;
    public float currentCostText;
    public float currentCost;
    public GameManager manager;

    private Renderer rend;
    public Transform range;

    BuildManager buildManager;
    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
        level = 1;
        currentCostText = turretBlueprint.baseCost;
        currentCost = turretBlueprint.baseCost;
        manager = FindObjectOfType<GameManager>();

    }
    
    private void OnMouseUp()
    {
        
       // if (turret != null) range.gameObject.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild) return;

        //if (turret != null) range.gameObject.SetActive(true);

        BuildTurret(buildManager.GetTurretToBuild());
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (!buildManager.CanBuild) return;

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }

        else rend.material.color = notEnoughMoneyColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.baseCost)
        {
            Debug.Log("Not enough money");
            return;
        }

        //turretBlueprint.RangeSearch(0);

        PlayerStats.Money -= blueprint.baseCost;
        manager.CoinAnimBuy();
        currentCost = blueprint.baseCost;
        currentCostText = blueprint.upgrade2Cost;
        

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;
        turretBlueprint = blueprint;
        range = turret.transform.Find("Range");
        HideRange();
        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 4f);
    }

    public void UpgradeTurret()
    {

        if (PlayerStats.Money < currentCostText)
        {
            Debug.Log("Not enough money to upgrade");
            
            return;
        }

        else
        {
            switch (level)
            {
                case 1:
                    currentCostText = turretBlueprint.upgrade3Cost;
                    currentCost = turretBlueprint.upgrade2Cost;
                   // turretBlueprint.RangeSearch(1);
                    break;
                case 2:
                    currentCostText = turretBlueprint.upgrade4Cost;
                    currentCost = turretBlueprint.upgrade3Cost;
                    //turretBlueprint.RangeSearch(2);
                    break;
                case 3:
                    currentCost = turretBlueprint.upgrade4Cost;
                  //  turretBlueprint.RangeSearch(3);
                    isUpgraded = true;
                    break;
            }

            PlayerStats.Money -= (int)currentCost;
            manager.CoinAnimBuy();

            //Get rid of the old turret
            Destroy(turret);
            level++;

            //Build a new one
            //GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgraded2Prefab, GetBuildPosition(), Quaternion.identity);
            //turret = _turret;
       

            switch (level)
            {
                case 2:
                    GameObject _turret1 = (GameObject)Instantiate(turretBlueprint.upgraded2Prefab, GetBuildPosition(), Quaternion.identity);
                    turret = _turret1;
                    range = turret.transform.Find("Range");
                    break;
                case 3:
                    GameObject _turret3 = (GameObject)Instantiate(turretBlueprint.upgraded3Prefab, GetBuildPosition(), Quaternion.identity);
                    turret = _turret3;
                    range = turret.transform.Find("Range");
                    break;
                case 4:
                    GameObject _turret4 = (GameObject)Instantiate(turretBlueprint.upgraded4Prefab, GetBuildPosition(), Quaternion.identity);
                    turret = _turret4;
                    range = turret.transform.Find("Range");
                    break;
            }



            GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
            Destroy(effect, 4f);

        }


      //  isUpgraded = true;
    }

    public void SellTurret()
    {
        PlayerStats.Money += turretBlueprint.GetSellAmount(level);
        manager.CoinAnimSell();
        Destroy(turret);
        turretBlueprint = null;
    }

    public void ShowRange()
    {
        range.gameObject.SetActive(true);

    }
    
    public void HideRange()
    {
        range.gameObject.SetActive(false);

    }
    private void Update()
    {
        
    }
}
