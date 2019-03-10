namespace Registriermachine.Tests
{
    using System;
    using System.Collections.Generic;
    using FakeItEasy;
    using FluentAssertions;
    using Registriermachine.Compiler;
    using Registriermachine.Compiler.InstructionsSet;
    using Registriermachine.ExecutableUnit;
    using Xunit;

    public class CompilerTests
    {
        [Fact]
        public void ShouldThrowExceptionWhenCodeLineIsNotCompilable()
        {
            // Arrange
            ICompiler testee = new Registriermachine.Compiler.Compiler(new List<IInstructionTemplate>(), A.Fake<IExecutableUnitFactory>(o => o.Strict()));

            // Act
            Action act = () => testee.Compile(new List<string> { "SomeLine " });

            // Assert
            act.Should().Throw<InvalidCodeException>();
        }
    }
}