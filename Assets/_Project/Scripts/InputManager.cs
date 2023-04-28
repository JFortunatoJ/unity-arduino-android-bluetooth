using BNG;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [Header("Left")]
    [SerializeField] private Transform _leftController;
    [SerializeField] private Transform _rightController;
    [Space]
    [SerializeField] private float _startFowardRange;
    [SerializeField] private float _endFowardRange;
    [Space]
    [SerializeField] private float _startBackwardRange;
    [SerializeField] private float _endBackwardRange;

    private InputBridge _input;
    
    private WheelMovementEnum _leftWheelMovement;
    private WheelMovementEnum LeftWheelMovement
    {
        get => _leftWheelMovement;
        set
        {
            if(value == _leftWheelMovement) return;

            _leftWheelMovement = value;
            
            print($"Left command sent: {_leftWheelMovement}");
            BluetoothManager.SendMessage(MovementHelper.GetLeftDirectionString(_leftWheelMovement));
        }
    }
    
    private WheelMovementEnum _rightWheelMovement;
    private WheelMovementEnum RightWheelMovement
    {
        get => _rightWheelMovement;
        set
        {
            if(value == _rightWheelMovement) return;

            _rightWheelMovement = value;
            
            print($"Right command sent: {_rightWheelMovement}");
            BluetoothManager.SendMessage(MovementHelper.GetRightDirectionString(_rightWheelMovement));
        }
    }

    private void Start()
    {
        _input = InputBridge.Instance;

        LeftWheelMovement = WheelMovementEnum.Stop;
        RightWheelMovement = WheelMovementEnum.Stop;
    }

    private void Update()
    {
        /*
        float left = Vector3.Dot(_leftController.forward, Vector3.forward);
        float right = Vector3.Dot(_rightController.forward, Vector3.forward);
        
        print($"Left: {left}");
        print($"Right: {right}");
        */

        LeftWheelMovement = GetMovementInput(_leftController);
        RightWheelMovement = GetMovementInput(_rightController);
    }

    private WheelMovementEnum GetMovementInput(Transform controller)
    {
        float input = Vector3.Dot(controller.up, Vector3.forward);
        
        if (input >= _startFowardRange && input <= _endFowardRange)
        {
            return WheelMovementEnum.Forward;
        }

        if (input > _startBackwardRange && input <= _endBackwardRange)
        {
            return WheelMovementEnum.Backward;
        }

        return WheelMovementEnum.Stop;
    }
}
