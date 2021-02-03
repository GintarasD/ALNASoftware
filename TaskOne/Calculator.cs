using System;

namespace TaskOne {
	public class Calculator {
		/// <exception cref="ArgumentException"></exception>
		public static float GetAngle(int hours, int minutes) {
			// Validate input
			if (hours < 0 || hours > 12) {
				throw new ArgumentException($"Invalid hours: {hours.ToString()}");
			}
			if (minutes < 0 || minutes > 60) {
				throw new ArgumentException($"Invalid minutes: {minutes.ToString()}");
			}
			
			// Clip max values
			if (hours == 12) { hours = 0; }
			// NOTE: Ambiguous, could technically mean the next hour (hours++)
			if (minutes == 60) { minutes = 0; }
			
			// Map the range 0-60 to 0-360
			int minutesAngle = minutes*(360/60);
			
			// Map the minutes angle to 0-<The angle of 1 hour>
			float minutesInfluence = (float)minutesAngle/360 * (360f/12);
			// Map the range 0-12 to 0-360 and account for minutes 
			float hoursAngle = hours*(360/12) + minutesInfluence;
			
			// Find the difference between the two
			float result = Math.Abs(hoursAngle - minutesAngle);
			// Return the minimum
			return Math.Min(result, 360 - result);
		}
		
		
		public static void Main(string[] args) {
			Console.Write("Hours: ");
			int hours = Int32.Parse(Console.ReadLine());
			
			Console.Write("Minutes: ");
			int minutes = Int32.Parse(Console.ReadLine());
			
			float angle = Calculator.GetAngle(hours, minutes);
			Console.WriteLine($"Angle: {angle.ToString()}°");
		}
	}
}