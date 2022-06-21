using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundmanager : MonoBehaviour
{
   [SerializeField]private AudioSource music;
   [SerializeField]private AudioSource enemys;
   [SerializeField]private AudioSource player;
  
   public void setsound(float Volume1)
   {
  
    music.volume=Volume1;
    enemys.volume=Volume1;
    player.volume=Volume1;
  
   }

}
