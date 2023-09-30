using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ememy Configuration", menuName = "ScriptableObject/Enemy Configuration")]
public class EnemyScriptableObject : ScriptableObject
{
    public int Health = 100;
    public float AIUpdateInterval = 0.5f;
    public float Speed = 1.0f;
    public float Damage = 10.0f;
    public float AttackInterval = 1.0f;
    public float AttackRange = 1.0f;
    public float Acceleration = 1.0f;
    public float height = 1.0f;

    // -1 means all layers
    public int AreaMask = -1;

    public float StoppingDistance = 0.5f;
    public UnityEngine.AI.ObstacleAvoidanceType obstacleAvoidanceType = UnityEngine.AI.ObstacleAvoidanceType.LowQualityObstacleAvoidance;
}
