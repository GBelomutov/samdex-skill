using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AP.Constantine.Functions.Core.Utils
{
    public interface IWakeOnLanService
    {
        /// <summary>
        /// Wake device by WOL protocol
        /// </summary>
        /// <param name="mac">Device MAC Address</param>
        /// <param name="domainAddress">network address</param>
        Task Wake(string mac, string domainAddress);
    }

    public class WakeOnLanService : IWakeOnLanService
    {
        /// <inheritdoc/>
        public async Task Wake(string mac, string domainAddress)
        {
            //192.168.100.31
            //var result = await ArpRequest.SendAsync(new IPAddress(new byte[] { 192, 168, 100, 31 }));
            //MAC wired:    70:2a:d5:3d:2e:62
            //MAC wireless: 64:1c:ae:4c:a8:c7

            //MAC PC:       0c:9d:92:c2:ba:21 WORK!!!!!
            var macAddress = ParseMacAddress(mac, ':');
            var magicPacket = GetMagicPacket(macAddress);

            using (var client = new UdpClient())
            {
                await client.SendAsync(magicPacket, 102, domainAddress, 9);
            }
        }

        private byte[] GetMagicPacket(byte[] macAddress)
        {
            var packet = new List<byte> { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
            for (var i = 0; i < 16; i++)
            {
                packet.AddRange(macAddress);
            }
            return packet.ToArray();
        }

        private byte[] ParseMacAddress(string macaddress, char separator)
        {
            var parts = macaddress.Split(separator);
            return parts.Select(x => Convert.ToByte(x, 16)).ToArray();
        }
    }
}
