using System;

namespace GooseToIDuckAdapter
{
	class Program
	{
		static void Main(string[] args)
		{
			Goose goose = new Goose();
			var adapter = new GooseToIDuckAdapter(goose);

			var result = adapter.Quack() == goose.Honk();
						
		}
	}
}
