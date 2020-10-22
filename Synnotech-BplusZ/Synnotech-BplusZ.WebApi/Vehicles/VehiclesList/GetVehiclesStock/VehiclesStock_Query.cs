using Raven.Client.Documents.Indexes;
using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;
using System.Collections.Generic;
using System.Linq;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehiclesList.GetVehiclesStock
{
    public class VehiclesStock_Query : AbstractIndexCreationTask<Vehicle>
    {
        public VehiclesStock_Query()
        {
            Map = vehicles => vehicles.Select(vehicle => new VehicleStockSearchIndexResult
            {
                LicenceNumber = vehicle.LicenceNumber,
                BranchOffice = vehicle.TransferData!.BranchOffice,
                Manufacturer = vehicle.Manufacturer,
                Model = vehicle.Model,
                Status = vehicle.Status,
                ConstructionType = vehicle.TechnicalComponents!.ConstructionType,
                Type = vehicle.Type,
                DeleteDate = vehicle.DeleteDate,
                Appointment = vehicle.Appointment,
                Info = vehicle.Info,
                VehicleClass = vehicle.VehicleClass,
                Query = new List<string>
                {
                    vehicle.Manufacturer ?? string.Empty,
                    vehicle.TechnicalComponents!.ConstructionType ?? string.Empty,
                    vehicle.Model ?? string.Empty,
                    vehicle.TransferData!.BranchOffice ?? string.Empty,
                    vehicle.Info ?? string.Empty,
                    vehicle.Appointment ?? string.Empty,
                    vehicle.VehicleClass ?? string.Empty
                }
            });

            Index("Query", FieldIndexing.Search);
        }
    }
}
