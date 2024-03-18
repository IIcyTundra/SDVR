using UnityEngine;


public class PowerUp : ScriptableObject
{
    public string PowerUpName;
    public string PowerUpDescription;
    public float PowerUpDuration;


    public virtual void ActivatePowerUp(Entity statAffected)
    {
        Debug.Log("PowerUp Activated");
    }

    
}
