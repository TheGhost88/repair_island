using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    private Slider healthBar;
    private int currentHP = 100;


    // Start is called before the first frame update
    void Awake()
    {
        healthBar = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = currentHP;
    }

    public void changeHP(int dHP)
    {
        currentHP += dHP;
    }
}

/*
 
     void Awake()
     {

        healthBar = GameObject.Find("Health Bar").GetComponent<HealthBarController>(); //call the gameobject's name 

     }

    void Update()
    {

     if(Input.GetKey(KeyCode.UpArrow))
     {
        healthBar.changeHP(1); //example on affecting the health bar
     }
      if(Input.GetKey(KeyCode.DownArrow))
     {
        healthBar.changeHP(-1);
     }

    }
     
     
     
     */
