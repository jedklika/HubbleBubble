using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] float maxCarryCap;
    [SerializeField] int itemsCarried;
    [SerializeField] float speed;
    [SerializeField] float maxSpeed;
    [SerializeField] float mimSpeed;
    [SerializeField] bool isFull;

    [SerializeField] int durability;
    [SerializeField] int lives;
    [SerializeField] float lifeTime;

    [SerializeField] int plasticAmount;
    [SerializeField] int metalAmount;
    [SerializeField] int glassAmount;
    [SerializeField] int maxPlasticAmount;
    [SerializeField] int maxMetalAmount;
    [SerializeField] int maxGlassAmount;

    [SerializeField] float glassMaxCarryBuff;
    [SerializeField] float glassSpeedDebuff;

    [SerializeField] float metalMaxCarryCap;
    [SerializeField] float metalSpeedDeBuff;

    [SerializeField] float plasticMaxCarryCap;
    [SerializeField] float plasticSpeedBuff;

    [SerializeField] string bubbleType;
    [SerializeField] bool assigned;

    [SerializeField] Transform respawnPoint;
    [SerializeField] Transform player;

    [SerializeField] List<GameObject> inPlayer = new List<GameObject>();
    [SerializeField] bool hasWon;
    [SerializeField] float maxTime;

    UI um;
 
    public float MaxCarryCap
    {
        get { return maxCarryCap; }
        set { maxCarryCap = value; }
    }
    public int ItemsCarried
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
    public int Durability
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
    public int MaxPlasticAmount
    {
        get { return maxPlasticAmount; }
        set { maxPlasticAmount = value; }
    }
    public int MetalAmount
    {
        get { return metalAmount; }
        set { metalAmount = value; }
    }
    public int MaxMetalAmount
    {
        get { return maxMetalAmount; }
        set { maxMetalAmount = value; }
    }
    public int GlassAmount
    {
        get { return glassAmount; }
        set { glassAmount = value; }
    }
    public int MaxGlassAmount
    {
        get { return maxGlassAmount; }
        set { maxGlassAmount = value; }
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

    public bool Full 
    { 
        get { return isFull; }

        set { isFull = value; }
    }

    public float GlassMaxCarryBuff 
    { 
        get { return glassMaxCarryBuff; }

        set { glassMaxCarryBuff = value; }
    }

    public float MetalMaxCarryCap 
    { 
        get { return metalMaxCarryCap; }

        set { metalMaxCarryCap = value; }
    }

    public float PlasticMaxCarryCap 
    { 
        get { return plasticMaxCarryCap; }

        set { plasticMaxCarryCap = value; }
    }
    public float GlassSpeedDebuff
    {
        get { return glassSpeedDebuff; }

        set { glassSpeedDebuff = value; }
    }

    public float MetalSpeedDeBuff
    {
        get { return metalSpeedDeBuff; }

        set { metalSpeedDeBuff = value; }
    }

    public float PlasticSpeedBuff
    {
        get { return plasticSpeedBuff; }

        set { plasticSpeedBuff = value; }
    }

    public List <GameObject> InPlayer 
    { 
        get { return inPlayer; }

        set { inPlayer = value; }
    }

    public bool Won 
    { 
        get { return hasWon; }

        set { hasWon = value; }
    }

    private void Start()
    {
        um = FindObjectOfType<UI>();
        respawnPoint = GameObject.Find("Respawn Point").transform;
        player = GameObject.Find("Player").transform;
        StartCoroutine(deathTimer());
       
    }
    private void Update()
    {
        switch (bubbleType) 
        { 
            case "Glass":
                maxCarryCap = glassMaxCarryBuff;
                um.GlassActive();
                    break;
            case "Metal":
                maxCarryCap = metalMaxCarryCap;
                um.MetalActive();
                break;
            case "Plastic":
                maxCarryCap = plasticMaxCarryCap;
                um.PlasticActive();
                break;
            default:
                um.CarriedItems.text = "0 /";
                um.BubbleType.color = Color.white;
                um.MaxCarryCap.text = "0";
                break;
        }
        if (durability <= 0) 
        {
            Respawn();
        }
        if(lives <= 0 && !hasWon) 
        {
            Die();
        }

        if(speed >= maxSpeed) 
        {
            speed = maxSpeed;
        }
        else if (speed <= mimSpeed)
        {
            speed = mimSpeed;
        }
        if(glassAmount == maxGlassAmount && metalAmount == maxMetalAmount && plasticAmount == maxPlasticAmount) 
        {
            Debug.Log("Win");
            hasWon = true;
        }
    }
     public void Respawn() 
    {
        StopAllCoroutines();
        durability = 1;
        bubbleType = null;
        isFull = false;
        player.position = respawnPoint.position;
        lives--;
        speed = 10;
        itemsCarried = 0;
        maxCarryCap = 1;
        assigned = false;
        StartCoroutine(deathTimer());
        Debug.Log("Respawned");
    }
    public void Die() 
    {
        Debug.Log("Die");
        SceneManager.LoadScene(0);
    }
    IEnumerator deathTimer() 
    {
        while (true)
        {
            
            yield return new WaitForSeconds(lifeTime);
            Respawn();
        }
    }
    public void AddPlastic()
    {
        plasticAmount = plasticAmount + itemsCarried;
    }

    public void AddMetal()
    {
        metalAmount = metalAmount + itemsCarried;
    }

    public void AddGlass()
    {
        glassAmount = glassAmount + itemsCarried;
    }
}
