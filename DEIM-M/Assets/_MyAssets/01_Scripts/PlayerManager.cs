using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    //Variables de vivo, velocidad y velocidad de desplazamiento lateral
    bool isAlive;
    public float speed;
    [SerializeField] float desplSpeed; //Serializada para poder cambiarla en Unity
    [SerializeField] float rotationSpeed; //velocidad a la que rotaré, en vueltas por segundo


    //Variable que obtendrá el movimiento del joystick en el eje X
    float moveX;
    float moveY;

    //Variable que obiene la rotación del RS
    float rotation;

    //Clase creada con el Input Asset
    InputActions inputActions;

    //Usaremos el Awake para activar los inputs y obtener los datos
    private void Awake()
    {
        //Creamos la instancia del asset de entradas IMPORTANTE: hay que activarlo en OnEnable()
        inputActions = new InputActions();

        //Cuando pulsamos el botón de fuego se ejecuta el método correspondiente
        inputActions.Player.Fire.started += _ => Fire();

        //Cuando activamos la entrada de mover en X le damos el variable a la valor, y al dejar de tocarla la ponemos en cero
        inputActions.Player.MoveX.performed += ctx => moveX = ctx.ReadValue<float>();
        inputActions.Player.MoveX.canceled += _ => moveX = 0f;

        inputActions.Player.MoveY.performed += ctx => moveY = ctx.ReadValue<float>();
        inputActions.Player.MoveY.canceled += _ => moveY = 0f;

        //Obtenemos la rotación
        inputActions.Player.Rotate.performed += ctx => rotation = ctx.ReadValue<float>();
        inputActions.Player.Rotate.canceled += _ => rotation = 0f;


    }

    private void Update()
    {
        transform.Translate(Vector3.right * desplSpeed * moveX * Time.deltaTime,Space.World);
        transform.Translate(Vector3.up * desplSpeed * moveY * Time.deltaTime);

        transform.Rotate(Vector3.forward * rotation * rotationSpeed * Time.deltaTime * -360);
    }


    void Fire()
    {
        print("POOM");
    }

    //IMPORTANTE: activar el Inpu
    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }







}
