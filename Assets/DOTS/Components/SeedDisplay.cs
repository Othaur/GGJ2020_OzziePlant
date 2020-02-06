using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SeedDisplay : MonoBehaviour
{
    int seed; 
    public TextMeshProUGUI seedText;
    // Update is called once per frame
    void Update()
    {
        seed = Settings.GetSeedCount();
        seedText.text = "Seeds:" + seed;
    }





}