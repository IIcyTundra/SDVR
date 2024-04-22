using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AITankAttackPlayerState : AIShootPlayerState
{
    private Transform playerTransform;
    private Transform enemyTransform;
    private Transform weaponTransform;
    private Transform aimTransform;
    private float rotationSpeed;
    private NavMeshAgent enemyNavMesh;
    private float minDistanceFromPlayer;
    private float maxTime;
    private float stopDistance;
    private float timer = 5.0f;
    private Vector3 playerDirection;
    public override void Enter(AIAgent agent){
        playerTransform = agent.playerTransform;
        aimTransform = agent.enemyGun.GetMuzzle();
        weaponTransform = agent.weaponTransform;
        enemyTransform = agent.enemyTransform;
        enemyNavMesh = agent.navMeshAgent;
        minDistanceFromPlayer = agent.config.minDistanceFromPlayer;
        rotationSpeed = agent.config.rotationSpeed;
        maxTime = agent.config.maxTime;
        stopDistance = agent.config.stopDistance;
        agent.enemyGun.SwitchShootingMode();
    }

    public override void Update(AIAgent agent){
        playerDirection = playerTransform.position - enemyTransform.position;
        playerDirection.y = 0;
        Aim();
        if(!agent.enabled){
            Debug.Log("AIChasePlayerState: agent not enabled");
            return;
        }
        timer -= Time.deltaTime;
        if(!enemyNavMesh.hasPath ){//if agent's path hasn't been set, it's set now
            enemyNavMesh.destination = playerTransform.position; 
            enemyNavMesh.stoppingDistance = stopDistance;   
        }
        if(timer < 0.0f){ //after timer runs out, destination is set again IF player is far enough away
            if(playerDirection.sqrMagnitude > (minDistanceFromPlayer * minDistanceFromPlayer)){ //checks distance away from player by taking the area of it
                enemyNavMesh.destination = playerTransform.position; 
                enemyNavMesh.stoppingDistance = stopDistance;   
            }
            timer = maxTime;
        }
    }

    private void Aim(){
         //aims muzzle
        Vector3 aimDirection = aimTransform.forward;
        Vector3 aimDistance = playerTransform.position - aimTransform.position;
        Quaternion targetRotation = Quaternion.FromToRotation(aimDirection, aimDistance);
        weaponTransform.rotation = targetRotation * weaponTransform.rotation;

        //rotates enemy
        Quaternion enemyRotation = Quaternion.LookRotation(playerDirection);
        enemyTransform.rotation = Quaternion.Slerp(enemyTransform.rotation, enemyRotation, Time.deltaTime * rotationSpeed);
    }
}