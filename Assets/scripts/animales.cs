using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animales : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] bool movingRight;
    float minX, maxX;
    void Start()
    {
        Vector2 esquinainfDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 0));
        Vector2 esquinainfIzq = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        maxX = esquinainfDer.x;
        minX = esquinainfIzq.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (movingRight)
        {
            transform.Translate(new Vector2(speed * Time.deltaTime, 0), Space.World);
        }
        else
            transform.Translate(new Vector2(speed * Time.deltaTime, 0), Space.World);
        if (transform.position.x > maxX)
        {
            movingRight = false;
        }
        else if (transform.position.x < minX)
        {
            movingRight = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject colisionando = collision.gameObject;

        if (colisionando.tag == "disparo")
        {
            Destroy(this.gameObject);
        }


    }
}
