﻿using Pixeval.Pages;

namespace Pixeval.Events
{
    public class MainPageFrameNavigatingEvent : IEvent
    {
        public object? Sender { get; }

        public MainPageFrameNavigatingEvent(MainPage? sender)
        {
            Sender = sender;
        }
    }
}