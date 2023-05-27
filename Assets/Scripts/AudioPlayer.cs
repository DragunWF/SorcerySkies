using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class AudioPlayer : MonoBehaviour
{
    private Dictionary<string, AudioClip> clips = new Dictionary<string, AudioClip>();
    private Dictionary<string, float> volumes = new Dictionary<string, float>();

    #region Play Audio File Methods

    public void PlayDeath() => PlayClip("Death");
    public void PlayJump() => PlayClip("Jump");
    public void PlayPickup() => PlayClip("Pickup");
    public void PlayDamage() => PlayClip("Damage");

    #endregion

    private void Awake()
    {
        clips.Add("Death", Resources.Load("Audio/Shoot") as AudioClip);
        volumes.Add("Death", 0.75f);

        clips.Add("Jump", Resources.Load("Audio/Jump") as AudioClip);
        volumes.Add("Jump", 0.35f);

        clips.Add("Pickup", Resources.Load("Audio/Pickup") as AudioClip);
        volumes.Add("Pickup", 0.75f);

        clips.Add("Damage", Resources.Load("Audio/Damage") as AudioClip);
        volumes.Add("Damage", 0.55f);
    }

    private void PlayClip(string fileName)
    {
        if (clips[fileName] != null)
        {
            Vector2 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clips[fileName], cameraPos, volumes[fileName]);
        }
    }
}