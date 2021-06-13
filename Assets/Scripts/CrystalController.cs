using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrystalController : MonoBehaviour
{
  public static CrystalController instance;

  public GameObject crystalContainer;


  private int numTotalCrystals, numSlayedCrystals;

    public Text crystalCounter;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        numTotalCrystals = crystalContainer.transform.childCount;
        numSlayedCrystals = 0;
        crystalCounter.text = "Crystals: 0 / " + numTotalCrystals;
    }

    public void SlayCrystal()
    {
        numSlayedCrystals++;

        string crystalCounterStr = "Crystals: " + numSlayedCrystals + " / " + numTotalCrystals;
        crystalCounter.text = crystalCounterStr;

        if(numSlayedCrystals >= numTotalCrystals)
        {
            GameController.instance.EndGame();
        }
    }

}
