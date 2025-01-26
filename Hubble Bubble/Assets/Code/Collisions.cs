using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    GameManager gm;
    public int hits;
    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        if(gm.ItemsCarried >= gm.GlassMaxCarryBuff && gm.BubbleType == "Glass" || gm.ItemsCarried >= gm.MetalMaxCarryCap && gm.BubbleType == "Metal" || gm.ItemsCarried >= gm.PlasticMaxCarryCap && gm.BubbleType == "Plastic") 
        {
            gm.Full = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Glass" && !gm.Assigned) 
        {
            gm.ItemsCarried++;
            gm.Speed = gm.Speed - gm.GlassSpeedDebuff;
            gm.BubbleType = "Glass";
            gm.Assigned = true;
            Destroy(other.gameObject);
        }
        else if (other.tag == "Glass" && gm.BubbleType == "Glass" && !gm.Full)
        {
            gm.Speed = gm.Speed - gm.GlassSpeedDebuff;
            gm.BubbleType = "Glass";
            gm.Assigned = true;
            gm.ItemsCarried++;
            Destroy(other.gameObject);
        }
        else if ( gm.BubbleType == "Glass" && other.tag == "Dump")
        {
            gm.AddGlass();
            gm.Durability--;
        }
        else if(gm.BubbleType == "Glass" && other.tag != "Glass" && other.tag != "Dump") 
        {
            Debug.Log("Die");
            gm.Durability--;
            
        }
        else if (other.tag == "Metal" && !gm.Assigned)
        {
            gm.ItemsCarried++;
            gm.Lives = gm.Lives + 1;
            gm.Speed = gm.Speed - gm.MetalSpeedDeBuff;
            gm.BubbleType = "Metal";
            gm.Assigned = true;
            Destroy(other.gameObject);
        }
        else if (other.tag == "Metal" && gm.BubbleType == "Metal" && !gm.Full)
        {
            gm.Speed = gm.Speed - gm.MetalSpeedDeBuff;
            gm.BubbleType = "Metal";
            gm.Assigned = true;
            gm.ItemsCarried++;
            Destroy(other.gameObject);
        }
        else if (gm.BubbleType == "Metal" && other.tag == "Dump")
        {
            gm.AddMetal();
            gm.Respawn();
        }
        else if (gm.BubbleType == "Metal" && other.tag != "Metal")
        {
            Debug.Log("Die2");
            gm.Durability--;
            
        }
        else if (other.tag == "Plastic" && !gm.Assigned)
        {
            gm.ItemsCarried++;
            gm.Speed = gm.Speed + gm.PlasticSpeedBuff;
            gm.BubbleType = "Plastic";
            gm.Assigned = true;
            Destroy(other.gameObject);
        }
        else if (other.tag == "Plastic" && gm.BubbleType == "Plastic" && !gm.Full)
        {
            gm.BubbleType = "Plastic";
            gm.Speed = gm.Speed + gm.PlasticSpeedBuff;
            gm.Assigned = true;
            gm.ItemsCarried++;
            Destroy(other.gameObject);
        }
        else if (gm.BubbleType == "Plastic" && other.tag == "Dump")
        {
            gm.AddPlastic();
            gm.Durability--;
        }
        else if (gm.BubbleType == "Plastic" && other.tag != "Plastic")
        {
            Debug.Log("Die3");
            gm.Durability--;
            
        }
        else if (gm.Full)
        {
            Debug.Log("Die4");
            gm.Durability--;
           
        }

    }
}
