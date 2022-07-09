using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
   [SerializeField] private Canvas gameOverCanvas;
   private WeaponSwitcher weaponSwitcher;

   private void Start()
   {
      gameOverCanvas.enabled = false;
      weaponSwitcher = FindObjectOfType<WeaponSwitcher>();
   }

   public void HandleDeath()
   {
      gameOverCanvas.enabled = true;
      Time.timeScale = 0;
      weaponSwitcher.enabled = false;
      Cursor.lockState = CursorLockMode.None;
      Cursor.visible = true;
   }
}
