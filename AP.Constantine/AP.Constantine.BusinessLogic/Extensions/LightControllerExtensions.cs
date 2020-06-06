using AP.Constantine.BusinessLogic.Enums;
using AP.Constantine.BusinessLogic.Models;
using System.Drawing;
using System.Linq;

namespace AP.Constantine.BusinessLogic.Extensions
{
    internal static class LightControllerExtensions
    {
        public static Color ToColor(this byte[] data, LightMode mode)
        {
            return mode switch
            {
                LightMode.Color => Color.FromArgb(data[6], data[7], data[8]),
                LightMode.White => Color.White,
                _ => Color.Transparent,
            };
        }

        public static LightMode ToLightMode(this string hex)
        {
            // Check if it's color or custom
            switch (hex)
            {
                case "61":
                case "62":
                case "41":
                    return LightMode.Color;
                case "60":
                    return LightMode.Custom;
                case "2a":
                case "2b":
                case "2c":
                case "2d":
                case "2e":
                case "2f":
                    return LightMode.Preset;
            }

            // Fallback: check if it's preset when it's in range
            if (int.TryParse(hex, out var result))
            {
                if (25 <= result && result <= 38)
                {
                    return LightMode.Preset;
                }
            }

            // Fallback
            return LightMode.Unknown;
        }

        public static bool IsPowerOn(this string hex) => hex == "23";

        public static ColorControllerData ToColorControllerData(this byte[] bytes)
        {
            var resultAsHex = bytes.Select(r => r.ToString("X")).ToArray(); // Convert to hex
            var lightMode = resultAsHex[7].ToLightMode();
            var colorResult = new ColorControllerData
            {
                IsTurnedOn = resultAsHex[2].IsPowerOn(),
                LightMode = lightMode,
                Color = bytes.ToColor(lightMode),
                HexData = resultAsHex,
            };

            return colorResult;
        }
    }
}
