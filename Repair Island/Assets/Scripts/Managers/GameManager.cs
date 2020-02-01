﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the state of the game, one stop shop for world data, player resources, enemies, etc...
/// </summary>
public class GameManager : MonoBehaviour
{

    public static GameManager Instance = null;
    public WorldCondition worldStatus;
    public PlayerResources playerResource;
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Instance.Init();
        }
        else
        {
            DestroyImmediate(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void Init()
    {
        
    }
}
