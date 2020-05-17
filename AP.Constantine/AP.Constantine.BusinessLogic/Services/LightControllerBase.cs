using AP.Constantine.BusinessLogic.Models;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace AP.Constantine.BusinessLogic.Services
{
    public interface ILightController
    {
        Task TurnOnAsync();

        Task TurnOffAsync();

        Task SetColorAsync(Color color);

        Task<ColorControllerData> GetColorControllerData();
    }

    public abstract class LightControllerBase : ILightController
    {
        public const int BufferSize = 20;

        public async Task TurnOnAsync() => await Send(new byte[] { 0x71, 0x23, 0x0f, 0xa3 });

        public async Task TurnOffAsync() => await Send(new byte[] { 0x71, 0x24, 0x0f, 0xa4 });

        public async Task SetColorAsync(Color color) => await Send(new byte[]{ 0x31, color.R, color.G, color.B, 0x00, 0x00, 0xf0, 0x0f, 0x2f });

        public abstract Task<ColorControllerData> GetColorControllerData();

        protected abstract Task Send(byte[] data);

        /// <summary>
        /// Applies the checksum to the given data.
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        protected static IEnumerable<byte> CalculateChecksum(IReadOnlyList<byte> bytes)
        {
            var packet = new List<byte>();
            byte checksum = 0;

            checksum = (byte)bytes.Sum(b => b); // checksum = 'sum of all byte elements in array'
            checksum &= 0xFF; // checksum = checksum AND 255

            packet.AddRange(bytes); // First things first, add our bytes
            packet.Add(checksum); // Then, append the checksum at the end

            return packet;
        }
    }
}
