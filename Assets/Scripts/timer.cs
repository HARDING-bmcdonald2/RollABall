using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer : MonoBehaviour
{
    public GameObject playerObject;

    // Start is called before the first frame update
    void Start()
    {
        playerObject.SendMessage("testMethod");
    }

    // Update is called once per frame
    void Update()
    {
        // New comment
    }
}
