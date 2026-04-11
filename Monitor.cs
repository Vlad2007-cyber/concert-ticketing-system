using System;

namespace lab2OOP
{
    public sealed class Monitor : Device
    {
        public double ScreenSize { get; set; }
        public string? Resolution { get; set; }

        public override string FileName => "Monitor.txt";

        public Monitor()
        {
            ScreenSize = 0;
            Resolution = string.Empty;
        }

        public Monitor(Guid id, string name, Driver? driver, double screenSize, string resolution)
            : base(id, name, driver)
        {
            ScreenSize = screenSize;
            Resolution = resolution;
        }

        public new bool IsValid()
        {
            return base.IsValid() &&
                   ScreenSize > 0 &&
                   !string.IsNullOrEmpty(Resolution);
        }

        public override string Format()
        {
            return $"{base.Format()}[{ScreenSize}][{Resolution}]";
        }

        public override string GetShortInfo()
        {
            return $"{Name} | {ScreenSize}\" | {Resolution}";
        }

        public void Parse(string record)
        {
            if (string.IsNullOrWhiteSpace(record))
            {
                throw new ArgumentException("Record cannot be null or empty.", nameof(record));
            }

            var parts = record.Trim('[', ']').Split(new[] { "][" }, StringSplitOptions.None);

            if (parts.Length != 5)
            {
                throw new FormatException("Invalid monitor record format.");
            }

            base.Parse($"[{parts[0]}][{parts[1]}][{parts[2]}]");

            if (!double.TryParse(parts[3], out double screenSize))
            {
                throw new FormatException("Invalid ScreenSize format.");
            }

            ScreenSize = screenSize;
            Resolution = parts[4];
        }
    }
}