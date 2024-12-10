using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [Header("Camara")]
    public float rotationSpeed = 300f;
    public float camXRot = 0f;//Rotacion de la camara en x
    private Camera _camera;

    [Header("Moviemiento y salto")]
    public float moveSpeed = 5f;
    private Vector3 input;
    private Rigidbody _rb;
    public float jumpForce = 300f;
    public bool isGrounded = true;
    public bool isJump = false;
    public bool isMoving = false;

    [Header("Ground Checker")]
    public Transform groundCheckCenter;
    public Vector3 groundCheckSize = Vector3.one;
    //Para guardar los colliders que detecta el ground checker
    public Collider[] detectedColliders;
    //Para que el ground checker solo detecte la layer que nos interesa (Ground)
    //Asi no detectara al Player ni otros objetos que estorban
    public LayerMask groundLayer;

    [Header("Otros")]

    public Transform pos1;
    public Transform pos2;
    public bool isLooking = false;
    public bool doSound = false;
    //public Transform enemy1;
    public float angulo = 60f;
    private GameObject enemiestatute;
    private Vector3 enemyPos;
    public float maxDistance = 10f;
    public LayerMask Wall;
    //public LayerMask EnemyS;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        //buscamos la camara en los objetos hijos y la asignamos
        _camera = GetComponentInChildren<Camera>();
        enemiestatute = GameObject.FindWithTag("EnemyStatue");
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiestatute != null)
        {
            enemyPos = enemiestatute.transform.position;
            Look();
        }
        else
        {
            Debug.Log("El objeto no está presente o está desactivado.");
        }
        isRun();
        MovePlayer();
        //HandleSpeed();
        float _horizontal = Input.GetAxisRaw("Horizontal");
        float _vertical = Input.GetAxisRaw("Vertical");
        input = new Vector3(_horizontal, 0f, _vertical);
        input = transform.TransformDirection(input);
        //if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        //{
        //    _rb.AddForce(Vector3.up * jumpForce);
        //    //Cuando saltamos ponemos el doSound en true
        //    doSound = true;
        //    //Hacemos una corutina para ponerla en false cuando pase un tiempo
        //    StartCoroutine(SinSonido());
        //}
        //GroundCheck();
        float _rotMouseX = Input.GetAxisRaw("Mouse X");

        //float _rotMouseY = Input.GetAxisRaw("Mouse Y"); para rotar en el eje y hay que hacerlo con la camara
        transform.Rotate(0, _rotMouseX * rotationSpeed * Time.deltaTime, 0);
        //Se acumula el valor de la rotacion en X de la camara
        //para que aumente o disminuya conforme movemos el raton arriba y abajo
        camXRot -= Input.GetAxisRaw("Mouse Y") * rotationSpeed * Time.deltaTime;
        camXRot = Mathf.Clamp(camXRot, -60, 60);
        //Asignamos la rotacion en x a los angulos de la camara
        _camera.transform.localEulerAngles = new Vector3(camXRot, 0, 0);
    }
    private IEnumerator SinSonido()
    {
        yield return new WaitForSeconds(0.15f);
        doSound = false;

    }
    private void MovePlayer()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        _rb.MovePosition(transform.position + movement * moveSpeed * Time.deltaTime);
    }
    private void isRun()
    {
        //Si pulsa f la velocidad cambia y la variable doSound es true
        if (Input.GetKey(KeyCode.F))
        {
            moveSpeed = 10f;
            doSound = true;
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            moveSpeed = 5f;
            doSound = false;
        }
    }
    private void FixedUpdate()
    {
        //no usar input en fixedupdate
        //Hay que normalizar el input para que no se mueva mas rapido en diagonal
        Vector3 _velocity = input.normalized * moveSpeed;
        //No podemor modificar la cvelocity en el eje Y del rigibody, o caera muy despacio
        _velocity.y = _rb.velocity.y;
        _rb.velocity = _velocity;

    }
    void GroundCheck()
    {
        //Guardamos la variable todos los colliders que encuentre el overlap
        detectedColliders = Physics.OverlapBox(groundCheckCenter.position, groundCheckSize * 0.5f, Quaternion.Euler(0, 0, 0), groundLayer);
        //Cuando el checker detecte la menos un objeto suelo, podemos saltar
        if (detectedColliders.Length > 0)
        {
            isGrounded = true;
            isJump = false;
        }
        else
        {
            //Cuando no haya ningun objeto detectado, ya estaremos en el aire
            isGrounded = false;
            isJump = true;
        }

    }
    public void Look()
    {
        Vector3 enemydirection = enemyPos - transform.position;
        float angle = Vector3.Angle(transform.forward, enemydirection);

        if (angle <= angulo * .5f)
        {

            RaycastHit hit;
            if (Physics.Raycast(transform.position, enemydirection.normalized, out hit, maxDistance, Wall))
            {
                // Si el rayo golpea algo, mostramos el nombre del objeto
                Debug.Log("El rayo ha tocado: " + hit.collider.name);
                isLooking = false;
                
            }
            else
            {
                isLooking = true;
                Debug.Log("Esta en el rango");
            }
          
        }
        else
        {
            isLooking = false;
            Debug.Log("No te veo");

        }
        Debug.DrawRay(transform.position, enemydirection.normalized * maxDistance, Color.magenta);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(groundCheckCenter.position, groundCheckSize);
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * maxDistance);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, pos1.transform.position);
        Gizmos.DrawLine(transform.position, pos2.transform.position);
    }
}
