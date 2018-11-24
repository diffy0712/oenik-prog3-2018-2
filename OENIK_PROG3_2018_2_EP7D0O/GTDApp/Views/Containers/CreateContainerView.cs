// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="CreateContainerView.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Console.Views.Containers
{
    using Terminal.Gui;

    /// <summary>
    ///     CreateContainerView
    /// </summary>
    public class CreateContainerView : IView
    {
        /// <summary>
        ///     Editor
        /// </summary>
        /// <returns>Window</returns>
        public Window Render()
        {
            var win = new Window("Create Container")
            {
                X = 0,
                Y = 2,
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };
            var name = new Label("Name: ") { X = 2, Y = 1 };
            var purpose = new Label("Purpose: ")
            {
                X = Pos.Left(name),
                Y = Pos.Bottom(name) + 1,
                Width = 25
            };
            var nameText = new TextField(string.Empty)
            {
                X = Pos.Right(purpose),
                Y = Pos.Top(name),
                Width = 85
            };
            var purposeText = new TextField(string.Empty)
            {
                X = Pos.Left(nameText),
                Y = Pos.Top(purpose),
                Width = Dim.Width(nameText)
            };
            var principles = new Label("Principles: ")
            {
                X = Pos.Left(purpose),
                Y = Pos.Bottom(purpose) + 1
            };
            var principlesText = new TextField(string.Empty)
            {
                X = Pos.Left(purposeText),
                Y = Pos.Top(principles),
                Width = Dim.Width(nameText)
            };
            var invisionedOutcome = new Label("Invisioned Outcome: ")
            {
                X = Pos.Left(principles),
                Y = Pos.Bottom(principles) + 1
            };
            var invisionedOutcomeText = new TextField(string.Empty)
            {
                X = Pos.Left(principlesText),
                Y = Pos.Top(invisionedOutcome),
                Width = Dim.Width(nameText)
            };

            // Add some content
            win.Add(
                name,
                nameText,
                purpose,
                purposeText,
                principles,
                principlesText,
                invisionedOutcome,
                invisionedOutcomeText,
                new FrameView(new Rect(2, 9, 110, 9), "Type of Container"){
                    new RadioGroup (1, 0, new [] {
                        "Incoming Collection Container",
                        "Project Container",
                        "Reference Collection Container",
                        "Incubator Collection Container" ,
                        "Blocked Collection Container",
                        "Appointment Collection Container",
                        "Next Actions Collection Container"
                    }, 0),
                },
                new Button(3, 19, "Create")
            );

            return win;
        }
    }
}
