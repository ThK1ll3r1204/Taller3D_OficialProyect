using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeUI : MonoBehaviour
{
    public int health;
    public int Nhearts;
    [SerializeField] PlayerLife playerLife;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;


    private void Start()
    {
        playerLife = GetComponent<PlayerLife>();
    }
    void Update()
    {
        if(playerLife.currentLife > playerLife.maxLife)
        {
            playerLife.currentLife = playerLife.maxLife;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < playerLife.currentLife)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if(i<playerLife.maxLife)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
    
    
}