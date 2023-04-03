using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Clicker
{
    internal class BaseAction
    {
        public int Delay;
        public int CoordX;
        public int CoordY;
        public int Repeat;
        public enum ActionType { Move, PressRelease, PressReleaseX2, Press, Release}
        public ActionType _ActionType;
        public string Type => _ActionType.ToString();
        public Key Key;
        public string KeyInView => Key.ToString();

        public BaseAction(Key key, int delay, ActionType actiontype, int coordX, int coordY, int repeat) { 
            Key = key;
            Delay = delay;
            _ActionType = actiontype;
            CoordX = coordX;
            CoordY = coordY;
            Repeat = repeat; }

        public static ActionType FromString(string source)
        {
            if (Enum.TryParse(source, true, out ActionType type))
            {
                return type;
            }
            throw new Exception("Cant Parse");
        }
    }
}
