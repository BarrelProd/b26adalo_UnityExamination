using System;
using UnityEngine;

public class QurbBehaviour : MonoBehaviour
{
    public GameObject qurbSpeech;
    public bool talking;
    public bool canTalk;
    
    void Start()
    {
        canTalk = false;
        talking = false;
    }

    
    void Update()
    {
        if (canTalk == true && Input.GetKeyDown(KeyCode.E))
        {
            qurbSpeech.SetActive(true);
            talking = true;
            canTalk = false;
        }
        else if (talking == true && Input.GetKeyDown(KeyCode.E))
        {
            qurbSpeech.SetActive(false);
            talking = false;
            canTalk = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canTalk = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canTalk = false;
        }
    }
}
