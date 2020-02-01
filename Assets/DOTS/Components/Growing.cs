using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Growing : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale *= 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale *= 1+(Time.deltaTime/10f);
    }
}
