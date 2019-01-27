using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnoreScript : MonoBehaviour
{
    [SerializeField] bool snoring = true;
    AudioManager audioManager;
    [SerializeField] string snore= "snore0";
    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
            StartCoroutine(Snore());


        
    }


    IEnumerator Snore()
    {
        while (snoring)
        {
            int randome = Random.Range(1, 5);
            audioManager.Play(snore + randome);

            yield return new WaitForSeconds(5f);

        }
    }

}
