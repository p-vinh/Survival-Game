using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tower", menuName = "ScriptableObject/Tower", order = 1)]
public class TowerScriptableObjects : ScriptableObject
{
    public int health;
    public enum type {
        normal,
        recon,
        water,
        explosive
    }

    public type towerType;
    


    
}
