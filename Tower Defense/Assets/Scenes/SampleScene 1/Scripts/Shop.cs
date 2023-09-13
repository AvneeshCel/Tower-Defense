using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint archerTower;
    public TurretBlueprint ballistaTower;
    public TurretBlueprint cannonTower;
    public TurretBlueprint poisonTower;
    public TurretBlueprint wizardTower;
    public BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectArcherTurret()
    {
        Debug.Log("Archer Turret Purchased");
        buildManager.SelectTurretToBuild(archerTower);
    }
    
    public void SelectBallistaTurret()
    {
        Debug.Log("Ballista Turret Purchased");
        buildManager.SelectTurretToBuild(ballistaTower);
    }
    
    public void SelectCannonTurret()
    {
        Debug.Log("Cannon Turret Purchased");
        buildManager.SelectTurretToBuild(cannonTower);
    }
    
    public void SelectPoisonTurret()
    {
        Debug.Log("Poison Turret Purchased");
        buildManager.SelectTurretToBuild(poisonTower);
    }
    
    public void SelectWizardTurret()
    {
        Debug.Log("Wizard Turret Purchased");
        buildManager.SelectTurretToBuild(wizardTower);
    }

}
