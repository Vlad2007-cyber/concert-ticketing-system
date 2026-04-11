using System;

namespace lab2OOP
{
    public class Driver : Entity
    {
        public string? Name { get; set; }
        public string? Version { get; set; }
        public bool IsInstalled { get; set; }
        public bool IsTested { get; set; }

        public override string FileName => "Driver.txt";

        public Driver()
        {
            Name = string.Empty;
            Version = string.Empty;
            IsInstalled = false;
            IsTested = false;
        }

        public Driver(Guid id, string name, string version, bool isInstalled, bool isTested)
            : base(id)
        {
            Name = name;
            Version = version;
            IsInstalled = isInstalled;
            IsTested = isTested;
        }

        public new bool IsValid()
        {
            return base.IsValid() &&
                   !string.IsNullOrEmpty(Name) &&
                   !string.IsNullOrEmpty(Version);
        }

        public override string Format()
        {
            return $"{base.Format()}[{Name}][{Version}][{IsInstalled}][{IsTested}]";
        }

        public override void Parse(string record)
        {
            if (string.IsNullOrWhiteSpace(record))
            {
                throw new ArgumentException("Record cannot be null or empty.", nameof(record));
            }

            var parts = record.Trim('[', ']').Split(new[] { "][" }, StringSplitOptions.None);

            if (parts.Length != 5)
            {
                throw new FormatException("Invalid driver record format.");
            }

            base.Parse($"[{parts[0]}]");

            Name = parts[1];
            Version = parts[2];

            if (!bool.TryParse(parts[3], out bool isInstalled))
            {
                throw new FormatException("Invalid IsInstalled format.");
            }

            if (!bool.TryParse(parts[4], out bool isTested))
            {
                throw new FormatException("Invalid IsTested format.");
            }

            IsInstalled = isInstalled;
            IsTested = isTested;
        }
    }
}