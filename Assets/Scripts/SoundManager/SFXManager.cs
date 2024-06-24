// SFXManager.cs - Manages playing different soundeffects in the game.

using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] private AudioClip shootSound;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip menuSound;
    [SerializeField] private AudioClip matchingSound;
    [SerializeField] private AudioClip noAmmoSound;
    [SerializeField] private AudioClip stepsSound;

    private bool isActive = true; // Flag to control whether sound effects are active.

    // Triggered when the Player enters a trigger collider.
    private void OnTriggerEnter(Collider shots)
    {
        // Check if the object that entered the trigger is the player.
        if (shots.gameObject.CompareTag("Shots"))
        {
            // Check if the collect sound is assigned and if sound effects are active.
            if (shootSound != null && isActive)
            {
                // Play the collect sound at the position of this SFXManager.
                AudioSource.PlayClipAtPoint(shootSound, transform.position);
            }
        }
    }


    // Play the jump sound effect.
    public void PlayJumpSound()
    {
        // Check if the jump sound is assigned and if sound effects are active.
        if (jumpSound != null && isActive)
        {
            // Play the jump sound at the position of this SFXManager.
            AudioSource.PlayClipAtPoint(jumpSound, transform.position);
        }
    }


    // Play the menu sound effect.
    public void PlayMenuSound()
    {
        // Check if the menu sound is assigned and if sound effects are active.
        if (menuSound != null && isActive)
        {
            // Play the menu sound at the position of this SFXManager.
            AudioSource.PlayClipAtPoint(menuSound, transform.position);
        }
    }


    public void PlayMatchingSound()
    {
        // Check if the matching sound is assigned and if sound effects are active.
        if (matchingSound != null && isActive)
        {
            // Play the matching sound at the position of this SFXManager.
            AudioSource.PlayClipAtPoint(matchingSound, transform.position);
        }
    }


    public void PlayNoAmmoSound()
    {
        // Check if the no ammo sound is assigned and if sound effects are active.
        if (noAmmoSound != null && isActive)
        {
            // Play the no ammo sound at the position of this SFXManager.
            AudioSource.PlayClipAtPoint(noAmmoSound, transform.position);
        }
    }   

    public void PlayStepsSound()
    {
        // Check if the steps sound is assigned and if sound effects are active.
        if (stepsSound != null && isActive)
        {
            // Play the steps sound at the position of this SFXManager.
            AudioSource.PlayClipAtPoint(stepsSound, transform.position);
        }
    }

    // Toggle the active state of sound effects.
    public void ToggleActiveState()
    {
        // Invert the value of isActive.
        isActive = !isActive;
    }
}
