using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTeam : Character {

    private void Awake()
    {
        mananger = GameObject.Find("Main Camera").GetComponent<Mananger>();

    }

    // Update is called once per frame


}
