namespace Parcels.Application.Models
{
	using System;

	public class FeedbackException : Exception
	{
		public FeedbackException(string message)
			: base(message)
		{

		}
	}
}
