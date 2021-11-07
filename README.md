# Dialogue system through JSON file

Unity version 2020.3.19f1

#### Assignment
Every game with a story have one thing in common Dialogue there can be no story if there is no dialogue and even games without story need dialogue hence I wanted to learn how to make an system for dialogue.

##### How I went to work
But if you need to paste it into C# code then it becomes a mess and hard to edit/add/make the dialogue so I wanted to make them in another file after some research I decided to use YAML as it looked like an easy system to write dialogue in but I know C# works well with JSON so I decided to write the dialogue in YAML and use an converter to convert the YAML file to an JSON file and read it from there where it would become harder to read for an human ut easier for C#

##### Result
The system works and you can enter different dialogue routes you can also engage in conversation if you are within the trigger

##### Things I might want to add in the future
I want to make the character detected the distance without an trigger but I still need to figure out if that is an better option
I also want to make an script that auto converts my YAML file to JSON on build so that I never need to look at the JSON file