using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    [SerializeField] bool isGlassBubble;
    [SerializeField] bool isMetalBubble;
    [SerializeField] bool isPlasticBubble;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Glass" && !isMetalBubble || !isPlasticBubble) 
        {
            isGlassBubble = true;
            isPlasticBubble = false;
            isMetalBubble = false;
            if (!isMetalBubble || !isPlasticBubble)
            {
                Destroy(other.gameObject);
            }
        }
        else if (other.tag == "Metal" && !isGlassBubble || !isPlasticBubble)
        {
            isMetalBubble = true;
            isGlassBubble = false;
            isPlasticBubble = false;
            if(!isGlassBubble || !isPlasticBubble) 
            { 
                Destroy(other.gameObject); 
            }
        }
        else if (other.tag == "Plastic" && !isGlassBubble || !isMetalBubble)
        {
            isPlasticBubble = true;
            isMetalBubble = false;
            isGlassBubble = false;
            if (!isGlassBubble || !isMetalBubble)
            {
                Destroy(other.gameObject);
            }
        }
    }
}
