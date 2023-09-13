using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    private Node target;
    public GameObject ui;
    public TextMeshProUGUI upgradeCost;
    public TextMeshProUGUI sellAmount;
    public Button upgradeButton;

    public void SetTarget(Node _target)
    {
        target = _target;
        transform.position = target.GetBuildPosition();

        if (!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.currentCostText;
            Debug.Log(target.currentCostText);
            upgradeButton.interactable = true;

        } else
        {
            upgradeCost.text = "Upgraded";
            upgradeButton.interactable = false;
        }

        sellAmount.text = "$" + target.turretBlueprint.GetSellAmount(target.level);
        ui.SetActive(true);
        
        target?.ShowRange();

    }
    

    public void Hide()
    {
        target?.HideRange();
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
