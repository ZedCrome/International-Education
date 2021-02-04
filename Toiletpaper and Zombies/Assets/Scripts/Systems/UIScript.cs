using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIScript : MonoBehaviour
{
    public static UIScript instance;

    public Text CurrentWave;
    public int wavetext;

    


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        ChangeTextWave();
        
    }

    public void ChangeTextWave()
    {

        CurrentWave.text = "Wave " + PlayerPrefs.GetInt("Wave");
    }

    
    

    private void Update()
    {
        PlayerPrefs.SetInt("Wave", wavetext);
        
    }
}
