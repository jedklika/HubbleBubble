using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField] bool isGlass;
    [SerializeField] bool isMetal;
    [SerializeField] bool isPlastic;

    [SerializeField] float durability;
    [SerializeField] float speed;
    [SerializeField] float carryCap;
    // Start is called before the first frame update
    void Start()
    {
        if(isGlass) 
        {
            gameObject.tag = "Glass";
        }
        if (isMetal)
        {
            gameObject.tag = "Metal";
        }
        if (isPlastic)
        {
            gameObject.tag = "Plastic";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
