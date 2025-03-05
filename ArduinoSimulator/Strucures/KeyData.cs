using ArduinoSimulator.Enums;

namespace ArduinoSimulator.Strucures
{
    public struct KeyData
    {

        public KeyType Type;

        // KeyCode
        public byte Key;
        // Sleep or delay
        public int Sleep;


        public void Clear()
        {
            Type = KeyType.release;
            Key = 0;
            Sleep = 0;
        }
        public byte[] GetData()
        {
            byte[] data = new byte[10];
            data[0] = 0;
            data[1] = (byte)Type;
            data[2] = Key;
            data[3] = (byte)Sleep;
            return data;
        }
    }
}
