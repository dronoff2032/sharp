using Notes;

DateTime Date = DateTime.Today;

int position = 1;

Note note1 = new Note()
{
    name = "Заметка 1",
    description = "Описание заметки 1",
    dateTime = DateTime.Today.AddDays(3)
};

Note note2 = new Note()
{
    name = "Заметка 2",
    description = "Описание заметки 2",
    dateTime = DateTime.Today
};

Note note3 = new Note()
{
    name = "Заметка 3",
    description = "Описание заметки 3",
    dateTime = DateTime.Today.AddDays(-3)
};

Note note4 = new Note()
{
    name = "Заметка 4",
    description = "Описание заметки 4",
    dateTime = DateTime.Today.AddDays(-5)
};

Note note5 = new Note()
{
    name = "Заметка 5",
    description = "Описание заметки 5",
    dateTime = DateTime.Today.AddDays(+5)
};

Note[] notes = new Note[5];
notes[0] = note1;
notes[1] = note2;
notes[2] = note3;
notes[3] = note4;
notes[4] = note5;

List<Note> list = new List<Note>();

int maxposition;

while (true)
{
    maxposition = 0;

    Console.Clear();
    Console.WriteLine(Date.ToString("dd.MM.yyyy"));
    
    foreach (Note note in notes)
    {
        if (Date == note.dateTime)
        {
            Console.WriteLine("  " + note.name);
            maxposition++;
        }
    }


    while (true)
    {
        if (maxposition != 0)
        {
            Console.SetCursorPosition(0, position);
            Console.WriteLine(">>");
        }

        ConsoleKeyInfo key = Console.ReadKey();

        if (key.Key == ConsoleKey.RightArrow)
        {
            Date = Date.AddDays(1);
            break;
        }
        else if (key.Key == ConsoleKey.LeftArrow)
        {
            Date = Date.AddDays(-1);
            break;
        }

        if (key.Key == ConsoleKey.DownArrow && position != maxposition && maxposition != 0)
        {
            Console.SetCursorPosition(0, position);
            Console.WriteLine("  ");
            position++;
        }
        else if (key.Key == ConsoleKey.UpArrow && position != 1 && maxposition != 0)
        {
            Console.SetCursorPosition(0, position);
            Console.WriteLine("  ");
            position--;
        }
    }
}
