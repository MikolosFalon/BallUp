using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    //set spawn on inspector for move
    [SerializeField]
    private Transform Spawn;
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "fild")
        {
            col.transform.position = Spawn.position;
            col.GetComponent<SetupFild>().Spawn();
        }
    }
}
