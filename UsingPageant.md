## Introduction ##

In this section I'll shortly explain how to set up and use public key authentication for PuTTY. Of course, this also works for PuTTY Tunnel Manager. If you're interested in all the details, see the [PuTTY documentation](http://the.earth.li/~sgtatham/putty/0.60/htmldoc/Chapter8.html).

Public key authentication is an alternative means of identifying yourself to a login server, instead of typing a password. It is more secure and more flexible, but more difficult to set up.

The advantages are thus:
  * No need to remember or use usernames and passwords for all your SSH sessions.
  * More secure authentication

## Getting started ##

  1. Download Pageant (_pageant.exe_) and PuTTYgen (_puttygen.exe_) from [here](http://www.chiark.greenend.org.uk/~sgtatham/putty/download.html) and place it in some directory (can be the same directory as where PuTTY Tunnel Manager resides).
  1. I assume you have PuTTY, if not, get it as well.

## Creating a public and private key ##

  1. Start PuTTYgen (_puttygen.exe_).
  1. Click _Generate_ and move the mouse over the blank area as indicated.
  1. Type in a password at _Key passphrase_ (this is the only password you need to remember).
  1. Type it again at _Confirm passphrase_.
  1. Click _Save public key_ and save it as "public\_key.ppk" in your home directory.
  1. Click _Save private key_ and save it as "private\_key.ppk" in your home directory.
  1. Select the complete random text at the top (starting with "ssh-rsa") and copy it into a new text file.
  1. Save the text file as "public\_key\_for\_authorized\_keys.txt" (leave this file open for now).

Your public key can be given to anyone, or to every server. However, never, ever, give out your private key!

## Adding your public key to a server ##

  1. Start PuTTY (_putty.exe_).
  1. Open a session to your desired server (that has tunnels, so you can use it with PuTTY Tunnel Manager) as usual and login.
  1. Type in the following commands:
```
mkdir .ssh
vi .ssh/authorized_keys
```
You just created a directory and opened up an editor.

  1. Copy the contents of the "public\_key\_for\_authorized\_keys.txt" file (that you left open earlier) and paste it into the editor.
  1. Save it by hitting the Esc-key and type ":wq" (without the quotes but with the colon) followed by Enter.
  1. Type in the following command:
```
chmod -R 600 .ssh
exit
```
This secured the just created file and closes the session.

**Tip**: You can do these steps for all servers you have in your session list.

## Using public key authentication ##

  1. Start Pageant (_pageant.exe_).
  1. On the system tray, right click the Pageant icon, and click _Add Key_.
  1. Locate your private key (_private\_key.ppk_) and open it.
  1. Type in your password for the key.

**Tip**: If you use PuTTY or PuTTY Tunnel Manager often, create a shortcut to Pageant followed by the location of your private key (ie. "C:\Program Files\PuTTY\pageant.exe" "%USERPROFILE%\private\_key.ppk"). Place this shotcut in the _Startup_ folder of your Start menu to have it start every time when Windows starts.

  1. Start PuTTY Tunnel Manager (_ptman.exe_).
  1. On the system tray, right click the icon and open the session that you copied your public key to.

You should no longer be asked for any password.