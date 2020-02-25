using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class forInstantiate : MonoBehaviour
{
    public GameObject wB;
    public GameObject wG;
    public InputDevice[] devices;
    // Start is called before the first frame update
    void Start()
    {
      
        PlayerInput.Instantiate(wG, new Vector3(-26, -9, 0), Quaternion.identity);
        PlayerInput.Instantiate(wB, new Vector3(-20, -9, 0), Quaternion.identity);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
