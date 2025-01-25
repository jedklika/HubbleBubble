using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] float carryCap;
    [SerializeField] float itemsCarried;
    [SerializeField] float speed;
    [SerializeField] float durability;

    [SerializeField] int lives;
    [SerializeField] float lifeTime;

    [SerializeField] int plasticAmount;
    [SerializeField] int metalAmount;
    [SerializeField] int glassAmount;

    public float CarryCap 
    {
        get { return carryCap; }
    }
    public float ItemsCarried
    {
        get { return itemsCarried; }
    }
    public float Speed
    {
        get { return speed; }
    }
    public float Durability
    {
        get { return durability; }
    }

    public int Lives
    {
        get { return lives; }
    }
    public float LifeTime 
    {
        get { return lifeTime; }
    }

    public int PlasticAmount 
    { 
        get { return plasticAmount; }   
    }
    public int MetalAmount
    {
        get { return metalAmount; }
    }
    public int GlassAmount
    {
        get { return glassAmount; }
    }
}
