using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class OVRInputProvider : VRInputProvider
{
    public InputDevice left_controller;
    public InputDevice right_controller;

    private void CalculateLeftController()
    {
        if (left_controller.TryGetFeatureValue(CommonUsages.gripButton, out var val))
        {
            if (left_controller.TryGetFeatureValue(CommonUsages.grip, out float val1))
            {
                left_grip = CalculateState(left_grip, val);
                left_grip.value = val1;
            };

        };

        if (left_controller.TryGetFeatureValue(CommonUsages.triggerButton, out var val4))
        {
            if (left_controller.TryGetFeatureValue(CommonUsages.trigger, out float val5))
            {
                left_trigger = CalculateState(left_trigger, (val5 >= 0.1f));
                left_trigger.value = val5;
            };

        };
        if (left_controller.TryGetFeatureValue(CommonUsages.secondaryButton, out var val2))
        {
            left_secondaryButton = CalculateState(left_secondaryButton, val2);

        };
        if (left_controller.TryGetFeatureValue(CommonUsages.primaryButton, out var val3))
        {
            left_primaryButton = CalculateState(left_primaryButton, val3);
        };
        if (left_controller.TryGetFeatureValue(CommonUsages.menuButton, out var val6))
        {
            left_menubutton = CalculateState(left_menubutton, val6);
        };
    }
    private void CalculateRightController()
    {
        if (right_controller.TryGetFeatureValue(CommonUsages.gripButton, out var val))
        {
            if (right_controller.TryGetFeatureValue(CommonUsages.grip, out float val1))
            {
                right_grip = CalculateState(right_grip, val);
                right_grip.value = val1;
            };

        };
        if (right_controller.TryGetFeatureValue(CommonUsages.triggerButton, out var val4))
        {
            if (right_controller.TryGetFeatureValue(CommonUsages.trigger, out float val5))
            {
                right_trigger = CalculateState(right_trigger, (val5 >= 0.1f));
                right_trigger.value = val5;
            };

        };
        if (right_controller.TryGetFeatureValue(CommonUsages.secondaryButton, out var val2))
        {
            right_secondaryButton = CalculateState(right_secondaryButton, val2);

        };
        if (right_controller.TryGetFeatureValue(CommonUsages.primaryButton, out var val3))
        {
            right_primaryButton = CalculateState(right_primaryButton, val3);
        };
    }
    public InputDevice getRightHand()
    {
        if (!right_controller.TryGetFeatureValue(CommonUsages.primary2DAxis, out var test))
        {
            var inputDevices = new List<InputDevice>();
            InputDevices.GetDevicesAtXRNode(XRNode.RightHand, inputDevices);
            if (inputDevices.Count == 1)
            {
                right_controller = inputDevices[0];
            }
        }

        return right_controller;
    }
    public InputDevice getLeftHand()
    {
        if (!left_controller.TryGetFeatureValue(CommonUsages.primary2DAxis, out var test))
        {
            var inputDevices = new List<InputDevice>();
            InputDevices.GetDevicesAtXRNode(XRNode.LeftHand, inputDevices);
            if (inputDevices.Count == 1)
            {
                left_controller = inputDevices[0];
            }
        }

        return left_controller;
    }
    protected override void CalculateControllers()
    {
        getRightHand();
        getLeftHand();
        CalculateLeftController();
        CalculateRightController();
    }
}
