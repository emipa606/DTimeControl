# DTimeControl

![Image](https://i.imgur.com/buuPQel.png)

Update of Dametris mod
https://steamcommunity.com/sharedfiles/filedetails/?id=2109225757
with the 1.3 version from the update by Denneisk
https://steamcommunity.com/sharedfiles/filedetails/?id=2558693847

- Added support for https://steamcommunity.com/sharedfiles/filedetails/?id=1319782555]Snap Out!

![Image](https://i.imgur.com/pufA0kM.png)

	
![Image](https://i.imgur.com/Z4GOv8H.png)

# Overview

Spare some time and leave a like!

![Image](https://i.imgur.com/FcAqtoA.png)

## Designed for Rimworld 1.1, 1.2 


Gives you control over the length of a day, giving your colonists more (or less) time to move around and do things.

I made this mod because I got frustrated with my colonists spending most of the day walking. Too many times I've seen someone spend 3 hours walking to a mining site in the back yard just to turn around after two taps because it's time for a snack.

**Compatible with existing saves, and can be removed without issue.**

Requires Harmony.

**Note:** This mod will probably require more testing than I've been able to give it so far. Let me know of any problems you run into.

------------------------------------------------------------------------------------------------------

# Features

## You have control over how long or short the days will be.

By default, days will be 25% longer. Open the options menu for the slider to change day length and other options. A higher % is a longer day.

**Making the day longer will mean that walking won't take as much of the day.**


- All pawns (colonists, other humanoids, animals) will move, fight, tend wounds, and make decisions at a speed unaffected by the increased day length.

- Unless an option is enabled, most work and activities (other than tending wounds), as well as things like world events, will take place at the normal rate relative to the length of the day.

- With an option, you can also allow your colonists to get more done in a day - more construction, more mining, more cooking, more work done.

- Needs will fall at the same per-day rate as usual, so increasing the day length means your colonists won't need to eat more meals or sleep more in a day than they otherwise would.

- Colonists will have more time to tend to health effects - including bleeding out.




**Make the day shorter at your own peril...**

[img=https://i.imgur.com/lN11WhK.gif])


*(I made this mod primarily to allow for longer days, but those aren't as easy to show in GIFs. Also, extremely short days can be kind of funny - raiders give up almost as soon as they spawn, winter starts and finishes before pawns have time to get hypothermia, and it generally feels like your colonists are Ents.)*

------------------------------------------------------------------------------------------------------
Under the hood

This mod selectively changes tickrates: one rate is used for certain components of pawn behavior, projectiles, and motes, and the other tickrate for everything else.

------------------------------------------------------------------------------------------------------
## Load order


Harmony
Core
...
[D] Time Control

------------------------------------------------------------------------------------------------------
### Compatible with:

Hopefully most mods.
Tested with:


- Smart Speed



### Conflicts:

This mod alters some pretty significant tick code. Ticks are the core mechanism by which the game advances. I hope that there will be few conflicts, but let me know if you find any.
Known conflicts:
- Zombieland
![Image](https://i.imgur.com/PwoNOj4.png)



-  See if the the error persists if you just have this mod and its requirements active.
-  If not, try adding your other mods until it happens again.
-  Post your error-log using https://steamcommunity.com/workshop/filedetails/?id=818773962]HugsLib and command Ctrl+F12
-  For best support, please use the Discord-channel for error-reporting.
-  Do not report errors by making a discussion-thread, I get no notification of that.
-  If you have the solution for a problem, please post it to the GitHub repository.


https://steamcommunity.com/sharedfiles/filedetails/changelog/2887355135]Last updated 2023-07-09
