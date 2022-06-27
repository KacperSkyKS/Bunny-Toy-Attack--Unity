# Bunny-Toy-Attack--Unity
You can test the game here:<br/>
https://kacpersky.itch.io/plush-toy-attack<br/>

You can watch the gameplay here:<br/>
https://www.youtube.com/watch?v=SAWowrbW2X0<br/>
<br/>
This is my first Unity project which started my adventure with Unity.<br/>
This is a wave survival game.<br/>
The player protects himself as much as he can from the waves of husk rabbits with hammers.<br/>
The game perspective is first-person.<br/>
<br/>
Written scripts are located under the path:<br/>
Assets > Scripts <br/>
<br/>
Features list(including scripts responsible for the operation of this features):<br/>
- **Walk**<br/>
  - Standard movement with WSAD and camera rotation with the mouse<br/>
  - Scripts: 
    - [PlayerRotate.cs](https://github.com/KacperSkyKS/Bunny-Toy-Attack--Unity/blob/main/Assets/Scripts/PlayerRotate.cs) 
    - [Klawiatura.cs](https://github.com/KacperSkyKS/Bunny-Toy-Attack--Unity/blob/main/Assets/Scripts/Klawiatura.cs)
- **Jump**<br/>
  - Scripts: 
    - [Klawiatura.cs](https://github.com/KacperSkyKS/Bunny-Toy-Attack--Unity/blob/main/Assets/Scripts/Klawiatura.cs)
- **Shooting (Raycast)**<br/>
  - Shooting with raycast. At the end of the shot, an explosion is created that tells you where the shot was shot.  <br/>
  - If an enemy is hit, it takes damage. <br/>
  - Scripts: 
    - [Promien.cs](https://github.com/KacperSkyKS/Bunny-Toy-Attack--Unity/blob/main/Assets/Scripts/Promien.cs)<br/>
- **Wave system**<br/>
  - You can start waves by pressing the "L" button as well as stop the next wave from appearing. 
  - Scripts: 
    - [Kontroler.cs](https://github.com/KacperSkyKS/Bunny-Toy-Attack--Unity/blob/main/Assets/Scripts/Kontroler.cs)<br/>
- **AI enemies that has:** <br/>
  - Follow the player.<br/>
  - Attack at the right distance. <br/>
  - Acceleration after corresponding health decline. <br/>
  - Coins dropped after death. <br/>
  - Scripts: 
    - [AI_KROLIK.cs](https://github.com/KacperSkyKS/Bunny-Toy-Attack--Unity/blob/main/Assets/Scripts/AI_KROLIK.cs)<br/>
    - [CelReaktywny.cs](https://github.com/KacperSkyKS/Bunny-Toy-Attack--Unity/blob/main/Assets/Scripts/CelReaktywny.cs)<br/>
- **Improvable player stats:**
  - Scripts: 
    - [PlayerManager.cs](https://github.com/KacperSkyKS/Bunny-Toy-Attack--Unity/blob/main/Assets/Scripts/PlayerManager.cs)<br/>
    - [DaneGracza.cs](https://github.com/KacperSkyKS/Bunny-Toy-Attack--Unity/blob/main/Assets/Scripts/DaneGracza.cs)<br/>
- **System of upgrading statistics** <br/>
  - Possibility to upgrade stats such as: <br/>
    - Health
    - Damage
    - Attack speed
    - Movement speed
  - Scripts: 
    - [UpgradePanelUI.cs](https://github.com/KacperSkyKS/Bunny-Toy-Attack--Unity/blob/main/Assets/Scripts/UpgradePanelUI.cs)<br/> 
- **Equipment**<br/>
  - Coins.<br/>
  - Scripts: 
    - [InventoryManager.cs](https://github.com/KacperSkyKS/Bunny-Toy-Attack--Unity/blob/main/Assets/Scripts/InventoryManager.cs)<br/>
- **An interactive door that opens when the player approaches if the waves are not turned on and the wave is not currently in progress.** <br/>
  - Scripts: 
    - [DeviceTrigger.cs](https://github.com/KacperSkyKS/Bunny-Toy-Attack--Unity/blob/main/Assets/Scripts/DeviceTrigger.cs)<br/> 
    - [DoorOpenDevice.cs](https://github.com/KacperSkyKS/Bunny-Toy-Attack--Unity/blob/main/Assets/Scripts/DoorOpenDevice.cs)<br/> 
- **Interactive buttons in the Main Menu and the Game Over screen**<br/>
  - Scripts:
    - [MainMenu.cs](https://github.com/KacperSkyKS/Bunny-Toy-Attack--Unity/blob/main/Assets/Scripts/MainMenu.cs)<br/> 
    - [EventButtons.cs](https://github.com/KacperSkyKS/Bunny-Toy-Attack--Unity/blob/main/Assets/Scripts/EventButtons.cs)<br/> 
<br/>

