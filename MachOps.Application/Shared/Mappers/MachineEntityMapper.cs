using MachOps.Application.Shared.Raws;
using MachOps.Domain.Entities;

namespace MachOps.Application.Shared.Mappers;

public static class MachineEntityMapper
{
    public static MachineEntity ToSingleMachineEntity(this MachineEntityRaw machineRaw)
    {
        return new MachineEntity
        (
            machineRaw.Id,
            machineRaw.Name,
            machineRaw.MachType,
            machineRaw.Status,
            machineRaw.Location,
            machineRaw.CreateAt,
            machineRaw.UpdateAt,
            machineRaw.Description,
            machineRaw.MaintenceStartDate,
            machineRaw.ExpectedReturnDate
        );
    }

    public static List<MachineEntity> ToListMachineEntity(this IEnumerable<MachineEntityRaw> machineRaws) => machineRaws.Select(m => m.ToSingleMachineEntity()).ToList();

    public static MachineEntityRaw ToSingleMachineEntityRaw(this MachineEntity machineEntity)
    {
        return new MachineEntityRaw
        (
            machineEntity.Id,
            machineEntity.Name.Value,
            (int)machineEntity.MachType.Value,
            (int)machineEntity.Status.Value,
            machineEntity.Location.Value,
            machineEntity.CreateAt.Value,
            machineEntity.UpdateAt.Value,
            machineEntity.Description.Value,
            machineEntity.MaintenanceStartDate?.Value,
            machineEntity.ExpectedReturnDate?.Value
        );
    }

    public static List<MachineEntityRaw> ToListMachineEntityRaw(this List<MachineEntity> machineEntities) => machineEntities.Select(m => m.ToSingleMachineEntityRaw()).ToList();
}