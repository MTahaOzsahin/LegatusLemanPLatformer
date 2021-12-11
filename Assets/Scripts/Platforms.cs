using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Vector3 ReturnEndPoint()
    {
        Vector3 calculatedEndPoint;
        calculatedEndPoint.x = spriteRenderer.bounds.size.x + this.transform.position.x
            + Random.Range(0f, 3f);

        calculatedEndPoint.y = Random.Range(0f,3f);
        calculatedEndPoint.z = 0;



        return calculatedEndPoint;
    }
    /*  daha sonra bak
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<CharacterMovementContoller>().runningspeed += 5;
            collision.gameObject.GetComponent<CharacterMovementContoller>().walkingspeed += 5;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PLayer"))
        {
            collision.gameObject.GetComponent<CharacterMovementContoller>().runningspeed -= 5;
            collision.gameObject.GetComponent<CharacterMovementContoller>().walkingspeed -= 5;
        }
    }
    */
}
