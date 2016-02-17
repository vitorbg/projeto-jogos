using UnityEngine;
using System.Collections;
public enum soundFX
{
    JUMP,
    OPEN,
    LAUGTH
}


public class SoundController : MonoBehaviour {

    public AudioClip jump;
    public AudioClip open;
    public AudioClip laugth;
    public static SoundController instance;
    private AudioSource Audio;


    // Use this for initialization
    void Start()
    {
        Audio = GetComponent<AudioSource>();
        instance = this;
    }

    public static void playSound(soundFX currentSound)
    {

        switch (currentSound)
        {
            case soundFX.JUMP:
                instance.Audio.PlayOneShot(instance.jump);
                break;
            case soundFX.OPEN:
                instance.Audio.PlayOneShot(instance.open);
                break;
            case soundFX.LAUGTH:
                instance.Audio.PlayOneShot(instance.laugth);
                break;
        }



    }
}
