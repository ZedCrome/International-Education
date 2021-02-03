using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    public float amountOfWaves;
    public float amountOfKills;
    public float amountOfDamage;
    
    public static HUD instance;
    public TMP_Text wave;
    public TMP_Text remainingEnemies;
    public TMP_Text killedEnemeis;
    public TMP_Text damageDealt;

    public TMP_Text health;
    public Slider hpSlider;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(this);    
    }

    public void Wave(int enemyWave)
    {
        wave.text = "Wave: " + enemyWave;
        amountOfWaves = enemyWave;
    }

    public void RemainingEnemies(int enemies)
    {
        remainingEnemies.text = "Enemies remaining: " + enemies;
        
    }

    public void KilledEnemies(int kills)
    {
        killedEnemeis.text = "Enemies killed: " + kills;
        amountOfKills = kills;
    }

    public void DamageDealt(int damage)
    {
        damageDealt.text = "Damage Dealt: " + damage;
        amountOfDamage = damage;
    }

    public void Hp(float hp, float maxHp)
    {
        health.text = hp + "/" + maxHp + "Toiletpaper Remaining";
        hpSlider.maxValue = maxHp;
        hpSlider.value = hp;
    }
}
