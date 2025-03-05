using ArduinoSimulator;

using (ArduinoDeviceSimulator simulator = new ArduinoDeviceSimulator("COM17", Received: (sender, bytes) =>
{
    //Console.WriteLine(string.Join(" ", bytes));

    Console.WriteLine(System.Text.Encoding.UTF8.GetString(bytes));
}, 300))
{

    while (true)
    {



        #region Mouse
        Console.ReadLine();
        simulator.Click(
            ArduinoSimulator.Enums.MouseKeys.MOUSE_LEFT,
            ArduinoSimulator.Enums.MouseStatus.press
            );
        simulator.LocalMouseMove(0, 100);

        simulator.Click(
            ArduinoSimulator.Enums.MouseKeys.MOUSE_LEFT,
            ArduinoSimulator.Enums.MouseStatus.release
            );

        simulator.LocalMouseMove(0, -100);
        #endregion





    }
}

