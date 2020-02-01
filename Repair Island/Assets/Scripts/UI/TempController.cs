﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempController : MonoBehaviour
{
     Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("clicked");
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100))
            {
                ItemPickup itemPickup = hit.collider.GetComponent<ItemPickup>();
                if (hit.collider.GetComponent<ItemPickup>())
                {
                    hit.collider.GetComponent<ItemPickup>().Interact();
                }
            }
        }
    }
}
