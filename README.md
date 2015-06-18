# MediaKeyRelay

## What is this?

  Have you ever wanted to pause/play/ff/rewind your music player while ingame? 
  Ever wondered why those nice media buttons never worked? 
  Well so have I. While I'm not entirely sure why it doesn't work, I have good news! This app is for you!
  
## How's it work?

  When the app starts a low level keyboard hook is activated. This allows the app to capture keystrokes regardless of what app you are currently using. If this sounds like a keylogger, well it is!
  
  Don't worry though, as the app only captures default media keys like Play/Pause, fast forward and rewind. You can even control the volume if you have the controls on your keyboard.
  
## Features

  * Can refire media events when using non fullscreen/directx apps. (Keyboard Events)
  * You can fire media events to supported media players by checking the corresponding app and configuring the appropriate settings.
  * Media players are connected to over their web interfaces. I simply send a POST request in order to bypass the whole signalling issue.
  * So far only MPC-HC and VLC are supported fully.
  
## TODO

  * Startup minimized
  * Add app icon
  * Make it look a bit nicer
