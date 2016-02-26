using System;
using Foundation;

namespace MoviesExploerer.iOS
{
	public class LocalisationHelper
	{
		public static string Localise(string text)
		{
			return NSBundle.MainBundle.LocalizedString (text, text);
		}
	}
}

