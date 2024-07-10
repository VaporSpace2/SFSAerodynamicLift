# SFSAerodynamicLift
An SFS mod that contains a wing part (just a fuel tank thats lighter and has less fuel) and a lifting body fuel tank.


## I want to make a mod that incorporates body lift, how can I use this?

1. Download/clone this repository (or click the green code button and press download .zip)

2. Take the "LiftingBodyBase" folder and paste it in the assets folder of your modding toolkit unity repository.

3. Add the script "Lifting Body Module" script (NOT the "Lifting Body Module-SCRIPT-") to your part that you want to give lift, or just copy it from any of the 2 prepackaged parts that come with the mod.

4. Once you want to build your mod to play with it, make sure you go to the "LiftingBodyModule.dll" file and add it to your mods asset bundle.

5. Rename the "LiftingBodyModule-SCRIPT-.dll" file to the same as the normal "LiftingBodyModule.dll" script, and probably move the file so you dont confuse the two.

6. Finally, when you press build mod your file manager will pop up, choose the LiftingBodyModule.dll that i had you rename in the last step and then your mod should work.

7. Consult me (Tommyboo4708) on discord if you have any issues or questions, I will answer your questions.

## Important notes

I would like it if you could also Credit me if you use my stuff in any way on your mods/projects, and if you noticed already I stole some math from https://github.com/brihernandez/SimpleWings because I got mad that the real world lift equations I originally used caused nothing but issues

I will also likely not be maintaining this mod myself, and so any PR that doesnt cause issues and fix stuff or whatever is welcome.
