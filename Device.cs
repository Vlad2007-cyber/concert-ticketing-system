using System;

namespace lab2OOP
{
    public class Device : Entity
    {
        public string? Name { get; set; }
        public Driver? Driver { get; set; }

        public override string FileName => "Device.txt";

        public Device()
        {
            Name = string.Empty;
            Driver = null;
        }

        public Device(Guid id, string name, Driver? driver)
            : base(id)
        {
            Name = name;
            Driver = driver;
        }

        public new bool IsValid()
        {
            return base.IsValid() &&
                   !string.IsNullOrEmpty(Name) &&
                   Driver != null;
        }

        public override string Format()
        {
            string driverId = Driver != null ? Driver.Id.ToString() : "null";
            return $"{base.Format()}[{Name}][{driverId}]";
        }

        public virtual string GetShortInfo()
        {
            return Name ?? string.Empty;
        }

        public override void Parse(string record)
        {
            if (string.IsNullOrWhiteSpace(record))
            {
                throw new ArgumentException("Record cannot be null or empty.", nameof(record));
            }

            var parts = record.Trim('[', ']').Split(new[] { "][" }, StringSplitOptions.None);

            if (parts.Length != 3)
            {
                throw new FormatException("Invalid device record format.");
            }

            base.Parse($"[{parts[0]}]");

            Name = parts[1];

            if (parts[2] == "null")
            {
                Driver = null;
            }
            else
            {
                if (!Guid.TryParse(parts[2], out Guid driverId))
                {
                    throw new FormatException("Invalid Driver ID format.");
                }

                Driver = new Driver(driverId, string.Empty, string.Empty, false, false);
            }
        }
    }
}