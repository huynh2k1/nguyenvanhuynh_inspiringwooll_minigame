using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ball : MonoBehaviour
{
    public CircleCollider2D circleCol;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rb;

    public int force = 5;
    public int health;
    public int score;
    bool jump = false;
    float _timeDie;
    bool startCowndown;

    public void Init()
    {
        score = 0;
        health = 2;
        startCowndown = false;
        rb.bodyType = RigidbodyType2D.Static;
        CanvasGame.instance.UpdateIconHealth(health);
        CanvasGame.instance.UpdateScoreText(score);
    }

    public void SetParentOfBall(Transform parent)
    {
        transform.SetParent(parent, true);
    }

    private void Update()
    {
        if (GameController.instance.state == StateGame.End)
            return;

        if(Input.GetMouseButtonDown(0) && jump == false && GameController.instance.state == StateGame.Playing)
        {
            jump = true;
            SetOrderLayout(5);
            JumpBall();
            ResetTime();
        }
        if (rb.velocity.y < 0.0f)
        {
            circleCol.enabled = true;
            return;
        }
        if(_timeDie <= 0 && startCowndown)
        {
            startCowndown = false;
            GameController.instance.GameOver();
            Basket.curBasket.TornBasket();
            FallingBall();
            return;
        }
        else if(_timeDie > 0 && jump == false && startCowndown)
        {
            _timeDie -= Time.deltaTime;
            CanvasGame.instance.UpdateTimeText((int)_timeDie);
        }
    }
    public void ResetBall()
    {
        rb.bodyType = RigidbodyType2D.Static;
        //transform.SetParent(Basket.curBasket.transform, true);
        SetOrderLayout(2);
        SetParentOfBall(Basket.curBasket.transform);
        transform.localPosition = Vector2.zero;
        circleCol.enabled = true;
        jump = false;
    }

    private void JumpBall()
    {
        transform.SetParent(null);
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.AddForce(new Vector2(0, force), ForceMode2D.Impulse);
        circleCol.enabled = false;
    }

    public void ResetTime()
    {
        _timeDie = GameController.instance.timeDie;
        CanvasGame.instance.UpdateTimeText((int)_timeDie);
    }

    public void FallingBall()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    public void UpdateHealth()
    {
        health -= 1;

        if (health < 0)
        {
            CanvasGame.instance.UpdateIconHealth(health);
            PopupController.instance.UpdateLosePopup(score);
            GameController.instance.GameOver();
            return;
        }
        else
        {
            CanvasGame.instance.UpdateIconHealth(health);
        }
    }

    public void UpdateScore()
    {
        score += 1;
        CanvasGame.instance.UpdateScoreText(score);
    }

    public void SetOrderLayout(int newSortingOrder)
    {
        if (spriteRenderer != null)
        {
            GetComponent<Renderer>().sortingOrder = newSortingOrder;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Basket")
        {
            if (!jump)
            {
                Basket.curBasket = collision.GetComponent<Basket>();
                Basket.curBasket.hasBall = true;
            }
            else
            {
                if(transform.position.y > collision.transform.position.y)
                {
                    rb.bodyType = RigidbodyType2D.Static;
                    rb.velocity = Vector2.zero;
                    transform.SetParent(collision.transform, true);
                    SetOrderLayout(2);
                    transform.localPosition = Vector2.zero;
                    if (collision.GetComponent<Basket>().hasBall == false)
                    {
                        UpdateScore();
                        Basket.curBasket = collision.GetComponent<Basket>();
                        Basket.curBasket.hasBall = true;
                        SpawnController.instance.SpawnBasket(transform.position.y + 8f);
                        SpawnController.instance.SetBasketTypeNone(Basket.curTypeBasketDestroy);
                    }
                    else
                    {
                        UpdateHealth();
                        ResetBall();
                    }
                    ResetTime();
                    startCowndown = true;
                    jump = false;
                }
            }
        }

        if(collision.tag == "DeadArea")
        {
            UpdateHealth();
            ResetBall();
        }
    }
}
