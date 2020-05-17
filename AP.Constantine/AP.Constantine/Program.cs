using AP.Constantine.Functions;
using AP.Constantine.BusinessLogic.Services;
using System;
using System.Drawing;
using System.Threading.Tasks;

namespace AP.Constantine
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var function = new ConstantineHandler();

            //await function.Run("test");
            var configProvider = new LightControlSettingsProvider();
           
            var connector = new LightControlConnector(configProvider);
            var controller = connector.ConnectToGlobalNetworkAsync();
            while (true)
            {
                var key = Console.ReadKey();
                await HandleInput(key, controller);
            }
            Console.ReadKey();
        }

        public static async Task HandleInput(ConsoleKeyInfo key, ILightController controller)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    await controller.TurnOnAsync();
                    Console.WriteLine("Power On");
                    break;
                case ConsoleKey.DownArrow:
                    await controller.TurnOffAsync();
                    Console.WriteLine("Power Off");
                    break;
                case ConsoleKey.Q:
                    await controller.SetColorAsync(Color.Red);
                    Console.WriteLine("Set red color");
                    break;
                case ConsoleKey.W:
                    await controller.SetColorAsync(Color.Green);
                    Console.WriteLine("Set green color");
                    break;
                case ConsoleKey.E:
                    await controller.SetColorAsync(Color.Blue);
                    Console.WriteLine("Set blue color");
                    break;
            }
            Console.WriteLine(await controller.GetColorControllerData());
        }
    }
}
