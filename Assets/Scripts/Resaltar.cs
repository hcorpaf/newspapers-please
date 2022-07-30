using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Resaltar : MonoBehaviour
{

    public SpriteRenderer textToResaltar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        textToResaltar.enabled = true;
    }
    private void OnMouseExit()
    {
        textToResaltar.enabled = false;
    }
}
