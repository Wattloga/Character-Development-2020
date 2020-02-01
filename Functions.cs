using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Functions : MonoBehaviour
{
    public string playerName;
    private int myNumber;
    public float speed = 5;
    public GameObject player;
    public Color playerColor = Color.red;

    // Start is called before the first frame update
    void Start()
    {
        ConfigGameObject(); 
    }

    private GameObject ConfigGameObject()
    {
        var newPlayer = Instantiate(player);
        newPlayer.layer = 0;
        newPlayer.active = true;
        newPlayer.tag = "Player";
        newPlayer.transform.position = Vector3.zero;
        newPlayer.name = playerName;
        newPlayer.GetComponent<Renderer>().material.color = playerColor;

        return newPlayer;
    }

    private void OnTriggerEnter(Collider other)
    {
        speed = IncreaseSpeed(2f);
    }
    private float IncreaseSpeed(float multiplier)
    {
        return speed * multiplier;
    }
    private string WelcomePlayer()
    {
        return playerName + "Welcome to the game!";
    }
    private int AddNumbers(int a, int b)
    {
        print(a + b);
        return a + b;
    }

    public int a = 4;
    public int b = 5;
    public int c = 10;
    public string password = "Friend";
    public bool lightsOn = false;
    // Start is called before the first frame update
    void Start()
    {
        if (a + b < c)
        {
            print(true);
        }
        else if (password != "OU812")
        {
            print(true);
        }
        else if (!lightsOn)
        {
            print(true);
        }
        else
        {
            print(false);
        }
    }
    private Vector3 position;
    private CharacterController controller;

    public float moveSpeed = 10f, gravity = 9.81f, jumpSpeed = 30f;
    private int jumpCount;
    public int jumpCountMax = 2;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        position.x = moveSpeed * Input.GetAxis("Horizontal");
        position.z = moveSpeed * Input.GetAxis("Vertical");
        position.y -= gravity;

        if (controller.isGrounded)
        {
            position.y = 0;
            jumpCount = 0;
        }

        if (Input.GetButtonDown("Jump") && jumpCount < jumpCountMax)
        {
            position.y = jumpSpeed;
            jumpCount++;
        }

        contoller.Move(position * Time.deltaTime);
    }

    private void Awake()
    {
        GetComponent<Collider>().isTrigger = true;
    }

    public UnityEvent triggerEnterEvent, triggerExitEvent;
    private void OnTriggerEnter(Collider other)
    {
        triggerEnterEvent.Invoke();
    }

    private void OnTrriggerExit(Collider other)
    {
        triggerExitEvent.Invoke();
    }

    [SerializeField] Text textComponent;
    [SerializeField] State startingState;

    State state;

    // Start is called before the first frame update
    void Start()
    {
        state = startingState;
        textComponent.text = state.GetStateStory();

    }

    // Update is called once per frame
    void Update()
    {
        ManageState();
    }
    private void ManageState()
    {
        var nextState = state.GetNextStates();
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            state = nextState[0];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            state = nextState[1];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            state = nextState[2];
        }
    }

}
