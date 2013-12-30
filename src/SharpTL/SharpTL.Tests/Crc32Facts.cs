﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Crc32Facts.cs">
//   Copyright (c) 2013 Alexander Logger. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Text;
using FluentAssertions;
using NUnit.Framework;
using SharpTL.Compiler.Utils;

namespace SharpTL.Tests
{
    [TestFixture]
    public class Crc32Facts
    {
        [Test]
        [TestCase("boolFalse = Bool", 0xbc799737u)]
        [TestCase("boolTrue = Bool", 0x997275b5u)]
        [TestCase("vector t:Type # [ t ] = Vector t", 0x1cb5c415u)]
        [TestCase("error code:int text:string = Error", 0xc4b9f9bbu)]
        [TestCase("req_pq nonce:int128 = ResPQ", 0x60469778u)]
        public void Should_compute_correct_crc32(string text, uint correctCrc32)
        {
            uint crc32 = Crc32.Compute(text, Encoding.UTF8);
            crc32.Should().Be(correctCrc32);
        }
    }
}