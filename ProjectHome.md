PuTTY Tunnel Manager allows you to easily open tunnels, that are defined in a PuTTY session, from the system tray. You can also move the tunnels from PuTTY to PuTTY Tunnel Manager. This allows you to use PuTTY just for SSH shell sessions (without opening tunnels), and use PuTTY Tunnel Manager just for tunneling.

## Features ##

  * Created specifically for tunneling over SSH sessions
  * Open and close sessions from the system tray
  * Works alongside PuTTY and Pageant, using Plink
  * Easily add and remove tunnels from existing PuTTY sessions
  * Can store tunnels outside the regular PuTTY sessions
  * Keep track of open tunnels and prevent multiple tunnels from listening on the same port
  * Reconnects when your PC wakes up from stand-by
  * Simple interface
  * One file, small size, with a cool icon

## Screenshots ##

![http://putty-tunnel-manager.googlecode.com/files/tunneloverview.png](http://putty-tunnel-manager.googlecode.com/files/tunneloverview.png)
![http://putty-tunnel-manager.googlecode.com/files/traymenu.png](http://putty-tunnel-manager.googlecode.com/files/traymenu.png)

## Download and installation ##

Like PuTTY, this program is just a single executable file. You will need [Microsoft's .NET Framework version 2 or higher](http://www.microsoft.com/NET/) to start it but you'll probably have it already.

  1. Download the latest version from [this page](http://code.google.com/p/putty-tunnel-manager/) and place it in your PuTTY directory, or any other directory.
  1. Download Plink (_plink.exe_) from [here](http://www.chiark.greenend.org.uk/~sgtatham/putty/download.html) and place it in the same directory.
  1. Start PuTTY Tunnel Manager (_ptman.exe_).
  1. If you put _ptman.exe_ and _plink.exe_ in the same directory, you're ready to go. If not, the settings window will show and you should point to _plink.exe_ yourself.

See the [Quick guide](QuickGuide.md) to get started.

I also recommend to use Pageant for public key authentication (read: no passwords and even more secure). See the [Using pageant](UsingPageant.md) section for a short explanation.