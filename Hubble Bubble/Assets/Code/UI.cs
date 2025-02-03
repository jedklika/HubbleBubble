using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] TextMeshProUGUI glassAmout;
    [SerializeField] TextMeshProUGUI maxGlassAmout;
    [SerializeField] TextMeshProUGUI metalAmout;
    [SerializeField] TextMeshProUGUI maxMetalAmout;
    [SerializeField] TextMeshProUGUI plasticAmout;
    [SerializeField] TextMeshProUGUI maxPlasticAmout;

    [Header("Bubble Type Info")]
    [SerializeField] Image bubbleType;
    [SerializeField] TextMeshProUGUI carriedItems;
    [SerializeField] TextMeshProUGUI maxCarryCap;

    [Header("Health")]
    [SerializeField] RawImage[] health;

    [Header("Slider")]
    [SerializeField] Slider timer;

    GameManager gm;

    public TextMeshProUGUI GlassAmount
    {
        get { return glassAmout; }

        set { glassAmout = value; }
    }
    public TextMeshProUGUI MaxGlassAmount
    {
        get { return maxGlassAmout; }

        set { maxGlassAmout = value; }
    }
    public TextMeshProUGUI MetalAmount
    {
        get { return glassAmout; }

        set { glassAmout = value; }
    }
    public TextMeshProUGUI MaxMetalAmount
    {
        get { return maxMetalAmout; }

        set { maxMetalAmout = value; }
    }
    public TextMeshProUGUI PlasticAmount
    {
        get { return plasticAmout; }

        set { plasticAmout = value; }
    }
    public TextMeshProUGUI MaxPlasticAmount
    {
        get { return maxPlasticAmout; }

        set { maxPlasticAmout = value; }
    }

    public Image BubbleType
    {
        get { return bubbleType; }

        set { bubbleType = value; }
    }
    public TextMeshProUGUI CarriedItems
    {
        get { return carriedItems; }

        set { carriedItems = value; }
    }
    public TextMeshProUGUI MaxCarryCap
    {
        get { return maxCarryCap; }

        set { maxCarryCap = value; }
    }

    public RawImage[] Health
    {
        get { return health; }

        set { health = value; }
    }

    public Slider Timer
    {
        get { return timer; }

        set { timer = value; }
    }


    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        maxGlassAmout.text = "/ " + gm.MaxGlassAmount.ToString();
        maxMetalAmout.text = "/ " + gm.MaxMetalAmount.ToString();
        maxPlasticAmout.text = "/ " + gm.MaxPlasticAmount.ToString();
        glassAmout.text = "0";
        metalAmout.text = "0";
        plasticAmout.text = "0";
        timer.maxValue = gm.LifeTime;
        timer.value = gm.LifeCurrTime;

    }

    private void Update()
    {
        timer.value = gm.LifeCurrTime;
    }

    public void GlassActive()
    {
        bubbleType.color = Color.green;
        maxCarryCap.text = gm.GlassMaxCarryBuff.ToString();
    }
    public void MetalActive()
    {
        bubbleType.color = Color.red;
        maxCarryCap.text = gm.MetalMaxCarryCap.ToString();
    }
    public void PlasticActive()
    {
        bubbleType.color = Color.blue;
        maxCarryCap.text = gm.PlasticMaxCarryCap.ToString();
    }

    public void AddCarryItems()
    {
        gm.ItemsCarried++;
        carriedItems.text = gm.ItemsCarried.ToString() + " / ";
    }

    public void DisposeGlass()
    {
        int combinedTotal;
        combinedTotal = gm.GlassAmount + gm.ItemsCarried;
        glassAmout.text = combinedTotal.ToString();
    }
    public void DisposeMetal()
    {
        int combinedTotal;
        combinedTotal = gm.MetalAmount + gm.ItemsCarried;
        metalAmout.text = combinedTotal.ToString();
    }
    public void DisposePlastic()
    {
        int combinedTotal;
        combinedTotal = gm.PlasticAmount + gm.ItemsCarried;
        plasticAmout.text = combinedTotal.ToString();
    }

    public void UpadeHealthUI()
    {
        for (int i = 0; i < Health.Length; i++)
        {
            if (i < gm.Lives)
            {
                Health[i].enabled = true;
            }
            else
            {
                health[i].enabled = false;
            }

        }
    }
}
