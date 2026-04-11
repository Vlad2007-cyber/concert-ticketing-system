using System;

namespace lab2OOP
{
    public class Mouse : Device
    {
        public string? Type { get; set; }
        public int DPI { get; set; }

        public override string FileName => "Mouse.txt";

        public Mouse()
        {
            Type = string.Empty;
            DPI = 0;
        }

        public Mouse(Guid id, string name, Driver? driver, string type, int dpi)
            : base(id, name, driver)
        {
            Type = type;
            DPI = dpi;
        }

        public new bool IsValid()
        {
            return base.IsValid() &&
                   !string.IsNullOrEmpty(Type) &&
                   DPI > 0;
        }

        public override string Format()
        {
            return $"{base.Format()}[{Type}][{DPI}]";
        }

        public override string GetShortInfo()
        {
            return $"{Name} | {Type} | DPI: {DPI}";
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
                throw new FormatException("Invalid mouse record format.");
            }

            base.Parse($"[{parts[0]}][{parts[1]}][{parts[2]}]");

            Type = parts[3];

            if (!int.TryParse(parts[4], out int dpi))
            {
                throw new FormatException("Invalid DPI format.");
            }

            DPI = dpi;
        }
    }
}