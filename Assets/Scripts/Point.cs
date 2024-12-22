using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    [SerializeField] int id = 0;
    [SerializeField] Color touchingColor = Color.white;
    [SerializeField] Point otherPoint;
    Color initialColor;
    SpriteRenderer spriteRenderer;

    bool isTouchingPlayer = false;

    float xRange = 8, yRange = 4;



    private void Start()
    {
        spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        initialColor = spriteRenderer.color;

        Teleport();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (id == collision.GetComponent<PlayerMovement>().id)
        {
            spriteRenderer.color = touchingColor;
            isTouchingPlayer = true;

            if (otherPoint.isTouchingPlayer)
            {
                Teleport();
                otherPoint.Teleport();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (id == collision.GetComponent<PlayerMovement>().id)
        {
            spriteRenderer.color = initialColor;
            isTouchingPlayer = false;
        }
    }


    void Teleport()
    {
        transform.position = new Vector3(
            Random.Range(-xRange, xRange),
            Random.Range(-yRange, yRange),
            0
        );
    }
}
