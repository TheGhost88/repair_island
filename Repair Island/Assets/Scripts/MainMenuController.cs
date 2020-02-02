using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{

    Camera cam;
    Coroutine routine = null;
    // Start is called before the first frame update
    void Start()
    {
        cam = this.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(routine == null)
        {
            this.transform.position = new Vector3(Random.Range(-55,55), Random.Range(-10,60),-7);
            routine = StartCoroutine(PanArea());
        }
    }

    IEnumerator PanArea()
    {
        float timer = 5f;
        Vector3 origSpot = this.transform.position;
        Vector3 newSpot = this.transform.position + new Vector3(5, 0, 0);
        while(timer > 0)
        {
            this.transform.position = Vector3.Lerp(origSpot, newSpot, (5 - timer) / 5);
            timer -= Time.deltaTime;
            yield return null;
        }
        routine = null;
    }

    public void LoadGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
