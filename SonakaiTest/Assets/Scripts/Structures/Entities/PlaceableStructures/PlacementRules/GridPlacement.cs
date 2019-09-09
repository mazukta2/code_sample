using System;
using UnityEngine;

public class GridPlacement : PlacementRule
{
    [SerializeField] private LayerMask _supportLayerMask;
    [SerializeField] private Vector3 _raycastOffset;
    [SerializeField] private float _raycastDistance = 0.2f;
    [SerializeField] private Vector3 _gridSize = Vector3.one;

    public override void SetPreferredPosition(Vector3 position)
    {
        Func<float, float, float> convert = ((value, size) =>
                Mathf.RoundToInt(value / size) * size);

        transform.position = new Vector3(convert(position.x, _gridSize.x),
            convert(position.y, _gridSize.y),
            convert(position.z, _gridSize.z));

        IsValid = IsValidRaycast(transform.position);
    }

    public override void Rotate()
    {
        transform.rotation *= Quaternion.Euler(0, 90, 0);
    }

    private bool IsValidRaycast(Vector3 position)
    {
        RaycastHit hit;
        if (Physics.Raycast(position + _raycastOffset,
            Vector3.down,
            out hit, _raycastDistance, _supportLayerMask))
        {
            return true;
        }

        return false;
    }
}
