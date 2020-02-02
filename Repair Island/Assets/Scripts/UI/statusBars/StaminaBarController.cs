using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBarController : MonoBehaviour
{
    private Slider staminaBar;
    private int currentSTM = 100;


    // Start is called before the first frame update
    void Awake()
    {
        staminaBar = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        staminaBar.value = currentSTM;
    }

    public void changeHP(int dSTM)
    {
        currentSTM += dSTM;
    }
}
