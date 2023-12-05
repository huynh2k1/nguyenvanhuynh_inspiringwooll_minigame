using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public static SpawnController instance;
    public List<Basket> listBasket;
    public List<TypeBasket> listType;
    public Basket basketPrefab;
    public Basket basketStart;
    public Ball ballPrefab;
    public float posSpawn;
    Basket _basketStart;
    public List<Basket> _listShuffed = new List<Basket>();

    private void Awake()
    {
        instance = this;
        posSpawn = 0;
        InitListType();
    }
    public void InitListType()
    {
        listType = new List<TypeBasket>();
        listType.Add(TypeBasket.idle);
        listType.Add(TypeBasket.moveleft);
        listType.Add (TypeBasket.moveright);
    }
    public void SpawnBasket(float posY)
    {
        //float posY = ball.transform.position.y + 10;
        Basket basket = Instantiate(basketPrefab,new Vector3(0, posY, 0), Quaternion.identity);
        listBasket.Add(basket);
    }
    public void SpawnBasketStart()
    {
        _basketStart = Instantiate(basketStart, new Vector3(0, 0, 0), Quaternion.identity);
        listBasket.Add(_basketStart);
    }
    public void SpawnBall()
    {
        Ball ball = Instantiate(ballPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        ball.Init();
        ball.SetParentOfBall(_basketStart.transform);
        CameraFollow.instance.ball = ball.transform;
    }
    public void Init()
    {
        SpawnBasketStart();
        SpawnBasket(posSpawn + 4f);
        SpawnBasket(posSpawn + 8f);

        SpawnBall();

        GenerateTypeBasketInList();
    }

    int idType;
    int idBasket;
    public void ShufferListBasket()
    {
        if(listBasket.Count > 0)
        {
            idType = Random.Range(0, listType.Count - 1);
            idBasket = Random.Range(0, listBasket.Count - 1);

            listBasket[idBasket].typeBasket = listType[idType];
            _listShuffed.Add(listBasket[idBasket]);
            listBasket.RemoveAt(idBasket);
            listType.RemoveAt(idType);
            ShufferListBasket();
        }
           
    }
    public void GenerateTypeBasketInList()
    {
        ShufferListBasket();
        for(int i = 0; i < _listShuffed.Count; i++)
        {
            _listShuffed[i].SwitchTypeBasket(_listShuffed[i].typeBasket);
        }
    }
    public void SetBasketTypeNone(TypeBasket type)
    {
        for(int i = 0; i < listBasket.Count; i++)
        {
            if (listBasket[i].typeBasket == TypeBasket.none)
            {
                listBasket[i].typeBasket = type;
                listBasket[i].SwitchTypeBasket(type);
                _listShuffed.Add(listBasket[i]);  
                listBasket.RemoveAt(i);
            }
        }
    }
}
