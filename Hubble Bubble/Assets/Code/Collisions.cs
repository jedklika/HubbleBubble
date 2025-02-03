using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Collisions : MonoBehaviour
{
    GameManager gm;
    UI um;

    public int hits;
    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        um = FindObjectOfType<UI>();
    }
    private void Update()
    {
        if (gm.ItemsCarried >= gm.GlassMaxCarryBuff && gm.BubbleType == "Glass" || gm.ItemsCarried >= gm.MetalMaxCarryCap && gm.BubbleType == "Metal" || gm.ItemsCarried >= gm.PlasticMaxCarryCap && gm.BubbleType == "Plastic")
        {
            gm.Full = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Glass" && !gm.Assigned)
        {

            um.AddCarryItems();
            gm.InPlayer.Add(other.gameObject);
            gm.Speed = gm.Speed - gm.GlassSpeedDebuff;
            gm.BubbleType = "Glass";
            gm.Assigned = true;
            other.gameObject.SetActive(false);
        }
        else if (other.tag == "Glass" && gm.BubbleType == "Glass" && !gm.Full)
        {

            um.AddCarryItems();
            gm.InPlayer.Add(other.gameObject);
            gm.Speed = gm.Speed - gm.GlassSpeedDebuff;
            gm.BubbleType = "Glass";
            gm.Assigned = true;
            other.gameObject.SetActive(false);
        }
        else if (gm.BubbleType == "Glass" && other.tag == "Dump")
        {
            um.DisposeGlass();
            DiposeObjectsInPlayer();
            gm.AddGlass();
            gm.Durability--;
        }
        else if (gm.BubbleType == "Glass" && other.tag != "Glass" && other.tag != "Dump")
        {
            RestoreObjectsInPlayer();

            gm.Durability--;

        }
        else if (other.tag == "Metal" && !gm.Assigned)
        {
            um.AddCarryItems();
            gm.InPlayer.Add(other.gameObject);
            gm.LifeCurrTime += 5;
            gm.Speed = gm.Speed - gm.MetalSpeedDeBuff;
            gm.BubbleType = "Metal";
            gm.Assigned = true;
            other.gameObject.SetActive(false);
        }
        else if (other.tag == "Metal" && gm.BubbleType == "Metal" && !gm.Full)
        {
            um.AddCarryItems();
            gm.InPlayer.Add(other.gameObject);
            gm.LifeCurrTime += 5;
            gm.Speed = gm.Speed - gm.MetalSpeedDeBuff;
            gm.BubbleType = "Metal";
            gm.Assigned = true;
            other.gameObject.SetActive(false);
        }
        else if (gm.BubbleType == "Metal" && other.tag == "Dump")
        {
            um.DisposeMetal();
            DiposeObjectsInPlayer();
            gm.AddMetal();
            gm.Durability--;
        }
        else if (gm.BubbleType == "Metal" && other.tag != "Metal" && other.tag != "Dump")
        {
            RestoreObjectsInPlayer();
            Debug.Log("Die2");
            gm.Durability--;

        }
        else if (other.tag == "Plastic" && !gm.Assigned)
        {
            um.AddCarryItems();
            gm.InPlayer.Add(other.gameObject);
            gm.Speed = gm.Speed + gm.PlasticSpeedBuff;
            gm.BubbleType = "Plastic";
            gm.Assigned = true;
            other.gameObject.SetActive(false);
        }
        else if (other.tag == "Plastic" && gm.BubbleType == "Plastic" && !gm.Full)
        {
            um.AddCarryItems();
            gm.InPlayer.Add(other.gameObject);
            gm.BubbleType = "Plastic";
            gm.Speed = gm.Speed + gm.PlasticSpeedBuff;
            gm.Assigned = true;
            other.gameObject.SetActive(false);
        }
        else if (gm.BubbleType == "Plastic" && other.tag == "Dump")
        {
            um.DisposePlastic();
            DiposeObjectsInPlayer();
            gm.AddPlastic();
            gm.Durability--;
        }
        else if (gm.BubbleType == "Plastic" && other.tag != "Plastic" && other.tag != "Dump")
        {
            RestoreObjectsInPlayer();
            Debug.Log("Die3");
            gm.Durability--;

        }
        else if (gm.Full)
        {
            RestoreObjectsInPlayer();
            Debug.Log("Die4");
            gm.Durability--;

        }

    }
    public void DiposeObjectsInPlayer()
    {
        gm.InPlayer.Clear();
    }
    public void RestoreObjectsInPlayer()
    {
        foreach (GameObject item in gm.InPlayer)
        {
            item.SetActive(true);
        }
        gm.InPlayer.Clear();
    }
}
