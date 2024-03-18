<<<<<<< HEAD

using UnityEngine;
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kitbashery.Gameplay;
using UnityEditor.PackageManager;
>>>>>>> dondev2

public class EnemyWeapon : WeaponBase
{
    private bool CanShoot = false; //instead of using mouse input, this class uses a bool to switch from shooting to not shooting

    protected override void Update()
    {
<<<<<<< HEAD
        if(CanShoot){
            Shoot();
        }
        if(currentAmmo < 0){
            Reload();
        }
        
=======
        //Tick(CanShoot);
>>>>>>> dondev2
    }

    

    public void SwitchShootingMode(){ //switches shooting mode
        CanShoot = !CanShoot;
    }

}
    
