using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int fruits = 0;
    [SerializeField] private Text fruitsCount;
    [SerializeField] private AudioSource collectFruits;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fruits"))
        {
            collectFruits.Play();
            fruits++;
            Destroy(collision.gameObject);
            fruitsCount.text = "Fruits: " + fruits;
        }
    }
   
}
