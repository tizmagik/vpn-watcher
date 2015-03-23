# vpn-watcher
Small Windows utility that watches a VPN network interface and when a disconnect is detected will exit listed applications.


## Planned new features
Here's a short-list of new features I'm looking to add to this project. Collaboration is encouraged -- please feel free to fork and submit a pull-request!

1. Easier VPN network interface selector.
2. Automatically re-open listed applications when the VPN reconnects.


### Original Author
This project is based on the work originally by Freddi -- http://www.freddi.de/


---

The entirety of the original 'readme' is below:

```
VPNWatcher

VPNWatcher is a small tool to make sure that certain programs only
run when you are connected do a VPN. It's designed to quietly run in the background
and only jump into action when you are NOT connected to a VPN and accidently
start e.g. your torrent client.

The configuration is simple:
1. Choose your VPN interface from the list and hit the save button
2. Specify the apps you want to close when you lose your VPN connection
3. Done!

When everything runs fine, click "Start minimzed" and put a link to VPNWatcher
into Windows Autostart. It will start with a small trayicon from now on.

Thats it!


Frequently asked questions

* What language was VPNWatcher coded in?
It's a C# WPF project and requires the .NET Framework 4.0 to run.


* Whats the general workflow of this tool after it is configured?
1. fetch a list of connected interfaces every 2 seconds
2a. if your configured VPN is online: everything is fine, show an ok sign
2b. if not: find the configured apps, close them and show a warning sign 


* I'm afraid it uses too much resources, can I reduce this somehow?
It doesn't, the CPU usage is very small. If neccessary, open up the config file
and increase the timespan between the checks (see "TimerInSeconds" in the config).


* What does the "Interfaces" textbox mean?
If shows all network interfaces that are currently online. If you connect to your
VPN, you will see a new interface popping up in the list.


* Can I see somehow if my textbox entrys are correct?
Yes. After you selected your VPN using the save button, a green "ok" sign will show up.
If you disconnect from your VPN, a red "warning" sign will show.


* I don't know what to insert in the "Apps" textbox.
The names of the applications to kill, without the file ending. For example, open the taskmanager
(CTRL+ALT+DEL, taskmanager) and check the processes tab. uTorrent shows up as "uTorrent.exe *32" or
"uTorrent.exe", so you need to enter "uTorrent" (without the quotes).
One line per application.


* When VPNWatcher is started minimized, how do I open it up again?
Whenever VPNWatcher is minimzed, a trayicon will show. Either doubleclick on it or
rightclick and hit "Open".


* What exactly does "Strict Mode"?
During tests with PPTP vpn networks, we found out that these networks might behave differently than
OpenVPN networks: They don't necessarily get a "down" status when disconnected, they comepletely vanish!
So "Strict Mode" makes VPNWatcher not only check for "down" networks, but also networks which are not
present any more.


* What do the config settings mean exactly?
TimerInSeconds: Checks every x seconds for a network change (default: 2)
ChosenActionIndex: The "App Action" selection. Leave it for 0 at the moment, might be extended in the future
ConsoleMaxSize: Wipes the "Log" textbox every X characters (default: 10000)
Applications: List of applications you want to kill when the VPN connection drops, separated with a #
IgnoreIPV6: I might add IPV6 support in the future, at the moment this does nothing
StartMinimized: Start with only the trayicon showing (default: false)
VPNInterfaceID: Internal ID of the interface you selected
VPNInterfaceName: Name of the interface you selected as displayed in the line below the interface list
DebugMode: If set to "true", spams massive logs into the Log textbox and also copies everything
           into the clipboard when you exit the application (so you can easily send me logs in case
           you need help).
StrictInterfaceHandling: Enables "Strict Mode" (=checking for interfaces not present any more) 


* Why are there more options in the config than in the program (debugmode, timer...)?
I don't consider them very userfriendly, in 99% of all cases they are fine like they are.
Also I want to keep the GUI as simple as possible.


* I'm interested in the programming of VPMWatch, can I have the sourcecode?
Absolutely, this is encouraged actually! The sourcecode is included.
If you don't need it, just delete the sourcecode folder.


* I have additonal ideas or questions, can I contact you?
Sure, drop me a line at muff99@outlook.com


Changelog:
* 1.1.1 - 290613
  introducing "Strict Mode" for PPTP network support
* 1.1 - 120613
  support for interfaces instead of IP ranges (big thanks to TorrentFreak's Ernesto)
  fix for VPNWatcher doing nothing when started minimized
  simpler UI with less buttons
  autosave for all config values except the interface name
  icons fixed (less resources, smaller binary) 
  sourcecode cleanup
* 1.0 - 100613
  initial release
```
