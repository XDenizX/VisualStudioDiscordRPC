﻿using System.Collections.Generic;
using System;
using DiscordRPC;
using VisualStudioDiscordRPC.Shared.Data;

namespace VisualStudioDiscordRPC.Shared.Nests.Base
{
    public abstract class BaseButtonNest : BaseDiscordRpcNest<ButtonInfo>
    {
        private readonly static Button FirstButton = new Button();
        private readonly static Button SecondButton = new Button();

        private readonly static List<Button> Buttons = new List<Button>();

        protected BaseButtonNest(RichPresence richPresence) : base(richPresence)
        { }

        protected void SetButton(int index, ButtonInfo buttonInfo)
        {
            UpdateButtonWithInfo(index, buttonInfo);
            RichPresence.Buttons = Buttons.ToArray();
        }

        private void UpdateButtonWithInfo(int index, ButtonInfo buttonInfo)
        {
            Button button;
            switch (index)
            {
                case 0: button = FirstButton; break;
                case 1: button = SecondButton; break;
                default: throw new ArgumentOutOfRangeException($"{nameof(index)} must be 0 or 1");
            }

            if (string.IsNullOrEmpty(buttonInfo.Label) || 
                string.IsNullOrEmpty(buttonInfo.Url) || 
                !Uri.TryCreate(buttonInfo.Url, UriKind.Absolute, out Uri _))
            {
                Buttons.Remove(button);
                return;
            }

            button.Label = buttonInfo.Label;
            button.Url = buttonInfo.Url;
            
            if (!Buttons.Contains(button))
            {
                Buttons.Add(button);
            }
        }
    }
}
