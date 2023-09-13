using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBlueprint
{
    public GameObject prefab;
    public int baseCost;

    public GameObject upgraded2Prefab;
    public int upgrade2Cost;
    
    public GameObject upgraded3Prefab;
    public int upgrade3Cost;
    
    public GameObject upgraded4Prefab;
    public int upgrade4Cost;


    public int GetSellAmount(int level)
    {
        //return cost - (cost / 4);
        switch (level)
        {
            case 2:
                return upgrade2Cost - (upgrade2Cost / 4);
                
            case 3:
                return upgrade3Cost - (upgrade3Cost / 4);

            case 4:
                return upgrade4Cost - (upgrade4Cost / 4);
            default:
                return baseCost - (baseCost / 4);
        }
    }

}
