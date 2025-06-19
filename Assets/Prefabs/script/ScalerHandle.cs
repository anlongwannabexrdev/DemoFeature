using UnityEngine;
using UnityEngine.XR;

public class ScalerHandleLR : MonoBehaviour
{
    public XRNode leftHandNode = XRNode.LeftHand;
    public XRNode rightHandNode = XRNode.RightHand;

    private bool isScaling = false;
    private float initialDistance;
    private Vector3 initialScale;

    void Update()
    {
        if (TryGetHandPosition(leftHandNode, out Vector3 leftPos) &&
            TryGetHandPosition(rightHandNode, out Vector3 rightPos))
        {
            float currentDistance = Vector3.Distance(leftPos, rightPos);

            if (!isScaling)
            {
                isScaling = true;
                initialDistance = currentDistance;
                initialScale = transform.localScale;
            }
            else
            {
                float scaleRatio = currentDistance / initialDistance;
                transform.localScale = initialScale * scaleRatio;
            }
        }
        else
        {
            isScaling = false;
        }
    }

    private bool TryGetHandPosition(XRNode node, out Vector3 position)
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(node);
        return device.TryGetFeatureValue(CommonUsages.devicePosition, out position);
    }
}
