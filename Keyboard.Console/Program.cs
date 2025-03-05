using ArduinoSimulator;

using (ArduinoDeviceSimulator simulator = new ArduinoDeviceSimulator("COM17", Received: (sender, bytes) =>
{
    //Console.WriteLine(string.Join(" ", bytes));

    Console.WriteLine(System.Text.Encoding.UTF8.GetString(bytes));
}, 300))
{

    while (true)
    {
        string readLine = Console.ReadLine();
        Thread.Sleep(5000);
        simulator.KeyboardWriteText(readLine, delay: 500);





        #region Mouse
        //Console.ReadLine();
        simulator.MouseClick(
            ArduinoSimulator.Enums.MouseKeys.MOUSE_LEFT,
            ArduinoSimulator.Enums.MouseStatus.press
            );
        //simulator.MouseMove(0, 100);

        //simulator.MouseClick(
        //    ArduinoSimulator.Enums.MouseKeys.MOUSE_LEFT,
        //    ArduinoSimulator.Enums.MouseStatus.release
        //    );

        //simulator.MouseMove(0, -100);
        #endregion





    }
}

