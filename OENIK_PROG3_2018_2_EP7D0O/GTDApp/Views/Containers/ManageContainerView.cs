// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="ManageContainerView.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Console.Views.Containers
{
    using System;
    using GTDApp.Console.Menu;
    using GTDApp.ConsoleCore;
    using GTDApp.ConsoleCore.Menu;
    using GTDApp.ConsoleCore.View;
    using GTDApp.Data;
    using Terminal.Gui;

    /// <summary>
    ///     ManageContainerView
    /// </summary>
    public class ManageContainerView : AbstractView
    {
        /// <summary>
        ///     Gets or sets _creation
        /// </summary>
        /// <value>IQueryable of Notification</value>
        private bool _creation = true;

        /// <summary>
        ///     Gets or sets a value indicating whether we are currently creating a new entity
        /// </summary>
        /// <value>IQueryable of Notification</value>
        public bool Creation
        {
            get
            {
                return this._creation;
            }

            set
            {
                this._creation = value;
            }
        }

        /// <summary>
        ///    Gets or sets Container
        /// </summary>
        /// <value>Container</value>
        public Container Container { get; set; }

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
            var nameText = new TextField(this.Container.name)
            {
                X = Pos.Right(purpose),
                Y = Pos.Top(name),
                Width = 85
            };
            var purposeText = new TextField(this.Container.purpose)
            {
                X = Pos.Left(nameText),
                Y = Pos.Top(purpose),
                Width = Dim.Width(nameText),
            };
            var principles = new Label("Principles: ")
            {
                X = Pos.Left(purpose),
                Y = Pos.Bottom(purpose) + 1
            };
            var principlesText = new TextField(this.Container.principles)
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
            var invisionedOutcomeText = new TextField(this.Container.invisioned_outcome)
            {
                X = Pos.Left(principlesText),
                Y = Pos.Top(invisionedOutcome),
                Width = Dim.Width(nameText)
            };

            string[] typesArray = new[]
            {
                "project",
                "incubator",
                "blocked",
                "next_actions",
                "calendar"
            };

            int typeSelected = 0;

            if (!this.Creation)
            {
                for (int i = 0; i < typesArray.Length; i++)
                {
                    if (typesArray[i] == this.Container.type)
                    {
                        typeSelected = i;
                    }
                }
            }

            RadioGroup typeGroup = new RadioGroup(
                1,
                0,
                typesArray,
                typeSelected);

            FrameView typeView = new FrameView(new Rect(2, 9, 110, 9), "Type of Container")
            {
                typeGroup
            };
            Button manageButton = new Button(85, 19, "Save");
            Action manageButtonEvent = new Action(() =>
            {
                this.Container.name = nameText.Text.ToString();
                this.Container.purpose = purposeText.Text.ToString();
                this.Container.principles = principlesText.Text.ToString();
                this.Container.invisioned_outcome = invisionedOutcomeText.Text.ToString();
                this.Container.type = typesArray[typeGroup.Selected].ToString();
                object[] parameters = new object[]
                {
                    this.Container
                };
                ConsoleCore.CallRoute(RoutesEnum.MANAGE_CONTAINER_ACTION.ToString(), parameters);
            });
            manageButton.Clicked = manageButtonEvent;

            Button backToListButton = new Button(96, 19, "Back To List");
            Action backToListButtonEvent = new Action(() => { ConsoleCore.CallRoute(RoutesEnum.LIST_CONTAINERS.ToString()); });
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
                manageButton,
                backToListButton);
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
            return this.Creation ? "Create Container" : "Edit Container";
        }
    }
}
