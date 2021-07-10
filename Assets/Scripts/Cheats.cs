using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheats : MonoBehaviour
{
private string[] speedy;
private string[] slowmo;
private string[] spooky;
private string[] nevermind;

private int speedyIndex;
private int slowmoIndex;
private int spookyIndex;
private int nevermindIndex;

public AudioSource source;
public AudioClip clip;
         
 void Start() {
     // User needs to input this in the right order
     speedy = new string[] { "s", "p", "e", "e", "d", "y" };
     slowmo = new string[] { "s", "l", "o", "w", "m", "o" };
     nevermind = new string[] { "n", "e", "v", "e", "r", "m", "i", "n", "d" };
     spooky = new string[] { "s", "p", "o", "o", "k", "y" };
     speedyIndex = 0;    
     slowmoIndex = 0;
     spookyIndex = 0;
     nevermindIndex = 0;
 }
 
 void Update() {
     CheatSlow();
     CheatSpeed();
     CheatGhost();
     CheatOff();
 }
void CheatSlow()
{
    // Check if any key is pressed
     if (Input.anyKeyDown) {
         // Check if the next key in the code is pressed
         if (Input.GetKeyDown(slowmo[slowmoIndex])) {
             // Add 1 to index to check the next key in the code
             slowmoIndex++;
         }
         // Wrong key entered, we reset code typing
         else {
             slowmoIndex = 0;    
         }
     }
     
     // If index reaches the length of the cheatCode string, 
     // the entire code was correctly entered
     if (slowmoIndex == slowmo.Length) {
         // Cheat code successfully inputted!
         // Unlock crazy cheat code stuff
         source.PlayOneShot(clip, 0.2f);
         Time.timeScale = 0.3f;
         slowmoIndex = 0;
     }
}

void CheatSpeed()
{
    // Check if any key is pressed
     if (Input.anyKeyDown) {
         // Check if the next key in the code is pressed
         if (Input.GetKeyDown(speedy[speedyIndex])) {
             // Add 1 to index to check the next key in the code
             speedyIndex++;
         }
         // Wrong key entered, we reset code typing
         else {
             speedyIndex = 0;    
         }
     }
     
     // If index reaches the length of the cheatCode string, 
     // the entire code was correctly entered
     if (speedyIndex == speedy.Length) {
         // Cheat code successfully inputted!
         // Unlock crazy cheat code stuff
         source.PlayOneShot(clip, 0.2f);
         Mover.moveSpeed = Mover.fastSpeed;
         speedyIndex = 0;
     }
}

void CheatGhost()
{
    // Check if any key is pressed
     if (Input.anyKeyDown) {
         // Check if the next key in the code is pressed
         if (Input.GetKeyDown(spooky[spookyIndex])) {
             // Add 1 to index to check the next key in the code
             spookyIndex++;
         }
         // Wrong key entered, we reset code typing
         else {
             spookyIndex = 0;    
         }
     }
     
     // If index reaches the length of the cheatCode string, 
     // the entire code was correctly entered
     if (spookyIndex == spooky.Length) {
         // Cheat code successfully inputted!
         // Unlock crazy cheat code stuff
         source.PlayOneShot(clip, 0.2f);
         Ghost.ghostMode = true;
         spookyIndex = 0;
     }
}

void CheatOff()
{
    // Check if any key is pressed
     if (Input.anyKeyDown) {
         // Check if the next key in the code is pressed
         if (Input.GetKeyDown(nevermind[nevermindIndex])) {
             // Add 1 to index to check the next key in the code
             nevermindIndex++;
         }
         // Wrong key entered, we reset code typing
         else {
             nevermindIndex = 0;    
         }
     }
     
     // If index reaches the length of the cheatCode string, 
     // the entire code was correctly entered
     if (nevermindIndex == nevermind.Length) {
         // Cheat code successfully inputted!
         // Unlock crazy cheat code stuff
         source.PlayOneShot(clip, 0.2f);
         Mover.moveSpeed = Mover.normalSpeed;
         Time.timeScale = 1;
         Ghost.ghostMode = false;
         nevermindIndex = 0;
     }
}

}
