using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    private PlayerController playerController;
    private float footstepTimer;
    private float footstepTimerMax = .1f;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        footstepTimer -= Time.deltaTime;
        if(footstepTimer < 0f)
        {
            footstepTimer = footstepTimerMax;
            if (playerController.IsWalking())
            {
                float volume = 1f;
                SoundManager.Instance.PlayFootstepsSound(playerController.transform.position, volume);
            }
        }
    }
}
