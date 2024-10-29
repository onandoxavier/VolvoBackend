using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volvo.API.Domain.Entities;
using Volvo.API.Domain.Models.Enum;

namespace Volvo.API.Data.Mapping
{
    public class TruckMapping : IEntityTypeConfiguration<Truck>
    {
        public void Configure(EntityTypeBuilder<Truck> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(t => t.Chassis, chassisBuilder =>
            {
                chassisBuilder
                    .Property(c => c.Value)
                    .HasColumnName("Chassis")
                    .HasMaxLength(17);
            });

            builder.OwnsOne(t => t.Color, colorBuilder =>
            {
                colorBuilder
                    .Property(c => c.Value)
                    .HasColumnName("Color")
                    .HasMaxLength(6);
            });

            builder.HasIndex(x => x.Id);

            builder.ToTable("Truck");

            // Generate GUIDs for Truck IDs
            var truck1Id = Guid.NewGuid();
            var truck2Id = Guid.NewGuid();
            var truck3Id = Guid.NewGuid();
            var truck4Id = Guid.NewGuid();
            var truck5Id = Guid.NewGuid();
            var truck6Id = Guid.NewGuid();
            builder.HasData(
                new Truck(id: truck1Id, year: 2024, model: EModelType.FM, plan: EPlan.France),
                new Truck(id: truck2Id, year: 2025, model: EModelType.VM, plan: EPlan.Brazil),
                new Truck(id: truck3Id, year: 2022, model: EModelType.FH, plan: EPlan.UnitedStates),
                new Truck(id: truck4Id, year: 2024, model: EModelType.FM, plan: EPlan.Sweden),
                new Truck(id: truck5Id, year: 2024, model: EModelType.VM, plan: EPlan.UnitedStates),
                new Truck(id: truck6Id, year: 2019, model: EModelType.FH, plan: EPlan.Brazil));

            // Seed data for Chassis
            builder.OwnsOne(t => t.Chassis).HasData(
                new { TruckId = truck1Id, Value = "2AAHv2LVP8um07368" },
                new { TruckId = truck2Id, Value = "6892KV2s2s83G8420" },
                new { TruckId = truck3Id, Value = "479ykee0T2ASA5694" },
                new { TruckId = truck4Id, Value = "39hF4AjvA4Al77410" },
                new { TruckId = truck5Id, Value = "1NXBR12E31Z463785" },
                new { TruckId = truck6Id, Value = "1GNKVGED5CJ196120" }
            );

            // Seed data for Color
            builder.OwnsOne(t => t.Color).HasData(
                new { TruckId = truck1Id, Value = "5be932" },
                new { TruckId = truck2Id, Value = "8e5f1c" },
                new { TruckId = truck3Id, Value = "6c6d02" },
                new { TruckId = truck4Id, Value = "6fa9e3" },
                new { TruckId = truck5Id, Value = "22ddd2" },
                new { TruckId = truck6Id, Value = "fcadaf" }
            );
        }
    }
}
