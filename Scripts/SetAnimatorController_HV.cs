using UnityEngine;

public class SetAnimatorController_HV : MonoBehaviour
{
    public float speedT = 10;
    public float speedR = 10;
    public string HAxisName = "Horizontal";
    public string VAxisName = "Vertical";

    CharacterController controller;
    Vector3 velocity;
    bool instanciate;
    public bool JoystickInput;
    Vector3 rotVelocity;

    void Start()
    {
        instanciate = false;
        controller = transform.GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            JoystickInput = !JoystickInput;
    }

    void FixedUpdate()
    {
        if (JoystickInput == false)
        {
            float HVal = Input.GetAxis(HAxisName) * speedR * Time.deltaTime;
            float VVal = Input.GetAxis(VAxisName) * speedT * Time.deltaTime;
            transform.Rotate(0, HVal, 0);
            if (instanciate == false)
            {
                transform.Translate(0, 0, VVal);
                instanciate = true;
            }
            else
            {
                velocity = transform.forward * VVal;
                controller.Move(velocity);
            }
        }
        else
        {
            controller.Move(InputManager.MainJoystick());
            rotVelocity = InputManager.Rotation();
            rotVelocity.x = transform.rotation.x;
            transform.Rotate(InputManager.Rotation());
        }
    }
}

