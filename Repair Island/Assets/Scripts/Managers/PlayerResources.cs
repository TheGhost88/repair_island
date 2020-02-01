using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Holds player resources, inventory, etc...
/// </summary>
public class PlayerResources : MonoBehaviour
{
    public static PlayerResources Instance = null;

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
