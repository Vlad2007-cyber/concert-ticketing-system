using System;

namespace lab2OOP
{
    public class SystemUnit : Device
    {
        public string? Processor { get; set; }
        public int RAM { get; set; }
        public int StorageCapacity { get; set; }

        public override string FileName => "SystemUnit.txt";

        public SystemUnit()
        {
            Processor = string.Empty;
            RAM = 0;
            StorageCapacity = 0;
        }

        public SystemUnit(Guid id, string name, Driver? driver, string processor, int ram, int storageCapacity)
            : base(id, name, driver)
        {
            Processor = processor;
            RAM = ram;
            StorageCapacity = storageCapacity;
        }

        public new bool IsValid()
        {
            return base.IsValid() &&
                   !string.IsNullOrEmpty(Processor) &&
                   RAM > 0 &&
                   StorageCapacity > 0;
        }

        public sealed override string Format()
        {
            return $"{base.Format()}[{Processor}][{RAM}][{StorageCapacity}]";
        }

        public sealed override string GetShortInfo()
        {
            return $"{Name} | CPU: {Processor} | RAM: {RAM} GB | Storage: {StorageCapacity} GB";
        }

        public override void Parse(string record)
        {
            if (string.IsNullOrWhiteSpace(record))
            {
                throw new ArgumentException("Record cannot be null or empty.", nameof(record));
            }

            var parts = record.Trim('[', ']').Split(new[] { "][" }, StringSplitOptions.None);

            if (parts.Length != 6)
            {
                throw new FormatException("Invalid system unit record format.");
            }

            base.Parse($"[{parts[0]}][{parts[1]}][{parts[2]}]");

            Processor = parts[3];

            if (!int.TryParse(parts[4], out int ram))
            {
                throw new FormatException("Invalid RAM format.");
            }

            if (!int.TryParse(parts[5], out int storageCapacity))
            {
                throw new FormatException("Invalid StorageCapacity format.");
            }

            RAM = ram;
            StorageCapacity = storageCapacity;
        }
    }
}