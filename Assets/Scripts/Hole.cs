using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public List<GameObject> moles;
    public bool isActive;
    public int moleIndex;

    // Start is called before the first frame update
    void Start()
    {
       //moleIndex = GenerateMole();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private int GenerateMole()
    {
        isActive = true;

        int randomMole = Random.Range(0, moles.Count);
        Instantiate(moles[randomMole],
            new Vector3(transform.position.x, transform.position.y + 1, transform.position.z),
            transform.rotation);
        

        return randomMole;
    }


}
