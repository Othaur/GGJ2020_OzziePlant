using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeedDisplay : MonoBehaviour
{
    int seed = Settings.GetSeedCount();
    public Text seedText;
    // Update is called once per frame
    void Update()
    {
        seedText.text = "Seeds:" + seed;
    }





}




