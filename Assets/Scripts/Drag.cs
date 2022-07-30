using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    public string verb;

    Vector3 offset;
    public Vector3 verbTransform;
    public bool isTrigger;
    public bool isVerbTrigger;


    public float speedRotation;
    float timerRotation;
    //ESTO SE EJECUTA UN SOLO FRAME CUANDO PULSAMOS
    private void OnMouseDown()//Cuando hago click con el boton izquierdo del raton
    {
        if (!isVerbTrigger)
        {
            verbTransform = this.transform.position;
        }
        Vector2 mousePos = Input.mousePosition; //Coordenadas de pantalla
        //Estoy cogiendo la distancia que hay desde el gameObject a la cámara
        float distance = Camera.main.WorldToScreenPoint(transform.position).z; //WorldToScreenPoint devuelve (cordenada pantalla, cordenada pantalla, distancia de pantalla) ejemplo en el extremo de la pantalla (1920,1080,23pixeles)
        //Calculo en coordenadas de mundo dejuego (Dela escena de Unity) la posicion del ratón
        //TENIENDO EN CUENTA LA DESITANCIA Q LA QUE ESTA EL GAMEOBJECT
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, distance));
        //el oofset lo calculo para que a la hora de pinchar sobre el bojeto, el sguimiento del objeto al cursor del raton
        //se haga precisamente sobre el punto sobre el que hemos pinchado
        offset = transform.position - worldPos;
    }
    //eSTO SE EJECUTA SIEMPRE QUE ESTEMOS ARRASTRANDO EL RATON CON EL BOTON PULSADO
    private void OnMouseDrag()//Cuando arrastro el raton
    {
        Vector2 mousePos = Input.mousePosition;
        float distance = Camera.main.WorldToScreenPoint(transform.position).z;
        //EN ESTA LINEA LE DIGO AL OBJETO QUE SE MUEVA.
        //El offset hace que se mueva desde el punto donde he hecho click y no sobre el centro del objeto
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, distance)) + offset;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, speedRotation*timerRotation );
        timerRotation += Time.deltaTime;
        this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 10;

    }
    private void OnMouseUp()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;

        timerRotation = 0;
        if (!isTrigger)
        {
            transform.position = verbTransform;
            if(GameManager.instance.verbList.Count == 1)
            {
                if (GameManager.instance.verbList[0] == verb)
                {
                    GameManager.instance.verbList.RemoveAt(0);
                    this.GetComponent<Rigidbody2D>().isKinematic = false;
                    
                }
            }
        }
        
        else if (isVerbTrigger)
        {
            if (GameManager.instance.verbList.Count == 0)
            {
                GameManager.instance.EditNewsPaper(verb, this.gameObject);
                GameManager.instance.verbList.Add(verb);
                this.GetComponent<Rigidbody2D>().isKinematic = true;
            }
            else if(GameManager.instance.verbList.Count == 1)
            {
                if (GameManager.instance.verbList[0] == verb)
                {
                    GameManager.instance.EditNewsPaper(verb, this.gameObject);
                }
                else
                {
                    GameManager.instance.verbObject.transform.position = GameManager.instance.verbObject.GetComponent<Drag>().verbTransform;
                    GameManager.instance.verbObject.GetComponent<Rigidbody2D>().isKinematic = false;
                    GameManager.instance.verbList.RemoveAt(0);
                    GameManager.instance.verbList.Add(verb);
                    GameManager.instance.EditNewsPaper(verb, this.gameObject);
                    this.GetComponent<Rigidbody2D>().isKinematic = true;


                }
            }
            if (!isVerbTrigger)
            {
                if (GameManager.instance.verbList.Count == 1)
                {
                    if (GameManager.instance.verbList[0] == verb)
                    {
                        GameManager.instance.verbList.RemoveAt(0);
                        this.GetComponent<Rigidbody2D>().isKinematic = false;

                    }
                }
            }
        }
        else
        {
            if (GameManager.instance.verbList.Count == 1)
            {
                if (GameManager.instance.verbList[0] == verb)
                {
                    GameManager.instance.verbList.RemoveAt(0);
                    this.GetComponent<Rigidbody2D>().isKinematic = false;

                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isTrigger = true;
        if(collision.gameObject.tag == "Verb")
        {
            isVerbTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isTrigger = false;
        if (collision.gameObject.tag == "Verb")
        {
            isVerbTrigger = false;
        }
    }

}
