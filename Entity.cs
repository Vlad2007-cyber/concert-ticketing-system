using System;

namespace lab2OOP
{
    public class Entity
    {
        public Guid Id { get; set; }

        public virtual string FileName => "Entity.txt";

        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Entity(Guid id)
        {
            Id = id;
        }

        public bool IsValid()
        {
            return Id != Guid.Empty;
        }

        public virtual string Format()
        {
            return $"[{Id}]";
        }

        public virtual void Parse(string record)
        {
            if (string.IsNullOrWhiteSpace(record))
            {
                throw new ArgumentException("Record cannot be null or empty.", nameof(record));
            }

            var parts = record.Trim('[', ']').Split(new[] { "][" }, StringSplitOptions.None);

            if (parts.Length != 1)
            {
                throw new FormatException("Invalid record format.");
            }

            if (!Guid.TryParse(parts[0], out Guid id))
            {
                throw new FormatException("Invalid ID format.");
            }

            Id = id;
        }
    }
}