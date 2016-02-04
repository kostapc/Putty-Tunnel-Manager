PuTTY Tunnel Manager was created for people that are already using PuTTY for their SSH sessions and want easier access to PuTTY's tunnels. PuTTY itself is not required. PuTTY Tunnel Manager simply uses the same location to store sessions, so you don't have to add all your hosts twice.

### Download and installation ###

See the [main page](http://code.google.com/p/putty-tunnel-manager/#Download_and_installation).

### Sessions ###

A session is simply a destination host and some settings. For example: you have a development and a production server. You typically create a session for both of them.

**Adding a session**

  1. Right click the PuTTY Tunnel Manager icon in your system tray
  1. Click on _Settings..._, and the settings window will show
  1. Click on _Add_, and a new window will open
  1. Fill in the _Session name_ (ie. Development server), _Hostname_ (ie. example.com) and _Port_ (ie. 22)
  1. Click _OK_ and the session will be created

![http://putty-tunnel-manager.googlecode.com/files/settings.png](http://putty-tunnel-manager.googlecode.com/files/settings.png)

### Tunnels ###

A tunnel (in this case) is an encrypted tunnel, created over an existing SSH connection, to securely route traffic from one machine to another. For example: your development server has a MySQL database on port 3306 but only allows connections from the local host. You can open an SSH session to the development server, and open a tunnel that routes all traffic from your computer on, let's say, port 3307 to the development server on port 3306.

**Adding a tunnel**

  1. In the settings window, select a session
  1. Below that, click on the _Local ports_ tab and click _Add_
  1. Fill in the _Local port_ (ie. 3307), _Remote host_ (ie. localhost), _Remote port_ (ie. 3306)
  1. Click _OK_ and the tunnel will be added to the selected session

### Starting and closing sessions ###

**Opening a session and its tunnels**

  1. Right click the PuTTY Tunnel Manager icon in your system tray
  1. Click on _Tunnels >_ and select a session (ie. Development server)

![http://putty-tunnel-manager.googlecode.com/files/traymenu.png](http://putty-tunnel-manager.googlecode.com/files/traymenu.png)

**Show which sessions and tunnels are open**

  1. Left click the PuTTY Tunnel Manager icon in your system tray
  1. Click anywhere else to close it again

![http://putty-tunnel-manager.googlecode.com/files/tunneloverview.png](http://putty-tunnel-manager.googlecode.com/files/tunneloverview.png)

Now you can easily start your favorite database manager and connect to localhost:3307 to connect to the development server's MySQL database.

**Closing a session and its tunnels**

  1. Right click the PuTTY Tunnel Manager icon in your system tray
  1. Click on _Tunnels >_ and select checked session to close it