using System.Collections;
using System.Collections.Generic;

using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public struct EnemyMovement
    {
        public float UpdateRate;
        public float LastUpdateTime;
        
    }

    public EnemyScriptableObject EnemyScriptableObject;
    public EnemyMovement Movement;
    public NavMesh Agent;
    public int health = 100;
    
    public void OnDisable()
    {
        base.OnDisable();
        Agent.enabled = false;
    }

    public void OnEnable()
    {
        SetUpAgentFromConfiguration();
    }

    public virtual void SetUpAgentFromConfiguration() {
        Agent.speed = EnemyScriptableObject.Speed;
        Agent.acceleration = EnemyScriptableObject.Acceleration;
        Agent.stoppingDistance = EnemyScriptableObject.StoppingDistance;
        Agent.obstacleAvoidanceType = EnemyScriptableObject.obstacleAvoidanceType;
        Agent.height = EnemyScriptableObject.height;
        Agent.radius = EnemyScriptableObject.AttackRange;
        Agent.areaMask = EnemyScriptableObject.AreaMask;

        Movement.UpdateRate = EnemyScriptableObject.AIUpdateInterval;
        health = EnemyScriptableObject.Health;
    }
}
