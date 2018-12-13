namespace GTDApp.ConsoleCore.View
{
    using GTDApp.ConsoleCore.Menu;
    using GTDApp.ConsoleCore.Views;
    using GTDApp.Logic.Interfaces;
    using GTDApp.Logic.Routing;
    using Terminal.Gui;

    public abstract class AbstractView : IView
    {
        /// <summary>
        ///    Gets or sets Router
        /// </summary>
        /// <value>Router</value>
        public Router Router { get; set; }
       

        public void Render()
        {
            Application.Init();

            var tframe = Application.Top.Frame;
            var ntop = new Toplevel(tframe);

            MenuHelper mainMenuBar = new MenuHelper(ntop, this.GetMenu().GetMenu(),this.Router);

            var win = new Window(this.GetTitle())
            {
                X = 0,
                Y = 1,
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };

            this.Content(win);

            ntop.Add(win);

            Application.Run(ntop);
        }

        protected abstract void Content(Window win);
        protected abstract IMenu GetMenu();
        protected abstract string GetTitle();
    }
}
