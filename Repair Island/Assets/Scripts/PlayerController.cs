using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController ThePlayer = null;

    [Header("Player Status")]
    public int health;
    public int stamina;
    public int thirst;
    public int hunger;
    public enum PlayerStatus { Health, Stamina, Thirst, Hunger }

    public List<Interactable> nearByInteractables = new List<Interactable>();

    private void Awake()
    {
        if (ThePlayer == null)
        {
            ThePlayer = this;
            ThePlayer.Init();
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
        health = 100;
        stamina = 100;
        thirst = 100;
        hunger = 100;
    }

    private void OnTriggerEnter2D(Collider other)
    {
        var item = other.GetComponent<Interactable>();
        if (item)
            nearByInteractables.Add(item);
    }

    private void OnTriggerExit2D(Collider other)
    {
        var item = other.GetComponent<Interactable>();
        if (item)
            nearByInteractables.Remove(item);
    }

    void SortInteractables()
    {
        nearByInteractables.Sort((x, y) => x.GetDistanceFromPlayer(this.transform).CompareTo(y.GetDistanceFromPlayer(this.transform)));
    }

    public void InteractWithObject()
    {
        nearByInteractables[0].Interact(/*Not from josh to include the equiped item here */);
    }

    public void ChangePlayerStatus(PlayerStatus stat, int value)
    {
        switch(stat)
        {
            case PlayerStatus.Health:
                health += value;
                break;
            case PlayerStatus.Stamina:
                stamina += value;
                break;
            case PlayerStatus.Thirst:
                thirst += value;
                break;
            case PlayerStatus.Hunger:
                hunger += value;
                break;
        }
    }
}
