using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipTrigger : MonoBehaviour
{
    [SerializeField] GM gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GM>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            gm.AddScore();
        }
    }
}
