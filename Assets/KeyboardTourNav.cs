// using UnityEngine;
// using UnityEngine.InputSystem;

// public class KeyboardTourNav : MonoBehaviour
// {
//     private TourManager tourManager;
//     private int currentRoom = 0;

//     void Start()
//     {
//         tourManager = GetComponent<TourManager>();
//     }

//     void Update()
//     {
//         if (Keyboard.current.wKey.wasPressedThisFrame)
//         {
//             currentRoom++;
//             tourManager.SwitchToRoom(currentRoom);
//         }

//         if (Keyboard.current.sKey.wasPressedThisFrame)
//         {
//             currentRoom--;
//             tourManager.SwitchToRoom(currentRoom);
//         }
//     }
// }

// using UnityEngine;
// using UnityEngine.InputSystem;

// public class KeyboardTourNav : MonoBehaviour
// {
//     private TourManager tourManager;
//     private int currentRoom = 0;
//     private int rightTurnFromRoom = 43;  // image index where right turn exists
//     private int rightTurnDestination = 45; // PUT THE INDEX OF THE RIGHT TURN IMAGE HERE

//     void Start()
//     {
//         tourManager = GetComponent<TourManager>();
//     }

//     void Update()
//     {
//         if (Keyboard.current.wKey.wasPressedThisFrame)
//         {
//             currentRoom++;
//             tourManager.SwitchToRoom(currentRoom);
//         }

//         if (Keyboard.current.sKey.wasPressedThisFrame)
//         {
//             currentRoom--;
//             tourManager.SwitchToRoom(currentRoom);
//         }

//         if (Keyboard.current.dKey.wasPressedThisFrame && currentRoom == rightTurnFromRoom)
//         {
//             currentRoom = rightTurnDestination;
//             tourManager.SwitchToRoom(currentRoom);
//         }
//     }
// }

// using UnityEngine;
// using UnityEngine.InputSystem;

// public class KeyboardTourNav : MonoBehaviour
// {
//     private TourManager tourManager;
//     private int currentRoom = 0;

//     void Start()
//     {
//         tourManager = GetComponent<TourManager>();
//     }

//     void Update()
//     {
//         if (Keyboard.current.wKey.wasPressedThisFrame)
//         {
//             int next = GetForward(currentRoom);
//             if (next != -1)
//             {
//                 currentRoom = next;
//                 tourManager.SwitchToRoom(currentRoom);
//             }
//         }

//         if (Keyboard.current.sKey.wasPressedThisFrame)
//         {
//             int next = GetBackward(currentRoom);
//             if (next != -1)
//             {
//                 currentRoom = next;
//                 tourManager.SwitchToRoom(currentRoom);
//             }
//         }

//         if (Keyboard.current.dKey.wasPressedThisFrame)
//         {
//             int next = GetRight(currentRoom);
//             if (next != -1)
//             {
//                 currentRoom = next;
//                 tourManager.SwitchToRoom(currentRoom);
//             }
//         }
//     }

//     int GetForward(int room)
//     {
//         if (room == 32) return 40;  // img41 → straight → img32
//         if (room == 34) return 35;  // img43 → straight → img44
//         if (room == 35) return -1;  // img44 → dead end
//         if (room == 39) return -1;  // img48 → dead end
//         if (room == 42) return -1;  // img34 → dead end
//         return room + 1;
//     }

//     int GetBackward(int room)
//     {
//         if (room == 40) return 32;  // img32 → back → img41
//         if (room == 33) return 32;  // img42 → back → img41
//         if (room == 35) return 34;  // img44 → back → img43
//         if (room == 36) return 34;  // img45 → back → img43
//         return room - 1;
//     }

//     int GetRight(int room)
//     {
//         if (room == 32) return 33;  // img41 → right → img42
//         if (room == 34) return 36;  // img43 → right → img45
//         return -1;
//     }
// }

using UnityEngine;
using UnityEngine.InputSystem;

public class KeyboardTourNav : MonoBehaviour
{
    private TourManager tourManager;
    private int currentRoom = 0;

    private InputAction buttonB;
    private InputAction buttonA;
    private InputAction buttonY;

    void Start()
    {
        tourManager = GetComponent<TourManager>();

        // Correct OpenXR paths for Meta Quest Pro
        buttonB = new InputAction(binding: "<MetaQuestTouchProController>{RightHand}/secondaryButton");
        buttonA = new InputAction(binding: "<MetaQuestTouchProController>{RightHand}/primaryButton");
        buttonY = new InputAction(binding: "<MetaQuestTouchProController>{LeftHand}/secondaryButton");

        buttonB.Enable();
        buttonA.Enable();
        buttonY.Enable();
    }

    void OnDestroy()
    {
        buttonB.Disable();
        buttonA.Disable();
        buttonY.Disable();
    }

    void Update()
    {
        // Forward — W or B button
        if (Keyboard.current.wKey.wasPressedThisFrame || buttonB.WasPressedThisFrame())
        {
            int next = GetForward(currentRoom);
            if (next != -1)
            {
                currentRoom = next;
                tourManager.SwitchToRoom(currentRoom);
            }
        }

        // Backward — S or A button
        if (Keyboard.current.sKey.wasPressedThisFrame || buttonA.WasPressedThisFrame())
        {
            int next = GetBackward(currentRoom);
            if (next != -1)
            {
                currentRoom = next;
                tourManager.SwitchToRoom(currentRoom);
            }
        }

        // Right — D or Y button
        if (Keyboard.current.dKey.wasPressedThisFrame || buttonY.WasPressedThisFrame())
        {
            int next = GetRight(currentRoom);
            if (next != -1)
            {
                currentRoom = next;
                tourManager.SwitchToRoom(currentRoom);
            }
        }
    }

    int GetForward(int room)
    {
        if (room == 32) return 40;
        if (room == 34) return 35;
        if (room == 35) return -1;
        if (room == 39) return -1;
        if (room == 42) return -1;
        return room + 1;
    }

    int GetBackward(int room)
    {
        if (room == 40) return 32;
        if (room == 33) return 32;
        if (room == 35) return 34;
        if (room == 36) return 34;
        return room - 1;
    }

    int GetRight(int room)
    {
        if (room == 32) return 33;
        if (room == 34) return 36;
        return -1;
    }
}