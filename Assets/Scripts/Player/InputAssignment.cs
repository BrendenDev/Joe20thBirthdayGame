using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputAssignment
{
    public static void EnableInput(InputActionReference[] inputs) {
        foreach (InputActionReference input in inputs) {
            input.action.Enable(); 
        }
    }

    public static void EnableInput(InputActionReference input) {
        input.action.Enable(); 
    }

    public static void DisableInput(InputActionReference[] inputs) {
        foreach (InputActionReference input in inputs) {
            input.action.Disable(); 
        }
    }

    public static void DisableInput(InputActionReference input) {
        input.action.Disable(); 
    }
}
