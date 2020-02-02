using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerBarController : MonoBehaviour
{
    private Slider hungerBar;
    private int currentHGR = 100;

    // Start is called before the first frame update
    void Awake()
    {
        hungerBar = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        hungerBar.value = PlayerController.ThePlayer.hunger;
    }
}
