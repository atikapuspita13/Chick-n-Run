using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
public class DrawGizmos : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Color gizmosColor;

    Transform raycastPos;
    float raycastDistance;

    private void Start()
    {
        raycastPos = playerController.GetRaycastPosition();
        raycastDistance = playerController.GetRaycastDistance();
    }

    private void OnDrawGizmos()
    {
        if (UnityEditor.EditorApplication.isPlaying)
        {
            Gizmos.color = gizmosColor;
            Gizmos.DrawLine(raycastPos.position, new Vector3(raycastPos.position.x, raycastPos.position.y, raycastPos.position.z + raycastDistance));
        }
    }
}
#endif