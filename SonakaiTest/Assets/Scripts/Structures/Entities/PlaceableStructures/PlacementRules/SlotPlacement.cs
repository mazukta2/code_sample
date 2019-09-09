using System;
using UnityEngine;

public class SlotPlacement : PlacementRule
{
    [SerializeField] private LayerMask _slotLayerMask;
    [SerializeField] private bool _isCanBeRotated;

    private Quaternion _additionalRotation = Quaternion.identity;

    public override void SetPreferredPosition(Vector3 position)
    {
        var hit = RaycastSlot(position);
        IsValid = (hit != null);

        if (IsValid)
        {
            transform.position = hit.Value.collider.gameObject.transform.position;
            transform.rotation = hit.Value.collider.gameObject.transform.rotation * _additionalRotation;
        }
    }

    public override void Rotate()
    {
        if (!_isCanBeRotated)
            return;

        var rotation = Quaternion.Euler(0, 90, 0);
        _additionalRotation *= rotation;
        transform.rotation *= rotation;
    }

    private RaycastHit? RaycastSlot(Vector3 cursorWorldPosition)
    {
        var cameraDirection = Camera.main.transform.position - cursorWorldPosition;
        RaycastHit hit;
        if (Physics.Raycast(cursorWorldPosition,
            cameraDirection,
            out hit, cameraDirection.magnitude, _slotLayerMask))
        {
            return hit;
        }

        return null;
    }
}
