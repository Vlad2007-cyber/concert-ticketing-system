using System;
using System.Collections.Generic;
using System.Text;

namespace lab2OOP
{
    public class Computer : Entity
    {
        public string? Name { get; set; }
        public SystemUnit? SystemUnit { get; set; }
        public List<Device>? Devices { get; set; }

        public static Computer? ListHead { get; set; }
        public Computer? Next { get; set; }

        public override string FileName => "Computer.txt";

        public Computer()
        {
            Name = string.Empty;
            SystemUnit = null;
            Devices = new List<Device>();
            Next = null;
        }

        public Computer(Guid id, string name, SystemUnit? systemUnit, List<Device>? devices)
            : base(id)
        {
            Name = name;
            SystemUnit = systemUnit;
            Devices = devices;
            Next = null;
        }

        public new bool IsValid()
        {
            return base.IsValid() &&
                   !string.IsNullOrEmpty(Name) &&
                   SystemUnit != null &&
                   Devices != null &&
                   Devices.Count > 0;
        }

        public override string Format()
        {
            string systemUnitId = SystemUnit != null ? SystemUnit.Id.ToString() : "null";

            List<string> devicesIds = new List<string>();
            if (Devices != null)
            {
                foreach (var device in Devices)
                {
                    devicesIds.Add(device.Id.ToString());
                }
            }

            string devicesIdsStr = string.Join(", ", devicesIds);

            return $"{base.Format()}[{Name}][{systemUnitId}][{devicesIdsStr}]";
        }

        public override void Parse(string record)
        {
            if (string.IsNullOrWhiteSpace(record))
            {
                throw new ArgumentException("Record cannot be null or empty.", nameof(record));
            }

            var parts = record.Trim('[', ']').Split(new[] { "][" }, StringSplitOptions.None);

            if (parts.Length != 4)
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

                SystemUnit = new SystemUnit(systemUnitId, string.Empty, null, string.Empty, 0, 0);
            }

            Devices = new List<Device>();

            if (!string.IsNullOrWhiteSpace(parts[3]))
            {
                var deviceIds = parts[3].Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var deviceIdStr in deviceIds)
                {
                    if (!Guid.TryParse(deviceIdStr, out Guid deviceId))
                    {
                        throw new FormatException("Invalid Device ID format.");
                    }

                    Devices.Add(new Device(deviceId, string.Empty, null));
                }
            }
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
            int index = 1; while (current != null)
            {
                builder.AppendLine(
                    $"{index}. " +
                    $"Name: {current.Name}, " +
                    $"Processor: {current.SystemUnit?.Processor}, " +
                    $"RAM: {current.SystemUnit?.RAM} GB, " +
                    $"Storage: {current.SystemUnit?.StorageCapacity} GB");

                current = current.Next;
                index++;
            }

            return builder.ToString();
        }
    }
}