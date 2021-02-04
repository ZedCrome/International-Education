using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIScript : MonoBehaviour
{
    public static UIScript instance;

    public Text CurrentWave;
    public int wavetext;

    public Text Currentkills;
    public int killstext;

    public Text Currentdamage;
    public int damagetext;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        ChangeTextWave();
        ChangeTextDamage();
        ChangeTextKills();
    }

    public void ChangeTextWave()
    {
       

        CurrentWave.text = "Wave " + wavetext;
    }
    public void ChangeTextDamage()
    {
        Currentdamage.text = "Damage " + damagetext;
    }

    public void ChangeTextKills()
    {
        Currentkills.text = "kills " + killstext;
    }
}
