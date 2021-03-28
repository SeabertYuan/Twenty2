# Twenty2
20/20 enforced :)

## C Sharp
Currently working! Program will now tell you when to take a break :D Hopefully going to polish it up, finish console functionality, and add saveable settings.
### Features
- Customizability over time between breaks
- customizability over length of break time
- Customizability over what plays
- On/off switch
- Console (W.I.P.)
### Code
Made without any external libraries.
Latest version:
- Default runs every 20 minutes for 20s
- Still needs a bit more polishing
    - Console doesn't work yet
- Less hardcoded
- Better variable and function names
- Fixed class, namespace, and file names

Runs on 3 threads, 1 timer, 1 gui, 1 main. Play and pause works by stopping and starting the thread. Whenever a setting is changed it calls methods in `User Settings.cs`(garbage name) that update variables. Timer is completely reset by restarting the thread. Is this the most efficient way? Probably not. Do I care? No.

## Java
Java version!! Hopefully will become more intuitive and less hardcoded. Currently, there has been minimal development towards any improvement.
### Features
- Has a bell schedule (eventually going to make custom button schedule changer)
- Basic GUI
### Code
Made using JavaFX to run use the following command:
```
$ java --module-path "path/to/JavaFX" --add-modules javafx.controls,javafx.fxml,javafx.media -jar "path/to/jar"
```
Still a work in progress ;-;
This version is heavily hardcoded (bell schedule is only synced to my school's time).