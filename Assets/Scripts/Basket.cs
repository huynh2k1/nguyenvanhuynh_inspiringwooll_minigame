using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Basket : MonoBehaviour
{
    public static Transform curPosBasket;
    public static Basket curBasket;
    public GameObject normalBasket;
    public GameObject tornBasket;

    public static TypeBasket curTypeBasketDestroy;
    public TypeBasket typeBasket;

    public float currentPosition;
    public float speed; 
    public float boundary; 
    public bool hasBall = false;
    Vector3 _direction;


    public void SwitchTypeBasket(TypeBasket type)
    {
        GetBoundCamera();
        switch (type)
        {
            case TypeBasket.moveright:
                _direction = Vector3.right;
                break;
            case TypeBasket.moveleft:
                _direction = Vector3.left;
                break;
            case TypeBasket.idle:
                break;
            case TypeBasket.none:
                break;

        }
    }

    private void Update()
    {
        if (typeBasket != TypeBasket.none && typeBasket != TypeBasket.idle)
        {
            Move();
        }
    }

    public void GetBoundCamera()
    {
        boundary = CameraController.instance.boundRight - 0.5f;
    }
    public void Move()
    {
        if (transform.position.x > boundary || transform.position.x < -boundary)
        {
            speed = -speed;
        }
        transform.Translate(_direction * speed * Time.deltaTime);
    }
    public void TornBasket()
    {
        normalBasket.SetActive(false);
        tornBasket.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "DeadArea")
        {
            curTypeBasketDestroy = typeBasket;
            Destroy(gameObject);
        }
    }

}
public enum TypeBasket
{
    moveleft,
    moveright,
    idle,
    none
}
