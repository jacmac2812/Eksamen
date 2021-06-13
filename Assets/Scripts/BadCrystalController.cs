using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadCrystalController : MonoBehaviour
{
    public event Action OnHit;

    int sizeOfList;
    private GameObject crystal;

    public GameObject badCrystalContainer;
    private List<GameObject> badCrystals = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in badCrystalContainer.transform)
        {
            if (child != null)
            {
                badCrystals.Add(child.gameObject);
            }
        }
        sizeOfList = badCrystals.Count;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < sizeOfList; i++)
        {
            crystal = badCrystals[i];

            if (crystal.active == false)
            {
                OnHit?.Invoke();
                badCrystals.Remove(crystal);
                sizeOfList--;
            }
        }
    }


}
