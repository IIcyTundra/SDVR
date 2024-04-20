using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

[System.Serializable]
public class WeaponAmmoData
{
    public int currentAmmo;
}


public class PlayerData
{
    public int health;
    public Vector3 position;
    public string weaponAmmoData; // Serialized JSON string for weapon ammo data
}

public class JsonSave : MonoBehaviour
{
    PlayerData playerData;
    WeaponAmmoData weaponAmmoData;
    string saveFilePath;

    // Start is called before the first frame update
    void Start()
    {
        //class to store data for player
        playerData = new PlayerData();

        // Create a new instance of WeaponAmmoData and assign the current ammo count
        weaponAmmoData = new WeaponAmmoData();

        saveFilePath = Application.persistentDataPath + "/PlayerData.json";
        NewGame();

    }

    // Update is called once per frame
    void Update()
    {
        // key j oper
        if (Input.GetKeyDown(KeyCode.J))
        {
            SaveGame();
        }
        // key k oper
        if (Input.GetKeyDown(KeyCode.K))
        {
            LoadGame();
        }
        // key l oper
        if (Input.GetKeyDown(KeyCode.L))
        {
            DeleteSaveFile();
        }
        // key m oper
        if (Input.GetKeyDown(KeyCode.M))
        {
            NewGame();
        }
        // key i oper
        if (Input.GetKeyDown(KeyCode.I))
        {
            ChangeData();
        }
    }

    public void SaveGame()
    {
        playerData.position = FindObjectOfType<PlayerCharacter>().PlayerPosition;

        //save weapon info----
        // Access current weapon ammo from WeaponBase
        int weaponAmmo = FindObjectOfType<WeaponBase>().GetCurrentAmmo();
        weaponAmmoData.currentAmmo = weaponAmmo;

        // Serialize weapon ammo data to JSON
        string weaponAmmoJson = JsonUtility.ToJson(weaponAmmoData);

        // Include weapon ammo JSON in the player data
        playerData.weaponAmmoData = weaponAmmoJson;

        // Serialize player data to JSON
        string savePlayerData = JsonUtility.ToJson(playerData);
        System.IO.File.WriteAllText(saveFilePath, savePlayerData);


        Debug.Log("Save file created at: " + saveFilePath);
    }

    public void LoadGame()
    {
        if (System.IO.File.Exists(saveFilePath))
        {
            string loadPlayerData = System.IO.File.ReadAllText(saveFilePath);
            playerData = JsonUtility.FromJson<PlayerData>(loadPlayerData);

            Debug.Log("Load game complete! \nPlayer health: " + playerData.health + ", Player Position: (x = " 
                + playerData.position.x + ", y = " + playerData.position.y + ", z = " + playerData.position.z 
                + "weapondata: " + playerData.weaponAmmoData + ")");

            // Update player position in PlayerCharacter script
            FindObjectOfType<PlayerCharacter>().SetPlayerPosition(playerData.position);

            int ammoResult = Int32.Parse(playerData.weaponAmmoData);

            //Update weapondata ammo
            FindAnyObjectByType<WeaponBase>().SetCurrentAmmo(ammoResult);
        }
        else
        {
            Debug.Log("There is no save files to load!");
        }
    }

    public void DeleteSaveFile() 
    {
        if (System.IO.File.Exists(saveFilePath))
        {
            System.IO.File.Delete(saveFilePath);

            Debug.Log("Save file deleted!");
        }
        else
        {
            Debug.Log("There is nothing to delete!");
        }
    }

    public void NewGame() 
    {
        playerData.health = 100;

        playerData.position = Vector3.zero;

        Debug.Log("New game! \nPlayer health: " + playerData.health + ", Player Position: (x = " 
            + playerData.position.x + ", y = " + playerData.position.y + ", z = " + playerData.position.z + ")");
    }

    public void ChangeData() 
    { }
}
