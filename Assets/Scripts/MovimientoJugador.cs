using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    //Crea el componente character controller para usar en el script
    private CharacterController characterController;

    //Reinicia la velocidad a 0 desde los 3 vectores
    private Vector3 velocidad = Vector3.zero;


    //La fuerza de la gravedad; 20?
    [SerializeField]
    private float gravedad = 20;

    //Crea la variable está en el piso
    private bool EstaEnElPiso;
    private bool isWalking;
    private bool isToggleMove;
    Animator animator;
    // Use this for initialization
    void Start()
    {
        //Asigna el componente a la variable
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        isWalking = true;

        if (isWalking) { 

        if (velocidad.z != 0)
        {
            animator.SetBool("caminando", true);

              
            }



        if (velocidad.z == 0)
        {
            animator.SetBool("caminando", false);
        }
        }

   

        //Si esta en el piso
        if (EstaEnElPiso)
        {
            velocidad = new Vector3(Input.GetMouseButton(1) ? Input.GetAxis("Horizontal") : 0, 0, Input.GetAxis("Vertical"));
            velocidad *= 4;


            //imprimir está en el suelo
            print("esta en el suelo");
            velocidad = transform.TransformDirection(velocidad);
            transform.Rotate(0, Input.GetAxis("Horizontal") *200 * Time.deltaTime, 0);
        }

        //La velocidad en el eje Y = velocidad en el eje y - gravedad * time delta time
        velocidad.y -= gravedad * Time.deltaTime;
        //Esta en el piso = al movimiento del character controller * la velocidad * time delta time & las colisiones debajo, si es diferente a 0;
        EstaEnElPiso = (characterController.Move(velocidad * Time.deltaTime) & CollisionFlags.Below) != 0;
    }
}