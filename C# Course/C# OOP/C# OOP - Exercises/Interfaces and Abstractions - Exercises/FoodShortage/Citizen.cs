﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Citizen : IBuyer
    {
        public int Food { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Birthdate { get; private set; }
        public string Id { get; private set; }
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Birthdate = birthdate;
            this.Id = id;
        }
        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
