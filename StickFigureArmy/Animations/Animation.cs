﻿using Microsoft.Xna.Framework;
using StickFigureArmy.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StickFigureArmy.Animations
{
    class Animation
    {
        public Frame CurrentFrame { get; set; }
        private List<Frame> frames;
        private Cooldown cooldown;
        private int FrameNumber = 0; //Huidige frame
        private String Name = "";
        public Animation()
        {
            cooldown = new Cooldown();
            frames = new List<Frame>();
        }
        public void AddFrame(Frame frame)
        {
            frames.Add(frame);
            CurrentFrame = frames[0];
        }
        public void Update(GameTime gameTime)
        {
            if (cooldown.CooldownTimerFPS(gameTime, 5))
            {
                FrameNumber++;
            }
            if (FrameNumber >= frames.Count)
            {
                FrameNumber = 0;
            }
            CurrentFrame = frames[FrameNumber];
        }
        static public Animation Create(int x, int y, int width, int height, int frameAmount, string name) //Creëert een animatie op dezelfde rij
        {
            Animation animation = new Animation();
            animation.Name = "name";
            for (int i = 0; i < frameAmount; i++)
            {
                animation.AddFrame(new Frame(new Rectangle(x, y, width, height)));
                x += width;
            }
            return animation;
        }
    }
}