using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private GameController gc;
    private Rigidbody2D rBody;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gco = GameObject.FindWithTag("GameController");
        gc = gco.GetComponent<GameController>();
        rBody = GetComponent<Rigidbody2D>();
        rBody.velocity = transform.right * speed;

    }
}
