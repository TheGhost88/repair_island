using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

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

    [Header("Tile Replacement")]
    public AnimatedTile ReplacementTileAnimated;
    Tile ReplacementTile;
    public Sprite ReplacementSprite;
    Tilemap tilemap;

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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InteractWithObject();
        }
    }

    private void Init()
    {
        health = 100;
        stamina = 100;
        thirst = 100;
        hunger = 100;

        ReplacementTile = ScriptableObject.CreateInstance<Tile>();
        ReplacementTile.sprite = ReplacementSprite;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var item = other.GetComponent<Interactable>();
        if (item)
            nearByInteractables.Add(item);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var item = collision.collider.GetComponent<ItemPickup>();
        if (item)
        {
            nearByInteractables.Add(item);
            if (collision.collider.gameObject.GetComponent<Tilemap>())
            {              
                
                tilemap = collision.collider.gameObject.GetComponent<Tilemap>();
                
                Debug.Log("Found Tilemap " + tilemap.name);

                //tilemap.RefreshAllTiles();
                
            }

        }


    }

    IEnumerator TreeFalling(Tilemap tilemap, Vector3Int tilePos)
    {
        yield return new WaitForSeconds(0.5f);
        tilemap.SetTile(tilePos, ReplacementTile);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        var item = collision.collider.GetComponent<Interactable>();
        if (item)
            nearByInteractables.Remove(item);
    }

    private void OnTriggerExit2D(Collider2D other)
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
        if (nearByInteractables[0])
        {
            
            Vector3Int tilePos = tilemap.layoutGrid.WorldToCell(this.gameObject.transform.position);

            if (tilemap.GetSprite(tilePos) == ReplacementSprite)
            {
                return;
            }

            tilemap.SetTile(tilePos, ReplacementTileAnimated);
            StartCoroutine(TreeFalling(tilemap, tilePos));
            nearByInteractables[0].Interact(/*Not from josh to include the equiped item here */);
        }
        else
        {
            nearByInteractables.RemoveAt(0);
        }
       
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
