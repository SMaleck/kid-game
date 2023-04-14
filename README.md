# Kid Game (Working Title)

A simple auto-runner game made for small children. 
Multiple levels of complexity are included for different ages.

The little gnome running through the forrest is a scenario based on a polish lullaby my mother passed on to me from previous generations and I am now passing on to my son.\
You can find the original song text as well as German and English translations [here](./Docs/SongText.md). I could not find many references to it anywhere, which would suggest it to be a very locally known lullaby. So in an unexpected way, this project turned from purely technical research into a bit of a preservation effort.

I hope you and your children find some enjoyment with this game.

## Credits
- Sebastian Maleck - Design & Development
- David Presa - Art & Animations

### Other Assets (CC0)
- [Cure Magic by Someoneman](https://opengameart.org/content/cure-magic)
- [RPG Sound Pack by artisticdude](https://opengameart.org/content/rpg-sound-pack)
- [Kenney - UI Audio](https://www.kenney.nl/assets/ui-audio)

### Resources Used
- FontAwesome for all GUI icons
- [html-color.codes](https://html-color.codes) for picking good looking colors, as I have a programmers eye for them :P
- Unity UI Extensions
- Json.NET

----
## Goals
This is mainly an experimental research-project, with several goals:

### 1. Attempt to make a simple child-friendly game
Initially a 1-year-old should be able to rudimentary play the game.
Additionally the idea was to grow the game with the child, as multiple levels of complexity (usually "difficulty") are available for different age-ranges

### 2. Attempt to make a game without any Dependency Injection and RX framework
In my professional environment, I was working mainly with Zenject and UniRx, both of which fundamentally influence the architecture of the game.
Attempting to learn Unreal with C++ proved difficult for me, as DI is simply non-existent, but my thought patterns were already shaped strongly with DI thinking. 
Thus the idea to start a project with a "what-if" approach and eliminating DI and RX completely, in order to learn different approaches and the restrictions of C++ without the additional baggage of another engine and syntax.

----
# Systems Created and Future Considerations

## Savegames
Created a multi-file capable savegame system, so I could manage a single global savegame and multiple player profiles.
- Read/Write operations should be made async

## GUI: `Gooey`
Created a simple GUI package to handle screens and modals. The idea was to make the underlying service manage all GUIs automatically based on type with concerns like
- A stack of GUIs that would re-open a lower GUI when a higher one closes
- Automatic handling of canvas layering
- Clear behaviour for Screens/Panels/Modals

In the end I didn't need most of those things, so I ended up not doing them. This is something I might revisit ina  future project.