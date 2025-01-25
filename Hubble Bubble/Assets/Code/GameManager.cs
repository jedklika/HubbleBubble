using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] float maxCarryCap;
    [SerializeField] float itemsCarried;
    [SerializeField] float speed;
    [SerializeField] float maxSpeed;
    [SerializeField] float mimSpeed;
    [SerializeField] float durability;
    [SerializeField] bool isFull;

    [SerializeField] int lives;
    [SerializeField] float lifeTime;

    [SerializeField] int plasticAmount;
    [SerializeField] int metalAmount;
    [SerializeField] int glassAmount;

    [SerializeField] float glassMaxCarryBuff;
    [SerializeField] float glassSpeedDebuff;

    [SerializeField] float metalMaxCarryCap;
    [SerializeField] float metalSpeedDeBuff;

    [SerializeField] float plasticMaxCarryCap;
    [SerializeField] float plasticSpeedBuff;

    [SerializeField] string bubbleType;
    [SerializeField] bool assigned;
 
    public float MaxCarryCap
    {
        get { return maxCarryCap; }
        set { maxCarryCap = value; }
    }
    public float ItemsCarried
    {
        get { return itemsCarried; }
        set { itemsCarried = value; }
    }
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }
    public float MaxSpeed
    {
        get { return maxSpeed; }
        set { MaxSpeed = value; }
    }
    public float MimSpeed
    {
        get { return mimSpeed; }
        set { mimSpeed = value; }
    }
    public float Durability
    {
        get { return durability; }
        set { durability = value; }
    }

    public int Lives
    {
        get { return lives; }
        set { lives = value; }
    }
    public float LifeTime 
    {
        get { return lifeTime; }
        set { lifeTime = value; }
    }

    public int PlasticAmount 
    { 
        get { return plasticAmount; } 
        set { plasticAmount = value; }
    }
    public int MetalAmount
    {
        get { return metalAmount; }
        set { metalAmount = value; }
    }
    public int GlassAmount
    {
        get { return glassAmount; }
        set { glassAmount = value; }
    }

    public string BubbleType 
    { 
        get { return bubbleType; }
        set { bubbleType = value; }
    }

    public bool Assigned 
    { 
        get { return assigned; }

        set { assigned = value; }
    }

    private void Update()
    {
        switch (bubbleType) 
        { 
            case "Glass":
                durability = 1;
                maxCarryCap = glassMaxCarryBuff;
                    break;
            case "Metal":
                durability = 2;
                maxCarryCap = metalMaxCarryCap;
                break;
            case "Plastic":
                durability = 1;
                maxCarryCap = plasticMaxCarryCap;
                break;
            default:
                break;
        }
    }

}
