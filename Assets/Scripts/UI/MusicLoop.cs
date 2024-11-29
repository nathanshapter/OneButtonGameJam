using UnityEngine;

public class MusicLoop : MonoBehaviour
{
    public AudioSource source;
    public AudioClip loop;


    private void Start()
    {
        source.Play();
    }
}
