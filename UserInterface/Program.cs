using System.Threading.Tasks;
using UserInterface.DataMangaer;

namespace UserInterface
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await MachineControl.MainMenu();
        }
    }
}

