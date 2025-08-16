using MachOps.Application.Shared.Raws;
using MachOps.Domain.Entities;

namespace MachOps.Application.Shared.Mappers;

public static class MachinaryEntityMapper
{
    public static Machinery ToSingleMachinery(this MachineryRaw machineryRaw)
    {
        return new Machinery
        (
            machineryRaw.Id,
            machineryRaw.MachineryName,
            machineryRaw.MachineryType,
            machineryRaw.MachineryStatus,
            machineryRaw.MachineryLocation,
            machineryRaw.MachineryCreatedAt,
            machineryRaw.MachineryLastUpdatedAt,
            machineryRaw.MachineryDescription,
            machineryRaw.MaintenanceStartDate,
            machineryRaw.ExpectedReturnDate
        );
    }

    public static List<Machinery> ToListMachinery(this IEnumerable<MachineryRaw> machineryRaws) => machineryRaws.Select(m => m.ToSingleMachinery()).ToList();

    public static MachineryRaw ToSingleMachineryRaw(this Machinery machinery)
    {
        return new MachineryRaw
        (
            machinery.Id,
            machinery.Name.Value,
            (int)machinery.MachType.Value,
            (int)machinery.Status.Value,
            machinery.Location.Value,
            machinery.CreatedAt.Value,
            machinery.LastUpdatedAt.Value,
            machinery.Description.Value,
            machinery.MaintenanceStart?.Value,
            machinery.MaintenanceReturn?.Value
        );
    }

    public static List<MachineryRaw> ToListMachineryRaw(this List<Machinery> machinery) => machinery.Select(m => m.ToSingleMachineryRaw()).ToList();
}