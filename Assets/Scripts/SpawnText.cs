using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
public class SpawnText : MonoBehaviour
{

    [SerializeField]
    private TextMeshPro yourText; 

    void Start()
    {
        yourText.enabled = false; 
    }


  
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            yourText.enabled = true; 
        }

    }


    void OnTriggerExit2D(UnityEngine.Collider2D other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            yourText.enabled = false; 
        }
    }
}