using AP.Constantine.BusinessLogic.Enums;
using System.Drawing;

namespace AP.Constantine.BusinessLogic.Models
{
    public class ColorControllerData
    {
        public bool IsTurnedOn { get; set; }

        public LightMode LightMode { get; set; }

        public Color Color { get; set; }

        public string[] HexData { get; set; }

        public string HexString => string.Join("-", HexData);

        public override string ToString()
        {
            var result = $@"{GetType().Name}
 Power Enabled: {IsTurnedOn}
 Color: {Color}
 Light Mode: {LightMode}
 HexData: {HexString}";
            return result;
        }
    }
}
