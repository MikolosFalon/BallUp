using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupFild : MonoBehaviour
{
    // walks 
    [SerializeField]
    private GameObject walkRight;
    [SerializeField]
    private GameObject walkLeft;
    
    //bonuses
    [SerializeField]
    private GameObject negativeBonus;
    [SerializeField]
    private GameObject positiveBonus;
    //list zones for bonus
    [SerializeField]
    private List<Transform> zone;

    private void Start()
    {
        Spawn();
    }
    public void Spawn()
    {
        //walk
        //limit 0.1 && 0.3
        float walk1 = Random.Range(6f, 10f);
        float walk2 = Random.Range(-10f, -6f);


        //set walk position
        walkRight.transform.position = new Vector3(walk1, walkRight.transform.position.y, walkRight.transform.position.z);
        walkLeft.transform.position = new Vector3(walk2, walkRight.transform.position.y, walkRight.transform.position.z);
   
        //zone set in inspector
        //zone position
        for (int i = 0; i < zone.Count; i++)
        {
            zone[i].position = new Vector3(Random.Range(walk2 + 4f, walk1 - 4f), zone[i].position.y, zone[i].position.z);
        }


        //bonus
        positiveBonus.SetActive(false);
        negativeBonus.SetActive(false);
        
        //set position bonus
        positiveBonus.SetActive(Random.value>0.5f);
        int posityvePosition = Random.Range(0, zone.Count);
        if (positiveBonus.activeSelf)
        {
            positiveBonus.transform.position = zone[posityvePosition].position;
        }
        
        //set negative bonus 
        negativeBonus.SetActive(Random.value > 0.5f);
        int negativePosition = Random.Range(0, zone.Count);
        if (negativeBonus.activeSelf)
        {
            while(posityvePosition == negativePosition)
            {
                negativePosition = Random.Range(0, zone.Count);
            }
            negativeBonus.transform.position = zone[negativePosition].position;
        }
        
    }
    

}
