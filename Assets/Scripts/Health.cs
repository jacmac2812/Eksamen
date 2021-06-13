using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public event Action OnDeath;
    [SerializeField] private BadCrystalController m_badCrystal;
    public int health;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    // Start is called before the first frame update

    private void Awake()
    {
        if (m_badCrystal != null)
        {
            m_badCrystal.OnHit += OnHit;
        }
    }

    void Start()
    {
        numOfHearts = 5;
        health = 5;
    }

    void Update()
    {
        if(health <= 0)
        {
            OnDeath?.Invoke();
        }
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }


            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
    private void OnHit()
    {
        health--;
    }
}
