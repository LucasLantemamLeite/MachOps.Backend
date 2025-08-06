using System.Reflection.PortableExecutable;
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

    public static IEnumerable<MachineEntity> ToEnumerableMachineEntity(this IEnumerable<MachineEntityRaw> machineRaws) => machineRaws.Select(m => m.ToSingleMachineEntity());
}