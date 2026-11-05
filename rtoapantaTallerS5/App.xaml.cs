using Microsoft.Extensions.DependencyInjection;

namespace rtoapantaTallerS5
{
    public partial class App : Application
    {
        public static Repositories.PersonRepostory _personRepository { get; set; }
        public App(Repositories.PersonRepostory personRepo)
        {
            InitializeComponent();
            _personRepository = personRepo;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new Views.vPersona());
        }
    }
}