using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Papae.UnitySDK.Managers;

public class audio : MonoBehaviour {
	[Header("Main Manu Music")]
	[Range(0,1)]
	public float mvolume;
	[Space(5)]
	public AudioClip main_manu_backgroundmusic;
	[Space(10)]


	[Header("Game Manu Musics")]
	[Range(0,1)]
	public float gvolume;
	[Space(5)]
	public AudioClip game_manu_backgroundmusic;
	[Space(10)]

	[Header("----Impetus----")]
	public AudioClip imp_background01;
	public AudioClip coin;
	public AudioClip hit;
	[Space(10)]

	[Header("----ZigZagTrail----")]
	public AudioClip zz_background01;
	public AudioClip diamond;
	public AudioClip move;
	public AudioClip fall;
	[Space(10)]

	[Header("----Chromatic----")]
	public AudioClip chromatic_background;
	public AudioClip touch;


	public void play_main_manu_background(){
		AudioManager.Instance.MusicVolume = mvolume;
		AudioManager.Instance.PlayBGM (main_manu_backgroundmusic,MusicTransition.Swift,1f);
	}

	public void game_manu_background(){
		AudioManager.Instance.MusicVolume = gvolume;
		AudioManager.Instance.PlayBGM (game_manu_backgroundmusic,MusicTransition.Swift,1f);
	}

	/// <summary>
	///impetus game
	/// </summary>

	public void play_imp_background01(){
		AudioManager.Instance.MusicVolume = gvolume;
		AudioManager.Instance.PlayBGM (imp_background01,MusicTransition.Swift,1f);
	}

	public void play_coin(){
		AudioManager.Instance.PlayOneShot (coin);
	}

	public void play_hit(){
		AudioManager.Instance.PlayOneShot (hit);
		AudioManager.Instance.MusicVolume = 0.5f;
	}

	/// <summary>
	///zigzag trAIL
	/// </summary>


	public void play_zz_background01(){
		AudioManager.Instance.MusicVolume = gvolume;
		AudioManager.Instance.PlayBGM (zz_background01,MusicTransition.Swift,1f);
	}

	public void play_diamond(){
		AudioManager.Instance.PlayOneShot (diamond);
	}

	public void play_move(){
		AudioManager.Instance.MusicVolume = gvolume - 0.3f;
		AudioManager.Instance.PlayOneShot (move);
		AudioManager.Instance.MusicVolume = mvolume;
	}

	public void play_fall(){
		AudioManager.Instance.MusicVolume = gvolume - 0.3f;
	}

	/// <summary>
	///chromatic
	/// </summary>

	public void play_chrom_background01(){
		AudioManager.Instance.MusicVolume = gvolume;
		AudioManager.Instance.PlayBGM (chromatic_background,MusicTransition.Swift,1f);
	}

	public void play_touch_marble(){
		AudioManager.Instance.PlaySFX (touch,0.25f,false,null);
	}
}
