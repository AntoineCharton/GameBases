﻿using UnityEngine;
using System.Collections;

namespace GZ.PlayerInputs
{
    public class InputsTypeSwitcher : MonoBehaviour
    {
        public string KeyboardInputType;
        public string ControllerInputType;
        public enum InputType { Keyboard, Controller };
        public InputType SelectedInput;
        public PlayerInputManager playerInputs;
        IEnumerator SwitchCoolDown;
        private bool CanRefreshInputs = true;


        // Update is called once per frame
        void Update()
        {
            if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.C)) && SelectedInput == InputType.Controller)
            {
                Debug.Log("Process inputs" + SelectedInput);
                if (SwitchCoolDown != null)
                {
                    StopCoroutine(SwitchCoolDown);
                    SwitchCoolDown = SwitchKeyboardCoolDown();
                    StartCoroutine(SwitchCoolDown);
                }
                playerInputs.SwitchAllInputs(KeyboardInputType);
                SelectedInput = InputType.Keyboard;
            }
            else if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f && CanRefreshInputs == true && SelectedInput == InputType.Keyboard)
            {
                Debug.Log("Switching to controller");
                playerInputs.SwitchAllInputs(ControllerInputType);
                SelectedInput = InputType.Controller;
            }
        }

        public string GetActionKeyboardKey()
        {
            return "F";
        }

        public string GetAttackKeyboardKey()
        {
            return "Left click";
        }

        IEnumerator SwitchKeyboardCoolDown()
        {
            CanRefreshInputs = false;
            yield return new WaitForSeconds(2f);
            CanRefreshInputs = true;
        }
    }
}
