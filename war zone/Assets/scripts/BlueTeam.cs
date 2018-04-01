using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueTeam : Character {
    private void Awake()
    {
        mananger = GameObject.Find("Main Camera").GetComponent<Mananger>();

    }
    // Use this for initialization


    // Update is called once per frame

}
