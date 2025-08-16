using MachOps.Application.Shared.Raws;
using MachOps.Domain.Entities;

namespace MachOps.Application.Shared.Mappers;

public static class MachinaryMapper
{
    public static Machinery ToSingleMachinery(this MachineryRaw machineryRaw)
    {
        return new Machinery
        (
            machineryRaw.Id,
            machineryRaw.Name,
            machineryRaw.MachType,
            machineryRaw.Status,
            machineryRaw.Location,
            machineryRaw.CreatedAt,
            machineryRaw.LastUpdatedAt,
            machineryRaw.Description,
            machineryRaw.Start,
            machineryRaw.Return
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