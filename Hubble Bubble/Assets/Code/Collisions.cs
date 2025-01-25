using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    GameManager gm;
    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Glass" && !gm.Assigned) 
        {
            gm.ItemsCarried++;
            gm.BubbleType = "Glass";
            gm.Assigned = true;
            Destroy(other.gameObject);
        }
        else if (other.tag == "Glass" && gm.BubbleType == "Glass")
        {
            gm.BubbleType = "Glass";
            gm.Assigned = true;
            if(other.tag != "Glass") 
            {
                Debug.Log("No");
            }
            else 
            {
                gm.ItemsCarried++;
                Destroy(other.gameObject);
            }
            
        }
        else if (other.tag == "Metal" && !gm.Assigned)
        {
            gm.ItemsCarried++;
            gm.BubbleType = "Metal";
            gm.Assigned = true;
            Destroy(other.gameObject);
        }
        else if (other.tag == "Metal" && gm.BubbleType == "Metal")
        {
            gm.BubbleType = "Metal";
            gm.Assigned = true;
            if (other.tag != "Metal")
            {
                Debug.Log("No");
            }
            else 
            {
                gm.ItemsCarried++;
                Destroy(other.gameObject);
            }
        }
        else if (other.tag == "Plastic" && !gm.Assigned)
        {
            gm.ItemsCarried++;
            gm.BubbleType = "Plastic";
            gm.Assigned = true;
            Destroy(other.gameObject);
        }
        else if (other.tag == "Plastic" && gm.BubbleType == "Plastic")
        {
            gm.BubbleType = "Plastic";
            gm.Assigned = true;
            if (other.tag != "Plastic")
            {
                Debug.Log("No");
            }
            else 
            {
                gm.ItemsCarried++;
                Destroy(other.gameObject);
            }
        }
    }
}
