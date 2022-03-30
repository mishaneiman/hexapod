using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexapodController : MonoBehaviour
{

    public HexapodLeg[] Legs;

    private void Awake()
    {
        Legs = LegSetup();
        
    }

    private void Update()
    {
        MoveForward();
    }

    private void MoveForward()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("Trying to move Forward");
            foreach (HexapodLeg leg in Legs)
            {
                leg.MoveTo(500, 30);
            }
        }
    }

    private HexapodLeg[] LegSetup()
    {
        List<HexapodLeg> LegHolder = new List<HexapodLeg>();
        foreach (Transform child in transform)
        {
            if (child.tag == "LegAnchor")
            {
                LegHolder.Add(child.GetChild(0).GetComponent<HexapodLeg>());
            }
        }
        return LegHolder.ToArray();
    }
}