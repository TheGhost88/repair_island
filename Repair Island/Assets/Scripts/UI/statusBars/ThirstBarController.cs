using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThirstBarController : MonoBehaviour
{
    private Slider thirstBar;
    private int currentTRS = 100;


    // Start is called before the first frame update
    void Awake()
    {
        thirstBar = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        thirstBar.value = PlayerController.ThePlayer.thirst;
    }
}
