using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMaps : MonoBehaviour
{
    List<GameObject> Maps = new List<GameObject>();
    public GameObject map00;
    public GameObject map01;
    public GameObject map02;
    public GameObject map03;
    public GameObject map04;

    public bool canSpawn;
    // Start is called before the first frame update
    void Start()
    {
        Maps.Add(map00);
        Maps.Add(map01);
        Maps.Add(map02);
        Maps.Add(map03);
        Maps.Add(map04);
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="SpawnMap")
        {
            canSpawn = true;
            Instantiate(Maps[Random.Range(0, 4)], transform.position, transform.rotation);
            canSpawn = false;
        }
    }
}
