using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeedDisplay : MonoBehaviour
{
    int seed; 
    public Text seedText;
    // Update is called once per frame
    void Update()
    {
        seed = Settings.GetSeedCount();
        seedText.text = "Seeds:" + seed;
    }





}