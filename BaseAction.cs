using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Clicker
{
    public class BaseAction
    {
        public int Delay;
        public string DelayInView => Delay.ToString();
        public int CoordX;
        public int CoordY;
        public string Coords => $"{CoordX.ToString()};{CoordY.ToString()}";
        public int Repeat;
        public string RepeatInView => Repeat.ToString();
        public enum ActionType { Move, PressRelease, PressReleaseX2, Press, Release}
        public ActionType _ActionType;
        public string Type => _ActionType.ToString();
        public Key Key;
        public string KeyInView {
            get {
                string ctrl = FlagCtrl ? " + CTRL" : "";
                string shift = FlagShift ? " + SHIFT" : "";
                string alt = FlagAlt ? " + ALT" : "";
                
                string output = $"{Key.ToString()}\r\n{ctrl}\r\n{shift}\r\n{alt}";
                return output;
            }
        }
        public bool RelativeCoord { get; set; }
        public bool CurrentCoord { get; set; }
        public bool FlagCtrl;
        public bool FlagShift;
        public bool FlagAlt;

        public BaseAction(Key key, int delay, ActionType actiontype, int coordX, int coordY, int repeat, bool relativecoord, bool currentcoord, bool flagCtrl, bool flagShift, bool flagAlt) { 
            Key = key;
            Delay = delay;
            _ActionType = actiontype;
            CoordX = coordX;
            CoordY = coordY;
            Repeat = repeat;
            RelativeCoord = relativecoord;
            CurrentCoord = currentcoord;
            FlagCtrl = flagCtrl;
            FlagShift = flagShift;
            FlagAlt = flagAlt;
        }

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
