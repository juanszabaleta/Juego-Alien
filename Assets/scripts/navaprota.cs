using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class navaprota : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] GameObject bala;
    [SerializeField] float fireRate;
    float minX;
    float maxX;
    float minY;
    float maxY;
    float contador;
    float nextFire = 0;




    // Start is called before the first frame update
    void Start()
    {
        Vector2 esquinasupDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 esquinainfIzq = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        maxX = esquinasupDer.x - 0.6f;
        maxY = esquinasupDer.y - 0.6f;
        minX = esquinainfIzq.x + 0.6f;
        Vector2 puntoX = Camera.main.ViewportToWorldPoint(new Vector2(0, 0.7f));
        minY = puntoX.y;
    }

    // Update is called once per frame
    void Update()
    {
        mover();

        disparar();

        void mover()

        {
            float dirH = Input.GetAxis("Horizontal");
            float dirV = Input.GetAxis("Vertical");

            Vector2 movimiento = new Vector2(dirH * Time.deltaTime * speed, dirV * Time.deltaTime * speed);
            transform.Translate(movimiento);

            if (transform.position.x > maxX)
                transform.position = new Vector2(maxX, transform.position.y);

            if (transform.position.x < minX)
                transform.position = new Vector2(minX, transform.position.y);

            if (transform.position.y > maxY)
                transform.position = new Vector2(transform.position.x, maxY);

            if (transform.position.y < minY)
            {
                transform.position = new Vector2(transform.position.x, minY);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(bala);
            }
        }

        void disparar()
        {
            if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextFire)
            {
                Instantiate(bala, transform.position - new Vector3(0, 1, 0), transform.rotation);
                nextFire = Time.time + fireRate;
            }
        }

    }
}
