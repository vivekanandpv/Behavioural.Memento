using System;
using System.Collections.Generic;
using System.Text;

namespace Behavioural.Memento
{
    public class Document
    {
        public string Title { get; set; }
        public string Body { get; set; }

        public DocumentMemento Save()
        {
            return new DocumentMemento(Title, Body);
        }

        public void Undo(DocumentMemento memento)
        {
            Title = memento.Title;
            Body = memento.Body;
        }

        public override string ToString()
        {
            return $"Title: {Title} {Environment.NewLine}Body: {Body} {Environment.NewLine}-------------------------------------";
        }
    }

    public class DocumentMemento
    {
        //  Modern C#
        //public string Title { get; }
        //public string Body { get; }

        //public DocumentMemento(string title, string body)
        //{
        //    Title = title;
        //    Body = body;
        //}

        //  Traditional approach

        private readonly string _title;
        private readonly string _body;

        public DocumentMemento(string title, string body)
        {
            _title = title;
            _body = body;
        }

        public string Title => _title;
        public string Body => _body;
    }

    public class Curator
    {
        private readonly Stack<DocumentMemento> history = new Stack<DocumentMemento>();

        public void Save(Document document)
        {
            history.Push(document.Save());
        }

        public void Undo(Document document)
        {
            if (history.Count > 0)
            {
                document.Undo(history.Pop());
            }
        }
    }
}
