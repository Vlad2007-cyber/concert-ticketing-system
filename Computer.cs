using System;
using System.Collections.Generic;
using System.Text;

namespace lab2OOP
{
    public class Computer : Entity, ISearchable
    {
        public string? Name { get; set; }
        public SystemUnit? SystemUnit { get; set; }
        public List<Device>? Devices { get; set; }
        public DateTime CreatedAt { get; set; }

        public static Computer? ListHead { get; set; }
        public Computer? Next { get; set; }

        public override string FileName => "Computer.txt";

        public Computer()
        {
            Name = string.Empty;
            SystemUnit = null;
            Devices = new List<Device>();
            CreatedAt = DateTime.Now;
            Next = null;
        }

        public Computer(Guid id, string name, SystemUnit? systemUnit, List<Device>? devices, DateTime createdAt)
            : base(id)
        {
            Name = name;
            SystemUnit = systemUnit;
            Devices = devices;
            CreatedAt = createdAt;
            Next = null;
        }

        public override bool IsValid()
        {
            return base.IsValid() &&
                   !string.IsNullOrWhiteSpace(Name) &&
                   SystemUnit != null &&
                   Devices != null &&
                   Devices.Count > 0;
        }

        public bool Search(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                return true;
            }

            string createdDate = CreatedAt.ToString("dd.MM.yyyy");
            string createdTime = CreatedAt.ToString("HH:mm");
            string createdDateTime = CreatedAt.ToString("dd.MM.yyyy HH:mm");

            return (Name != null &&
                    Name.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                   ||
                   (SystemUnit?.Processor != null &&
                    SystemUnit.Processor.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                   ||
                   createdDate.Contains(searchText, StringComparison.OrdinalIgnoreCase)
                   ||
                   createdTime.Contains(searchText, StringComparison.OrdinalIgnoreCase)
                   ||
                   createdDateTime.Contains(searchText, StringComparison.OrdinalIgnoreCase);
        }

        public override string Format()
        {
            string systemUnitId = SystemUnit != null
                ? SystemUnit.Id.ToString()
                : "null";

            List<string> deviceIds = new List<string>();

            if (Devices != null)
            {
                foreach (Device device in Devices)
                {
                    deviceIds.Add(device.Id.ToString());
                }
            }

            string devicesString = string.Join(", ", deviceIds);

            return $"{base.Format()}[{Name}][{systemUnitId}][{devicesString}][{CreatedAt}]";
        }

        public override void Parse(string record)
        {
            if (string.IsNullOrWhiteSpace(record))
            {
                throw new ArgumentException("Record cannot be null or empty.", nameof(record));
            }

            string[] parts = record.Trim('[', ']')
                                   .Split(new[] { "][" }, StringSplitOptions.None);

            if (parts.Length != 5)
            {
                throw new FormatException("Invalid computer record format.");
            }

            base.Parse($"[{parts[0]}]");

            Name = parts[1];

            if (parts[2] == "null")
            {
                SystemUnit = null;
            }
            else
            {
                if (!Guid.TryParse(parts[2], out Guid systemUnitId))
                {
                    throw new FormatException("Invalid SystemUnit ID format.");
                }

                SystemUnit = new SystemUnit(
                    systemUnitId,
                    string.Empty,
                    null,
                    string.Empty,
                    0,
                    0);
            }

            Devices = new List<Device>();

            if (!string.IsNullOrWhiteSpace(parts[3]))
            {
                string[] deviceIds = parts[3].Split(
                    new[] { ", " },
                    StringSplitOptions.RemoveEmptyEntries);

                foreach (string deviceIdString in deviceIds)
                {
                    if (!Guid.TryParse(deviceIdString, out Guid deviceId))
                    {
                        throw new FormatException("Invalid Device ID format.");
                    }

                    Devices.Add(new Device(deviceId, string.Empty, null));
                }
            }

            if (!DateTime.TryParse(parts[4], out DateTime createdAt))
            {
                throw new FormatException("Invalid CreatedAt format.");
            }

            CreatedAt = createdAt;
        }

        public static void AddToList(Computer computer)
        {
            if (ListHead == null)
            {
                ListHead = computer;
                return;
            }

            Computer current = ListHead;

            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = computer;
        }

        public static string ViewList()
        {
            if (ListHead == null)
            {
                return "The list is empty.";
            }

            StringBuilder builder = new StringBuilder();

            Computer? current = ListHead;
            int index = 1;

            while (current != null)
            {
                builder.AppendLine(
                    $"{index}. " +
                    $"Name: {current.Name}, " +
                    $"Processor: {current.SystemUnit?.Processor}, " +
                    $"RAM: {current.SystemUnit?.RAM} GB, " +
                    $"Storage: {current.SystemUnit?.StorageCapacity} GB, " +
                    $"Created: {current.CreatedAt:dd.MM.yyyy HH:mm}");

                current = current.Next;
                index++;
            }

            return builder.ToString();
        }
    }
}