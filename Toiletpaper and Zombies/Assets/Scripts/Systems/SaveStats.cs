using System;
using UnityEngine;
using System.Collections;
using System.IO;
public class SaveStats : MonoBehaviour
{
    public static SaveStats instance;

    private string gameDataSave = "save.json";

    private HUD hud;
    public int rounds;
    public int kills;
    public int damage;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(this);  
    }

    void Start()
    {
        hud = HUD.instance;
    }

    private void SavePlayerStats()
    {
        PlayerPrefs.SetFloat("waves-cleared", hud.amountOfWaves);
        
        PlayerPrefs.SetString("enemies-killed", hud.killedEnemeis.ToString());
        PlayerPrefs.SetString("damage-dealt", hud.damageDealt.ToString());
    }
    
    private void LoadPlayerStats()
    {
        
    }
}
