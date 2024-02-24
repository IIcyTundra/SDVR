using Kitbashery.Gameplay;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Entity : MonoBehaviour
{
    protected Health EntityHealth;
    [SerializeField] protected EntityStats Stats;
    protected virtual void Awake()
    {
        EntityHealth = GetComponent<Health>();
        EntityHealth.hitPoints = Stats.MaxHealth; 
    }
}
