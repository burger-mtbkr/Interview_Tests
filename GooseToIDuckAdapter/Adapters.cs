using System;
using System.Collections.Generic;
using System.Text;

namespace GooseToIDuckAdapter
{

	public class GooseToIDuckAdapter : IDuck
	{
		private Goose goose { get; set; }

		public GooseToIDuckAdapter(Goose a)
		{
			this.goose = a;
		}

		public string Quack()
		{
			return this.goose.Honk();
		}	

		public void Fly() { this.goose.Fly(); }

	}

}
