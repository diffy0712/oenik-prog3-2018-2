// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="CreateContainerView.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Console.Views.Containers
{
    using System;
    using GTDApp.Console.Menu;
    using GTDApp.ConsoleCore.Menu;
    using GTDApp.ConsoleCore.View;
    using GTDApp.Logic;
    using Terminal.Gui;

    /// <summary>
    ///     CreateContainerView
    /// </summary>
    public class CreateContainerView : AbstractView
    {
        /// <summary>
        ///     Content
        /// </summary>
        /// <param name="win">Window instance</param>
        protected override void Content(Window win)
        {
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

            FrameView typeView = new FrameView(new Rect(2, 9, 110, 9), "Type of Container"){
                new RadioGroup (
                    1,
                    0,
                    new [] {
                        "Incoming Collection Container",
                        "Project Container",
                        "Reference Collection Container",
                        "Incubator Collection Container" ,
                        "Blocked Collection Container",
                        "Appointment Collection Container",
                        "Next Actions Collection Container"
                    },
                    0
                ),
            };

            Button createButton = new Button(85, 19, "Create");
            Action createButtonEvent = new Action(() => { Router.Call("create_container"); });
            createButton.Clicked = createButtonEvent;

            Button backToListButton = new Button(96, 19, "Back To List");
            Action backToListButtonEvent = new Action(() => { Router.Call("list_containers"); });
            backToListButton.Clicked = backToListButtonEvent;

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
                typeView,
                createButton,
                backToListButton
            );
        }

        /// <summary>
        ///     GetMenu
        /// </summary>
        /// <returns>IMenu</returns>
        protected override IMenu GetMenu()
        {
            return new MainMenu();
        }

        /// <summary>
        ///     GetTitle
        /// </summary>
        /// <returns>string</returns>
        protected override string GetTitle()
        {
            return "Create Container";
        }
    }
}
