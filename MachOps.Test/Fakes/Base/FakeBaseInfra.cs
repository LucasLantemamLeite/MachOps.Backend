using MachOps.Domain.Entities;

namespace MachOps.Test.Fakes.Base;

public abstract class FakeBaseDb
{
    protected List<Machinery> machines = new()
    {
        new(
            id: 1,
            name: "Empilhadeira",
            machType: 1,
            status: 3,
            location: "Galpão A",
            createdAt: new DateTime(2025, 1, 15),
            updatedAt: new DateTime(2025, 6, 10),
            description: null,
            maintenanceStart: new DateTime(2025, 8, 1),
            expectedReturn: new DateTime(2025, 8, 5)
        ),
        new(
            id: 2,
            name: "Guindaste",
            machType: 6,
            status: 3,
            location: "Doca 3",
            createdAt: new DateTime(2024, 12, 1),
            updatedAt: new DateTime(2025, 7, 25),
            description: "Em manutenção crítica.",
            maintenanceStart: new DateTime(2025, 7, 20),
            expectedReturn: new DateTime(2025, 8, 10)
        ),
        new(
            id: 3,
            name: "Bulldozer",
            machType: 2,
            status: 1,
            location: "Pátio de Manobras",
            createdAt: new DateTime(2025, 3, 3),
            updatedAt: new DateTime(2025, 7, 30),
            description: "Utilizada para limpeza geral.",
            maintenanceStart: null,
            expectedReturn: null
        ),
        new(
            id: 4,
            name: "Trator",
            machType: 5,
            status: 1,
            location: "Galpão B",
            createdAt: new DateTime(2025, 2, 5),
            updatedAt: new DateTime(2025, 6, 20),
            description: "Auxiliando no transporte de cargas.",
            maintenanceStart: new DateTime(2025, 7, 15),
            expectedReturn: new DateTime(2025, 7, 18)
        )
    };
}