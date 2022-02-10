using System;


namespace Lecture19Composition
{
	interface Controller
	{
		string ChooseAction(Character character, Character enemy);
	}
}
