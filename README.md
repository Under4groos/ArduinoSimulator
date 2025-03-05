
## Mouse
```C
Console.ReadLine();
simulator.MouseClick(
    ArduinoSimulator.Enums.MouseKeys.MOUSE_LEFT,
    ArduinoSimulator.Enums.MouseStatus.press
    );
simulator.MouseMove(0, 100);
simulator.MouseClick(
    ArduinoSimulator.Enums.MouseKeys.MOUSE_LEFT,
    ArduinoSimulator.Enums.MouseStatus.release
    );
simulator.MouseMove(0, -100);
```
Mouse Enums 
```C
public enum MouseKeys
{
    MOUSE_LEFT = 1,
    MOUSE_RIGHT = 2,
    MOUSE_MIDDLE = 4,
    MOUSE_ALL = (MOUSE_LEFT | MOUSE_RIGHT | MOUSE_MIDDLE)
}
public enum MouseStatus
{
    click,
    press,
    release,
}
```

## Keyboard
Write text.
```C
string readLine = Console.ReadLine();
Thread.Sleep(5000);
simulator.KeyboardWriteText(readLine, delay: 500);
```