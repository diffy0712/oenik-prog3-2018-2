namespace GTDApp.ConsoleCore.View
{
    using GTDApp.ConsoleCore.Menu;
    using GTDApp.ConsoleCore.Views;
    using GTDApp.Logic.Interfaces;
    using Terminal.Gui;

    public abstract class AbstractView : IView
    {
        public void Render()
        {
            Application.Init();

            Toplevel top = new Toplevel(Application.Top.Frame);
            
            MenuHelper mainMenuBar = new MenuHelper(top, this.GetMenu().GetMenu());

            var win = new Window(this.GetTitle())
            {
                X = 0,
                Y = 1,
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };

            this.Content(win);

            top.Add(win);

            Application.Run(top);
        }

        protected abstract void Content(Window win);
        protected abstract IMenu GetMenu();
        protected abstract string GetTitle();
    }

}
