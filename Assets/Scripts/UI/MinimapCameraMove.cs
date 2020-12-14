using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCameraMove : MonoBehaviour
{
    [SerializeField] Player _player;
    private void Update()
    {
        transform.position = _player.transform.position + new Vector3(0, 20, 0);
    }
}
