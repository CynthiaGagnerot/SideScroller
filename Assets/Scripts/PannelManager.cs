using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PannelManager : MonoBehaviour
{
    
    public bool Proxi = false; //proxi = a proximite
    public bool dialogueManagerState = false;
    public PanelSO PanelText;

    public GameObject Ebutton;
    public GameObject dialogueManagerObj;
    public DialogueManager dialogueManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        //dialogueManager = FindFirstObjectByType<DialogueManager>();
        dialogueManagerObj.GetComponent<Sprite>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Proxi == true && Input.GetKeyDown(KeyCode.E))
        {
            if (dialogueManagerState == false)
            {
                dialogueManagerState = true;
                dialogueManagerObj.SetActive(dialogueManagerState);
                dialogueManager.pannelManager = this;
            }

            else
            {
                dialogueManagerState = false;
                dialogueManagerObj.SetActive(dialogueManagerState);
                dialogueManager.pannelManager = null;
            }

        }
        

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Sip"))
        {
            Proxi = true;
            Ebutton.SetActive(true);
            dialogueManager.pannelManager = this;
        }       
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Sip"))
        {
            Proxi = false;
            Ebutton.SetActive(false);
            dialogueManagerObj.SetActive(false);
            dialogueManager.pannelManager = null;
        }
    }

}
