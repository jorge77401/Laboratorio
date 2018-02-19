using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puertas : MonoBehaviour {


    Animator animator;
    bool hecho;

	// Use this for initialization
	void Start () {

        animator = GetComponent<Animator>();
        
        
	}

    // Update is called once per frame
    void Update()
    {


        test();
         



    }

    void test()
    {

        if (GameManager.AnimarBaño)
        {

            ControlPuerta("Abierta");


        }

    

    }

    //void OnTriggerEnter(Collider col)
    //{
    //    //si el jugador entra en colision la puerta se abre
    //    if (col.gameObject.tag == "Jugador")
    //    {
    //        ControlPuerta("Abierta");
    //        print("Abierta");

    //    }

    //}


    //void OnTriggerExit(Collider col)
    //{
    //    if (col.gameObject.tag == "Jugador")
    //    {
    //        //si el jugador sale de colision la puerta se cierra
    //        ControlPuerta("Cerrada");
    //        print("Cerrada");
    //    }

    //}

    //aqui se llama el componente del animator a traves del string dado arriba.
    void ControlPuerta(string direction)
    {
        animator.SetTrigger(direction);
    }

}
