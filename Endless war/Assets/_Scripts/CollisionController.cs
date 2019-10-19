using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public GameController gc;
    public GameObject bonus;
    
    private AudioSource explosionSound;

    void Start()
    {
        GameObject gameControllerObject = GameObject.Find("GameController");
        if (gameControllerObject == null)
        {
            Debug.Log("Can't find Game Controller");
        }
        gc = gameControllerObject.GetComponent<GameController>();
        explosionSound = gc.audioSources[(int)SoundClip.EXPLOSION];
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (this.gameObject.tag == "Player")
        {
            if (col.gameObject.tag == "Enemy1" || col.gameObject.tag == "Enemy2")
            {
                gc.Lives -= 1;
                Debug.Log("Life decreased: " + gc.Lives);
                Destroy(col.gameObject);
                if (gc.Lives == 0)
                {
                    Destroy(this.gameObject);
                    gc.GameOver();
                }
            }
        }
        
        else if (this.gameObject.tag == "Bullet")
        {
            if (col.gameObject.tag == "Enemy1")
            {
                Destroy(this.gameObject);
                Destroy(col.gameObject);
                gc.Score += 50;
                explosionSound.volume = 0.3f;
                explosionSound.Play();
            }
            if (col.gameObject.tag == "Enemy2")
            {
                Vector3 position = this.gameObject.transform.position;
                Destroy(this.gameObject);
                Destroy(col.gameObject);
                gc.Score += 100;
                explosionSound.volume = 0.3f;
                explosionSound.Play();
                int itemChance = Random.Range(0, 101);
                if (itemChance >= 0 && itemChance <= 5)
                {
                    Instantiate(bonus, position, Quaternion.identity);
                }
            }
        }
    }
}
