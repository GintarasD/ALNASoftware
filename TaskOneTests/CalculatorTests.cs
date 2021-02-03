using System;
using Xunit;

namespace TaskOneTests {
	public class CalculatorTests {
		[Theory]
		[InlineData(-1, -1)]
		[InlineData(0, -1)]
		[InlineData(-1, 0)]
		[InlineData(13, 61)]
		[InlineData(0, 61)]
		[InlineData(13, 0)]
		public void TestInvalidInput(int hours, int minutes) {
			Assert.Throws<ArgumentException>(() => { TaskOne.Calculator.GetAngle(hours, minutes); });
		}

		[Theory]
		[InlineData(0, 0, 0)]
		[InlineData(12, 60, 0)]
		[InlineData(3, 0, 90)]
		[InlineData(9, 0, 90)]
		[InlineData(6, 0, 180)]
		[InlineData(0, 15, 82.5)]
		[InlineData(0, 30, 165)]
		[InlineData(0, 45, 112.5)]
		[InlineData(0, 1, 5.5)]
		[InlineData(11, 59, 5.5)]
		[InlineData(1, 1, 24.5)]
		public void TestValidInput(int hours, int minutes, float angle) {
			Assert.Equal(angle, TaskOne.Calculator.GetAngle(hours, minutes));
		}
	}
}