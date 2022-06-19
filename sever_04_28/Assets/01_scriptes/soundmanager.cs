using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundmanager : MonoBehaviour
{
   [SerializeField]private AudioSource music;
   [SerializeField]private AudioSource enemys;
   [SerializeField]private AudioSource player;
   public void setsound(float Volume)
   {
    music.volume=Volume;
    enemys.volume=Volume;
    player.volume=Volume;
   }
}
