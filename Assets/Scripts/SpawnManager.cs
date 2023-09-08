using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> moles;
    public float respawnTime;

    Timer timer;


    // Start is called before the first frame update
    void Start()
    {
        timer = FindObjectOfType<Timer>();
        GenerateMole();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerateMole()
    {
        int randomMole = Random.Range(0, moles.Count);
        GameObject newMole = Instantiate(moles[randomMole],
            new Vector3(transform.position.x, transform.position.y + 1, transform.position.z),
            transform.rotation, this.transform);
    }


}
