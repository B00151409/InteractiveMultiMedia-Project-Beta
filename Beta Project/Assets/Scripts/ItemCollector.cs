using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int coins = 0;
    public Text collectableCounter;
    [SerializeField] private AudioSource coinSound;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider collision)
    {
        
        if (collision.gameObject.CompareTag("Coins"))
        {
            
            coinSound.Play();
            Destroy(collision.gameObject);
            coins++;
            collectableCounter.text = ":" + coins;
        }
    }
}
