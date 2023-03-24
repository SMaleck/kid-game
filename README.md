# Kid Game (Working Title)

A simple auto-runner game made for small children. 
Multiple levels of complexity are included for different ages.

## Goals
This is mainly an experimental research-project, with several goals:

### 1. Attempt to make a simple child-friendly game
Initially a 1-year-old should be able to rudimentary play the game.
Additionally the idea was to grow the game with the child, as multiple levels of complexity (usually "difficulty") are available for different age-ranges

### 2. Attempt to make a game without any Dependency Injection and RX framework
In my professional environment, I was working mainly with Zenject and UniRx, both of which fundamentally influence the architecture of the game.
Attempting to learn Unreal with C++ proved difficult for me, as DI is simply non-existent, but my thought patterns were already shaped strongly with DI thinking. 
Thus the idea to start a project with a "what-if" approach and eliminating DI and RX completely, in order to learn different approaches and the restrictions of C++ without the additional baggage of another engine and syntax.

## Documentation
Further docs can be found [here](./Docs).

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