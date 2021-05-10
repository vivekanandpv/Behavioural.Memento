using System;

namespace Behavioural.Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            Curator curator = new Curator();
            Document doc = new Document { Title = "Initial Title", Body = "Initial Body" };
            

            curator.Save(doc);

            curator.Undo(doc); // No effect
            Console.WriteLine(doc);

            doc.Title = "New Title 1";
            curator.Save(doc);

            Console.WriteLine(doc); //  New Title 1

            doc.Body = "New body 1";    
            Console.WriteLine(doc);

            curator.Undo(doc);  //  New Title 1

            Console.WriteLine(doc);

        }
    }
}
