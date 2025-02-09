﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TruongNT;
using UnityEngine;
using UnityEngine.Audio;
using Random = UnityEngine.Random;

public class SoundManager : MonoBehaviour
{
    #region Instance
    private static SoundManager instance;
    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SoundManager>();
                if (instance == null)
                {
                    instance = Instantiate(Resources.Load<SoundManager>("SoundManager"));
                }
            }
            return instance;
        }
    }

    public static void LoadAsysn()
    {
        if (instance != null)
            return;
        Tools.LoadResourceAsyn<SoundManager>(delegate (ResourceRequest request)
        {
            instance = Instantiate(request.asset as SoundManager);
            //instance.PlayHomeMusic();
        });
    }
    public static bool Exist => instance != null;

    #endregion

    #region Inspector Variables

    public AudioSource music;
    public AudioMixer mixer;
    public AudioMixerGroup musicGroup, sfxGroup, voiceGroup;
    public SortedList<int, AudioSource> playingSound;
    public SortedList<int, LoopSoundRequest> loopSound;
    public SortedList<int, AudioSource> voiceSound;
    public AudioClip[] gameMusics;
    public AudioClip[] homeMusics;
    public AudioClip clickSound, failClickSound;
    public AudioClip popupOpenSfx, popupCloseSfx;

    #endregion;

    #region Unity Methods

    private void Awake()
    {
        if (FindObjectsOfType(typeof(SoundManager)).Length > 1)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        //   DontDestroyOnLoad(this.gameObject);


    }

    private void Start()
    {
        playingSound = new SortedList<int, AudioSource>();
        loopSound = new SortedList<int, LoopSoundRequest>();
        voiceSound = new SortedList<int, AudioSource>();

        //if (PlayerPrefs.GetInt(Const.FIRST_TIME_OPEN) == 0)
        //{
        //    PlayerPrefs.SetInt(Const.FIRST_TIME_OPEN, 1);
        //    PlayerPrefs.SetFloat(Const.MUSIC_VALUE, 10f);
        //    PlayerPrefs.SetFloat(Const.SOUND_VALUE, -10.65f);
        //    PlayerPrefs.SetFloat(Const.VOICE_OVER_VALUE, 2);
        //}

        ////mixer.SetFloat("music", PlayerPrefs.GetFloat(Const.MUSIC_VALUE));
        ////mixer.SetFloat("sfx", PlayerPrefs.GetFloat(Const.SOUND_VALUE));
        ////mixer.SetFloat("voice", PlayerPrefs.GetFloat(Const.VOICE_OVER_VALUE));
        //if (SettingData.Instance.MUSIC)
        //{
        //    TurnOnMusic("music");
        //}
        //else
        //{
        //    TurnOff("music");
        //}

        //if (SettingData.Instance.SOUND)
        //{
        //    TurnOnSound("sfx");
        //}
        //else
        //{
        //    TurnOff("sfx");
        //}
    }

    //void HandlePopupClose(PopupSystem.BasePopup p)
    //{
    //    PlaySfxOverride(popupCloseSfx);
    //}

    //public void HandlePopupOpen(PopupSystem.BasePopup p)
    //{
    //    PlaySfxOverride(popupOpenSfx);
    //}

    void HandlePressButton(object ob1, object ob2)
    {
        PlayUIButtonClick();
    }

    #endregion;

    #region Public Methods

    public AudioSource AddAudioSource(AudioClip sfx, bool isSFX = true)
    {
        AudioSource ac = (AudioSource)gameObject.AddComponent(typeof(AudioSource));
        ac.outputAudioMixerGroup = isSFX ? sfxGroup : musicGroup;
        ac.loop = false;
        ac.playOnAwake = false;
        ac.clip = sfx;
        playingSound.Add(sfx.GetInstanceID(), ac);
        return ac;
    }

    public LoopSoundRequest AddLoopSoundRequest(AudioClip sfx, int requesterId, bool isSFX = true)
    {
        AudioSource ac = (AudioSource)gameObject.AddComponent(typeof(AudioSource));
        ac.outputAudioMixerGroup = isSFX ? sfxGroup : musicGroup;
        ac.loop = true;
        ac.playOnAwake = true;
        ac.clip = sfx;
        LoopSoundRequest r = new LoopSoundRequest();
        r.source = ac;
        r.requester = requesterId;
        loopSound.Add(sfx.GetInstanceID(), r);
        return r;
    }

    public void PlayVoiceRewind(AudioClip voice)
    {
        if (voice == null)
            return;
        int id = voice.GetInstanceID();
        if (voiceSound.ContainsKey(id))
        {
            voiceSound[id].Stop();
            voiceSound[id].Play();
        }
        else
        {
            AudioSource ac = (AudioSource)gameObject.AddComponent(typeof(AudioSource));
            ac.outputAudioMixerGroup = voiceGroup;
            ac.loop = false;
            ac.playOnAwake = false;
            ac.clip = voice;
            voiceSound.Add(voice.GetInstanceID(), ac);
            ac.Play();
        }
    }

    /// <summary>
    /// stop the sfx and replay it
    /// </summary>
    public void PlaySfxRewind(AudioClip sfx)
    {
        if (sfx == null || playingSound == null)
            return;
        int id = sfx.GetInstanceID();
        if (playingSound.ContainsKey(id))
        {
            playingSound[id].Stop();
            playingSound[id].Play();
        }
        else
        {
            AddAudioSource(sfx).Play();
        }
    }

    /// <summary>
    /// Play the sfx if it is not being played at the moment 
    /// </summary>
    public void PlaySfxNoRewind(AudioClip sfx)
    {
        if (sfx == null || playingSound == null)
            return;
        int id = sfx.GetInstanceID();
        if (playingSound.ContainsKey(id))
        {
            if (!playingSound[id].isPlaying)
                playingSound[id].Play();
        }
        else
        {
            AddAudioSource(sfx).Play();
        }
    }

    /// <summary>
    /// play the sfx one more no matter it is playing or not
    /// </summary>
    public void PlaySfxOverride(AudioClip sfx)
    {
        if (sfx == null || playingSound == null)
            return;
        int id = sfx.GetInstanceID();
        if (playingSound.ContainsKey(id))
        {
            playingSound[id].PlayOneShot(sfx);
        }
        else
        {
            AddAudioSource(sfx).Play();
        }
    }

    public void PlaySfxLoop(AudioClip sfx, int requesterId)
    {
        if (sfx == null || playingSound == null)
            return;
        int id = sfx.GetInstanceID();
        if (loopSound.ContainsKey(id))
        {
            loopSound[id].requester = requesterId;
            if (!loopSound[id].source.isPlaying)
                loopSound[id].source.Play();
        }
        else
        {
            AddLoopSoundRequest(sfx, requesterId).source.Play();
        }
    }

    public bool StopLoopSound(AudioClip sfx, int requesterId)
    {
        if (sfx == null || playingSound == null)
            return false;
        int id = sfx.GetInstanceID();
        if (loopSound.ContainsKey(id))
        {
            LoopSoundRequest lsr = loopSound[id];
            if (lsr.requester == requesterId)
            {
                lsr.source.Stop();
                return true;
            }
            else
                return false;
        }
        else
            return false;
    }


    public void TurnOff(string soundType)
    {
        mixer.SetFloat(soundType, -80);
    }

    public void TurnOnMusic(string soundType)
    {
        mixer.SetFloat(soundType, 10f);

    }

    public void TurnOnSound(string soundType)
    {
        mixer.SetFloat(soundType, -10.65f);

    }

    public void PlayGameMusic()
    {
        if (autoTask != null)
            StopCoroutine(autoTask);
        if (music.isPlaying)
            music.Stop();
        music.clip = gameMusics[0];
        music.Play();
        music.loop = true;
    }

    public void PlayHomeMusic()
    {
        if (autoTask != null)
            StopCoroutine(autoTask);
        if (music.isPlaying)
            music.Stop();
        music.clip = gameMusics[0];
        music.Play();
        music.loop = true;
        //  Debug.Log("PlaygHomeMusic");
    }

    Coroutine autoTask;
    public void PlayGameMusicInList(int _id = -1)
    {
        if (autoTask != null)
            StopCoroutine(autoTask);
        if (music.isPlaying)
            music.Stop();
        if (_id == -1)
            _id = Random.Range(0, gameMusics.Length);
        else
        {
            if (_id >= gameMusics.Length)
                _id = 0;
        }
        music.clip = gameMusics[_id];
        music.Play();
        autoTask = StartCoroutine(AutoNextSong(_id + 1, music.clip.length + 0.3f));
    }

    private IEnumerator AutoNextSong(int id, float delay)
    {
        yield return new WaitForSeconds(delay);
        PlayGameMusicInList(id);
    }

    public void PlayUIButtonClick()
    {
        PlaySfxRewind(clickSound);
    }

    public void PlayUIButtonFail()
    {
        PlaySfxRewind(failClickSound);
    }

    public void PlayVibrate(long milliseconds)
    {
        if (!SettingData.Instance.VIBRATE) return;
        Debug.LogError($"Vibrate");
        VibrationManager.Vibrate(milliseconds);
    }

    public void MusicHandle(bool value)
    {

        if (value)
        {
            TurnOnMusic("music");
        }
        else
        {
            TurnOff("music");
        }
    }

    public void SoundHandle(bool value)
    {

        if (value)
        {
            TurnOnSound("sfx");
        }
        else
        {
            TurnOff("sfx");
        }
    }

    public void VibrateHandle(bool value)
    {
        if (value)
        {
            Handheld.Vibrate();
        }
        else
        {
            return;
        }
    }
    #endregion;

}

public class LoopSoundRequest
{
    public AudioSource source;
    public int requester;
}

/// <summary>
/// the way the sound fx is played
/// </summary>
public enum SFX_PLAY_STYLE
{
    /// <summary>
    /// restart the sound
    /// </summary>
    REWIND,
    /// <summary>
    /// if the same sound is playing, dont play this one
    /// </summary>
    DONT_REWIND,
    /// <summary>
    /// always play the sound
    /// </summary>
    OVERRIDE,
    NONE
}
