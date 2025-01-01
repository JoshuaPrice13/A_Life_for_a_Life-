using UnityEngine;

public class First_Person_Movement : MonoBehaviour
{
    //private myHUD hud;
    private Vector3 Velocity;
    private Vector3 PlayerMovementInput;
    private Vector2 PlayerMouseInput;
    private float xRotation;

    public Transform PlayerCamera;
    public CharacterController Controller;
    public Transform Player;
    public GameObject FireStaff;
    public GameObject IceStaff;
    public GameObject LightningStaff;

    public float JumpForce;
    public float Sensetivity;

    private float Gravity = -9.8f; // Gravity is now set to -9.8

    //private float ProjectileSpeed = 100.0f;
    public float Speed;
    private int health = 5;
    private int points = 5;

    private bool hasBlueKey;
    private bool hasPurpleKey;
    private bool hasRedKey;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        //hud = GameObject.Find("HUD").GetComponent<myHUD>();
    }
    /*
    public float getProjectileSpeed()
    {
        return ProjectileSpeed;
    }

    public void takeHealth()
    {
        health -= 1;
        hud.updateHealth(health);
    }

    public void addPoint()
    {
        points += 5;
        hud.updatePoints(points);
    }

    public void takePoints(int count)
    {
        points -= count;
        hud.updatePoints(points);
    }

    public int getPoints()
    {
        return points;
    }

    public int getHealth()
    {
        return health;
    }

    public void ObtainItem(string item)
    {
        if (item == "BlueKey")
        {
            hud.ActivateKeyIcon("BlueKeyIcon");
            hasBlueKey = true;
        }
        else if (item == "PurpleKey")
        {
            hud.ActivateKeyIcon("PurpleKeyIcon");
            hasPurpleKey = true;
        }
        else if (item == "RedKey")
        {
            hud.ActivateKeyIcon("RedKeyIcon");
            hasRedKey = true;
        }
        else if (item == "IceStaff")
        {
            FireStaff.SetActive(false);
            LightningStaff.SetActive(false);
            IceStaff.SetActive(true);
        }
        else if (item == "LightningStaff")
        {
            print("activate lightning staff");
            FireStaff.SetActive(false);
            IceStaff.SetActive(false);
            LightningStaff.SetActive(true);
        }

    }

    public bool HasKey(string doorName)
    {
        if (doorName == "BlueRoom_DOOR")
        {
            if (hasBlueKey)
            {
                return true;
            }
        }
        else if (doorName == "PurpleRoom_DOOR")
        {
            if (hasPurpleKey)
            {
                return true;
            }
        }
        else if (doorName == "RedRoom_DOOR")
        {
            if (hasRedKey)
            {
                return true;
            }
        }

        return false;
    }
    */
    private void MovePlayer()
    {
        Vector3 MoveVector = transform.TransformDirection(PlayerMovementInput);

        if (Controller.isGrounded)
        {
            Velocity.y = -1f; // Small downward force to keep grounded

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Velocity.y = JumpForce;
            }
        }
        else
        {
            // Gravity is directly applied as a negative value
            Velocity.y += Gravity * Time.deltaTime;
        }

        // Apply horizontal movement and gravity separately
        Controller.Move(MoveVector * Speed * Time.deltaTime);
        Controller.Move(Velocity * Time.deltaTime);
    }

    private void MoveCamera()
    {
        xRotation -= PlayerMouseInput.y * Sensetivity;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.Rotate(0f, PlayerMouseInput.x * Sensetivity, 0f);
        PlayerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    void Update()
    {
        PlayerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        PlayerMouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        MovePlayer();
        MoveCamera();

        // Gravity is directly applied as a negative value
        Velocity.y += Gravity * Time.deltaTime;
        Controller.Move(Velocity * Time.deltaTime);
    }

}
