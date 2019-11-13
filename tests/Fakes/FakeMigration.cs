﻿using System.Text.RegularExpressions;
using Minimig;

namespace MinimigTests.Fakes
{
    public class FakeMigration : Migration
    {
        public FakeMigration(string filePath) : base(filePath, new Regex("\r\n|\n\r|\n|\r", RegexOptions.Compiled))
        {
        }
    }
}
