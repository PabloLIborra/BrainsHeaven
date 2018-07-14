using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using System.Collections.Generic;

public class MusicManager : MonoBehaviour {

	//Audio lists and counters
	public AudioClip[] corrects; 	//Effect sound when you get it right
	public AudioClip[] errors; 		//Effect sound when you get it wrong
	public int effects_index;

	public AudioClip[] music; 		//Music list of elements
	public int music_index;

	//Sound player
	public List<AudioSource> sound_source;
	public AudioSource music_source;


	//Things maybe I won't use
    public AudioMixerSnapshot fade_out_trigger;
    public AudioMixerSnapshot fade_in_trigger;

   
    public float bpm = 140;


	//Transition values
    private float m_TransitionIn;
    private float m_TransitionOut;
    private float m_QuarterNote;

    // Use this for initialization
    void Start () 
    {
		//List indexes
		effects_index   = 0;
		
		//Add audio sources
		GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
		for(int i = 0; i < corrects.Length; i++)
		{
			AudioSource a  = camera.AddComponent<AudioSource>();
			sound_source.Add(a);
		}

		//Variables maybe we won't use
        m_QuarterNote = 60 / bpm;
        m_TransitionIn = m_QuarterNote;
        m_TransitionOut = m_QuarterNote * 32;

    }

	//Play correct sound
    public void PlayCorrect()
    {
		//Play clip
		sound_source[effects_index].clip = corrects[effects_index];
		sound_source[effects_index].Play();

		//Increment index
		effects_index++;
		if(effects_index >= corrects.Length)
			effects_index = 0;

    }

	//Play error sound
	public void PlayError()
	{
		//Play clip
		sound_source[effects_index].clip = errors[effects_index];
		sound_source[effects_index].Play();

		//Increment index
		effects_index++;
		if(effects_index >= errors.Length)
			effects_index = 0;
	}

	public void PlayMusicRandom()
	{
		//Play music clip
		int index = Random.Range(0, music.Length);
		music_source.clip = music[index];
		music_source.loop = true;
		music_source.Play();
	}

	public void PlayMusic()
	{
		//Play music clip
		music_source.clip = music[music_index];
		music_source.loop = true;
		music_source.Play();
	}


}